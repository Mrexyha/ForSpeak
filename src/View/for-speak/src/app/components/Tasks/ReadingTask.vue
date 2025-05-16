<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { fetchReading, type ReadingModule } from '@/app/services/readingService'

const route = useRoute()
const languageId = Number(route.params.languageId)
const lessonId = Number(route.params.id)

const moduleData = ref<ReadingModule | null>(null)
const loading = ref(true)
const error = ref<string | null>(null)

const currentIndex = ref(0)
const answer = ref('')
const feedback = ref<string | null>(null)
const score = ref(0)

async function load() {
  try {
    moduleData.value = await fetchReading(languageId, lessonId)
  } catch (e) {
    console.error(e)
    error.value = 'Failed to load text'
  } finally {
    loading.value = false
  }
}

function check() {
  if (!moduleData.value) return
  const correct = moduleData.value.tasks[currentIndex.value].correctWord.toLowerCase()
  if (answer.value.trim().toLowerCase() === correct) {
    feedback.value = '✅ Правильно'
    score.value++
  } else {
    feedback.value = `❌ Неправильно, правильно: "${correct}"`
  }
}

function next() {
  answer.value = ''
  feedback.value = null
  if (moduleData.value && currentIndex.value + 1 < moduleData.value.tasks.length) {
    currentIndex.value++
  }
}

onMounted(load)
</script>

<template>
  <div class="reading">
    <h2 class="title">📚 Читання</h2>

    <div v-if="loading" class="info">Завантаження...</div>
    <div v-else-if="error" class="error">{{ error }}</div>
    <div v-else-if="!moduleData?.tasks.length" class="info">Завдань немає</div>
    <div v-else>
      <p class="text">{{ moduleData.text }}</p>

      <div class="task-block" v-if="currentIndex < moduleData.tasks.length">
        <p class="sentence">
          {{ moduleData.tasks[currentIndex].sentence.replace('____', '_____') }}
        </p>

        <input v-model="answer" :disabled="!!feedback" placeholder="Вставте слово" />

        <button class="btn-check" @click="check" :disabled="!answer.trim() || !!feedback">
          Перевірити
        </button>

        <p
          v-if="feedback"
          :class="{ correct: feedback.startsWith('✅'), incorrect: feedback.startsWith('❌') }"
        >
          {{ feedback }}
        </p>

        <button
          v-if="feedback && currentIndex + 1 < moduleData.tasks.length"
          class="btn-next"
          @click="next"
        >
          Далі
        </button>

        <div v-else-if="feedback && currentIndex + 1 === moduleData.tasks.length" class="summary">
          <p>Тестування завершено!</p>
          <p>
            Ваш результат: <strong>{{ score }} / {{ moduleData.tasks.length }}</strong>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.reading {
  max-width: 700px;
  margin: 50px auto;
  margin-top: 100px;
  padding: 30px;
  background: #ffffff;
  border-radius: 12px;
  box-shadow: 0 6px 20px rgba(0, 0, 0, 0.1);
}
.title {
  text-align: center;
  font-size: 28px;
  color: #1e3a8a;
  margin-bottom: 20px;
}
.info {
  text-align: center;
  font-size: 18px;
  color: #555;
  margin: 20px 0;
}
.text {
  font-size: 16px;
  line-height: 1.6;
  margin-bottom: 30px;
  color: #333;
}
.task-block {
  background: #f7fafc;
  padding: 20px;
  border-radius: 8px;
}
.sentence {
  font-style: italic;
  font-size: 18px;
  margin-bottom: 15px;
  color: #2d3748;
}
input {
  width: 100%;
  max-width: 300px;
  padding: 10px;
  font-size: 16px;
  border: 2px solid #cbd5e0;
  border-radius: 6px;
  margin-bottom: 15px;
  transition: border-color 0.3s;
}
input:focus {
  border-color: #4a90e2;
  outline: none;
}
.btn-check,
.btn-next {
  padding: 10px 20px;
  font-size: 16px;
  margin-right: 10px;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  transition:
    background 0.3s,
    transform 0.2s;
}
.btn-check {
  background: #4a90e2;
  color: #fff;
}
.btn-check:disabled {
  background: #a0aec0;
  cursor: not-allowed;
}
.btn-check:hover:not(:disabled) {
  background: #1e3a8a;
  transform: translateY(-2px);
}
.btn-next {
  background: #48bb78;
  color: #fff;
}
.btn-next:hover {
  background: #2f855a;
  transform: translateY(-2px);
}
.correct {
  color: #2f855a;
  font-weight: bold;
  margin-top: 10px;
}
.incorrect {
  color: #e53e3e;
  font-weight: bold;
  margin-top: 10px;
}
.summary {
  margin-top: 20px;
  text-align: center;
  font-size: 18px;
  font-weight: bold;
}
.error {
  color: #e53e3e;
  font-weight: bold;
  text-align: center;
  margin: 20px 0;
}
</style>
