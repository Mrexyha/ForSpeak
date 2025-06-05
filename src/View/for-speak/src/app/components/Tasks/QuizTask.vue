<script setup lang="ts">
import { ref, onMounted, computed } from 'vue'
import { useRoute } from 'vue-router'
import { fetchQuiz, type QuizQuestion } from '@/app/services/quizService'
import axios from 'axios'
import { useAuthStore } from '@/app/stores/auth'

const route = useRoute()
const auth = useAuthStore()

auth.initFromLocalStorage()

const userId = computed(() => auth.currentUser?.id ?? null)

const languageId = Number(route.params.languageId)
const lessonId = Number(route.params.id)

const questions = ref<QuizQuestion[]>([])
const current = ref(0)
const selected = ref<number | null>(null)
const lastSelected = ref<number | null>(null)
const score = ref(0)
const finished = ref(false)
const error = ref<string | null>(null)

async function load() {
  if (!userId.value) {
    error.value = 'Будь ласка, увійдіть у систему'
    return
  }

  try {
    const key = `quizAttempts-${languageId}-${lessonId}`
    const attemptCount = Number(localStorage.getItem(key)) || 0
    if (attemptCount >= 3) {
      error.value = 'Ви вже вичерпали 3 спроби.'
      return
    }

    const quiz = await fetchQuiz(languageId, lessonId)
    questions.value = quiz.questions
  } catch (e) {
    console.error(e)
    error.value = 'Не вдалося завантажити тестування.'
  }
}

async function submitAnswer() {
  if (selected.value === null) return

  lastSelected.value = selected.value

  if (selected.value === questions.value[current.value].correctOptionIndex) {
    score.value++
  }

  selected.value = null

  if (current.value + 1 < questions.value.length) {
    current.value++
  } else {
    finished.value = true

    const key = `quizAttempts-${languageId}-${lessonId}`
    const prevCount = Number(localStorage.getItem(key)) || 0
    localStorage.setItem(key, String(prevCount + 1))

    if (!userId.value) {
      error.value = 'Потрібно увійти, щоб зберегти результат.'
      return
    }

    try {
      await axios.post(
        `https://localhost:7058/api/languages/${languageId}/lessons/${lessonId}/quiz/results/${userId.value}`,
        { score: score.value },
      )
      console.log('Результат тестування успішно збережено')
    } catch (err) {
      console.error('Не вдалося зберегти результат тестування на бекенд:', err)
      error.value = 'Помилка при збереженні результату'
    }
  }
}

onMounted(load)
</script>

<template>
  <div class="task">
    <h2>📝 Тестування</h2>

    <div v-if="error" class="error">{{ error }}</div>
    <div v-else-if="questions.length === 0">Завантаження...</div>
    <div v-else>
      <div v-if="!finished">
        <div class="progress-bar">
          <div
            class="progress-bar__fill"
            :style="{ width: ((current + 1) / questions.length) * 100 + '%' }"
          ></div>
        </div>

        <p class="question">
          <strong>Питання {{ current + 1 }} з {{ questions.length }}:</strong><br />
          {{ questions[current].question }}
        </p>

        <ul class="options">
          <li v-for="(option, index) in questions[current].options" :key="index">
            <label
              class="option-button"
              :class="{
                correct: finished && index === questions[current].correctOptionIndex,
                incorrect:
                  finished &&
                  lastSelected === index &&
                  index !== questions[current].correctOptionIndex,
              }"
            >
              <input type="radio" :value="index" v-model.number="selected" class="sr-only" />
              {{ option }}
            </label>
          </li>
        </ul>

        <button @click="submitAnswer" :disabled="selected === null">Відповісти</button>
      </div>

      <div v-else class="result">
        <p>
          Тестування завершено! Ваш результат:
          <strong>{{ score }}</strong> / {{ questions.length }}
        </p>
        <p>Результат збережено в базі</p>
      </div>
    </div>
  </div>
</template>

<style scoped>
.task {
  padding: 20px;
  background-color: #ffffff;
  border-radius: 12px;
  box-shadow: 0 6px 20px rgba(0, 0, 0, 0.1);
  max-width: 600px;
  margin: 40px auto;
  margin-top: 100px;
  text-align: center;
  position: relative;
}

.progress-bar {
  width: 100%;
  height: 8px;
  background: #e2e8f0;
  border-radius: 4px;
  overflow: hidden;
  margin-bottom: 20px;
}
.progress-bar__fill {
  height: 100%;
  background: linear-gradient(135deg, #4a90e2, #1e3a8a);
  transition: width 0.3s ease;
}

h2 {
  font-size: 26px;
  color: #2b6cb0;
  margin-bottom: 10px;
}

.question {
  font-size: 20px;
  margin: 20px 0;
  color: #2d3748;
  line-height: 1.4;
}

.options {
  list-style: none;
  padding: 0;
  display: grid;
  grid-template-columns: 1fr;
  gap: 12px;
}
.option-button {
  display: block;
  width: 100%;
  padding: 14px 18px;
  font-size: 16px;
  background: #edf2f7;
  color: #2d3748;
  border: 2px solid transparent;
  border-radius: 8px;
  cursor: pointer;
  text-align: left;
  transition:
    background 0.3s,
    border-color 0.3s,
    transform 0.2s;
}
.option-button:hover {
  background: #e2e8f0;
  border-color: #4a90e2;
  transform: translateY(-2px);
}
.option-button:focus-within {
  border-color: #1e3a8a;
  outline: none;
}

.option-button.correct {
  background: #c6f6d5;
  border-color: #48bb78;
  color: #22543d;
}
.option-button.incorrect {
  background: #fed7d7;
  border-color: #f56565;
  color: #742a2a;
}

button {
  margin-top: 25px;
  padding: 12px 24px;
  font-size: 16px;
  background: #4a90e2;
  color: white;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  transition:
    background 0.3s,
    transform 0.2s;
}
button:disabled {
  background: #a0aec0;
  cursor: not-allowed;
}
button:not(:disabled):hover {
  background: #1e3a8a;
  transform: translateY(-2px);
}

.result {
  margin-top: 30px;
  padding: 20px;
  background: #ffffff;
  border: 2px solid #e2e8f0;
  border-radius: 10px;
}
.result p {
  font-size: 20px;
  color: #2d3748;
  margin: 0;
}
.result strong {
  color: #4a90e2;
}

.error {
  color: #e53e3e;
  font-weight: bold;
  margin: 20px 0;
}
</style>
