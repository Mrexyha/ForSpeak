<script setup lang="ts">
import { ref, onMounted, onUnmounted, computed } from 'vue'
import { useRoute } from 'vue-router'
import { fetchSpeaking, type SpeakingPhrase } from '@/app/services/speakingService'
import axios from 'axios'
import { useAuthStore } from '@/app/stores/auth'

const route = useRoute()
const auth = useAuthStore()
auth.initFromLocalStorage()

const userId = computed(() => auth.currentUser?.id ?? null)

const languageId = Number(route.params.languageId)
const lessonId = Number(route.params.lessonId || route.params.id)

const phrases = ref<SpeakingPhrase[]>([])
const currentIndex = ref(0)
const currentPhrase = ref<string>('')

const isPlaying = ref(false)
const isRecording = ref(false)
const spokenPhrase = ref('')
const similarity = ref<number | null>(null)

const attempts = ref<number[]>([])
const averageResult = ref<number | null>(null)

let recognition: SpeechRecognition | null = null
const synth = window.speechSynthesis

async function loadPhrases() {
  if (!userId.value) {
    console.warn('Неавторизований користувач не може проходити говоріння')
    return
  }

  try {
    const key = `speakingAttempts-${languageId}-${lessonId}`
    const attemptCount = Number(localStorage.getItem(key)) || 0
    if (attemptCount >= 3) {
      return
    }

    const module = await fetchSpeaking(languageId, lessonId)
    phrases.value = module.phrases
    if (phrases.value.length > 0) {
      currentPhrase.value = phrases.value[0].text
    }
  } catch (err) {
    console.error('Не вдалося завантажити фрази для говоріння:', err)
  }
}

onMounted(() => {
  loadPhrases()

  const ctor = window.SpeechRecognition || window.webkitSpeechRecognition
  if (!ctor) return
  recognition = new ctor()
  recognition.lang = 'en-US'
  recognition.continuous = false
  recognition.interimResults = false

  recognition.onresult = (event: any) => {
    const transcript = event.results[0][0].transcript as string
    spokenPhrase.value = transcript
    calculateSimilarity(transcript)
  }
  recognition.onend = () => {
    isRecording.value = false
  }
})

onUnmounted(() => {
  if (recognition) recognition.stop()
  synth.cancel()
})

const playPhrase = () => {
  if (!currentPhrase.value) return
  isPlaying.value = true
  const utt = new SpeechSynthesisUtterance(currentPhrase.value)
  utt.lang = 'en-US'
  utt.onend = () => {
    isPlaying.value = false
  }
  synth.speak(utt)
}

const startRecording = () => {
  if (!recognition) return
  spokenPhrase.value = ''
  similarity.value = null
  isRecording.value = true
  recognition.start()
}

const stopRecording = () => {
  if (!recognition) return
  recognition.stop()
  isRecording.value = false
}

const calculateSimilarity = (spokenText: string) => {
  const a = currentPhrase.value.toLowerCase()
  const b = spokenText.toLowerCase()

  const dp: number[][] = Array(b.length + 1)
    .fill(0)
    .map(() => Array(a.length + 1).fill(0))

  for (let i = 0; i <= b.length; i++) dp[i][0] = i
  for (let j = 0; j <= a.length; j++) dp[0][j] = j

  for (let i = 1; i <= b.length; i++) {
    for (let j = 1; j <= a.length; j++) {
      dp[i][j] =
        b[i - 1] === a[j - 1]
          ? dp[i - 1][j - 1]
          : Math.min(dp[i - 1][j - 1] + 1, dp[i][j - 1] + 1, dp[i - 1][j] + 1)
    }
  }

  const dist = dp[b.length][a.length]
  const maxLen = Math.max(a.length, b.length)
  similarity.value = Math.round(((maxLen - dist) / maxLen) * 100)
}

const selectPhrase = (index: number) => {
  currentIndex.value = index
  currentPhrase.value = phrases.value[index].text
  spokenPhrase.value = ''
  similarity.value = null
  attempts.value = []
  averageResult.value = null
}

async function nextPhrase() {
  if (similarity.value !== null) {
    attempts.value.push(similarity.value)
  }

  if (currentIndex.value + 1 < phrases.value.length) {
    currentIndex.value++
    currentPhrase.value = phrases.value[currentIndex.value].text
    spokenPhrase.value = ''
    similarity.value = null
  } else {
    const sum = attempts.value.reduce((acc, x) => acc + x, 0)
    const avg = attempts.value.length > 0 ? sum / attempts.value.length : 0
    averageResult.value = Math.round(avg)

    const key = `speakingAttempts-${languageId}-${lessonId}`
    const prevCount = Number(localStorage.getItem(key)) || 0
    localStorage.setItem(key, String(prevCount + 1))

    if (!userId.value) {
      console.error('Потрібно увійти, щоб зберегти результат говоріння.')
      return
    }

    try {
      await axios.post(
        `https://localhost:7058/api/languages/${languageId}/lessons/${lessonId}/speaking/results/${userId.value}`,
        { averageAccuracy: avg },
      )
      console.log('Результат говоріння успішно збережено')
    } catch (e) {
      console.error('Не вдалося зберегти результат говоріння:', e)
    }
  }
}
</script>

<template>
  <div class="speaking-exercise">
    <div class="all-phrases">
      <h4>Усі фрази:</h4>
      <ul>
        <li
          v-for="(p, i) in phrases"
          :key="p.id"
          :class="{ active: i === currentIndex }"
          @click="selectPhrase(i)"
        >
          {{ p.text }}
        </li>
      </ul>
    </div>

    <div class="phrase-container">
      <h3>Фраза для повторення:</h3>
      <p class="current">{{ currentPhrase }}</p>
    </div>

    <div class="controls">
      <button @click="playPhrase" :disabled="isPlaying || isRecording">
        {{ isPlaying ? '▶️ Відтворюємо...' : '▶️ Прослухати' }}
      </button>
      <button @click="startRecording" :disabled="isRecording || isPlaying">
        {{ isRecording ? '🎙️ Говоріть...' : '🎙️ Повторити' }}
      </button>
      <button @click="stopRecording" :disabled="!isRecording">🛑 Зупинити</button>
      <button
        class="next-btn"
        @click="nextPhrase"
        :disabled="similarity === null && attempts.length === currentIndex"
      >
        {{ currentIndex + 1 < phrases.length ? '➡️ Наступна фраза' : '🔒 Завершити тест' }}
      </button>
    </div>

    <div v-if="similarity !== null" class="result">
      <h4>Результат:</h4>
      <p>
        Схожість: <strong>{{ similarity }}%</strong>
      </p>
      <p>Ваша відповідь: “{{ spokenPhrase }}”</p>
    </div>

    <div v-if="averageResult !== null" class="final-result">
      <h4>Тестування завершено</h4>
      <p>
        Ваш середній відсоток вимови: <strong>{{ averageResult }}%</strong>
      </p>
    </div>
  </div>
</template>

<style scoped>
.speaking-exercise {
  max-width: 700px;
  margin: 50px auto;
  margin-top: 100px;
  padding: 30px;
  background: #fafafa;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  font-family: sans-serif;
}

.all-phrases {
  margin-bottom: 20px;
}
.all-phrases ul {
  display: flex;
  flex-wrap: wrap;
  gap: 8px;
  padding: 0;
  list-style: none;
}
.all-phrases li {
  padding: 6px 12px;
  background: #e0e0e0;
  border-radius: 20px;
  cursor: pointer;
  transition: background 0.2s;
}
.all-phrases li:hover {
  background: #d5d5d5;
}
.all-phrases li.active {
  background: #4caf50;
  color: white;
}

.phrase-container {
  text-align: center;
  margin-bottom: 20px;
}
.phrase-container .current {
  font-size: 22px;
  font-weight: bold;
  color: #333;
  margin-top: 8px;
}

.controls {
  display: flex;
  justify-content: center;
  gap: 12px;
  margin-bottom: 20px;
}
.controls button {
  padding: 10px 18px;
  border: none;
  border-radius: 6px;
  background: #4caf50;
  color: white;
  font-size: 16px;
  cursor: pointer;
  transition:
    background 0.2s,
    transform 0.1s;
}
.controls button:disabled {
  background: #aaa;
  cursor: not-allowed;
}
.controls button:not(:disabled):hover {
  background: #45a047;
  transform: translateY(-2px);
}

.next-btn {
  background: #2196f3;
}
.next-btn:disabled {
  background: #aaa;
}
.next-btn:not(:disabled):hover {
  background: #1976d2;
  transform: translateY(-2px);
}

.result {
  background: #fff;
  border: 2px solid #4caf50;
  border-radius: 8px;
  padding: 15px;
  text-align: center;
  margin-bottom: 20px;
}
.result h4 {
  margin-bottom: 10px;
  color: #4caf50;
}
.result p {
  margin: 6px 0;
  font-size: 16px;
}

.final-result {
  background: #fff;
  border: 2px solid #2196f3;
  border-radius: 8px;
  padding: 15px;
  text-align: center;
  margin-top: 20px;
}
.final-result h4 {
  margin-bottom: 10px;
  color: #2196f3;
}
.final-result p {
  margin: 6px 0;
  font-size: 16px;
}
</style>
