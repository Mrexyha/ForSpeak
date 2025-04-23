<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { fetchVocabulary, type Word } from '../../services/vocabularyService'

const route = useRoute()
const languageId = Number(route.params.languageId)
const lessonId = Number(route.params.id)

const words = ref<Word[]>([])
const loading = ref(false)
const error = ref<string | null>(null)

const speak = (text: string) => {
  if ('speechSynthesis' in window) {
    const utterance = new SpeechSynthesisUtterance(text)
    utterance.lang = 'en-US'
    speechSynthesis.speak(utterance)
  } else {
    alert('Ваш браузер не підтримує синтез мовлення 😢')
  }
}

async function loadVocabulary() {
  loading.value = true
  error.value = null

  try {
    const data = await fetchVocabulary(languageId, lessonId)
    words.value = data.words
  } catch (e) {
    console.error(e)
    error.value = 'Failed to load vocabulary'
  } finally {
    loading.value = false
  }
}

onMounted(loadVocabulary)
</script>

<template>
  <div class="vocabulary">
    <h2>📔 Vocabulary</h2>
    <div v-if="loading">Завантаження даних...</div>
    <div v-else-if="error" class="error">{{ error }}</div>
    <div v-else class="table-container">
      <table>
        <thead>
          <tr>
            <th>Слово</th>
            <th>🔊</th>
            <th>Транскрипція</th>
            <th>Переклад</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="word in words" :key="word.id">
            <td class="word">{{ word.word }}</td>
            <td>
              <button class="speak-btn" @click="speak(word.word)">🔊</button>
            </td>
            <td class="transcription">{{ word.transcription }}</td>
            <td class="translation">{{ word.translation }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<style scoped>
.vocabulary {
  max-width: 900px;
  margin: 50px auto;
  padding: 25px;
  background: #ffffff;
  box-shadow: 0px 6px 15px rgba(0, 0, 0, 0.1);
  border-radius: 12px;
  text-align: center;
  transition: all 0.3s ease-in-out;
  margin-top: 100px;
}

h2 {
  font-size: 28px;
  color: #1e3a8a;
  margin-bottom: 20px;
  text-transform: uppercase;
  letter-spacing: 1px;
}

.table-container {
  overflow-x: auto;
}

table {
  width: 100%;
  border-collapse: collapse;
  background: #f9f9f9;
  border-radius: 12px;
  overflow: hidden;
}

th,
td {
  padding: 15px;
  border-bottom: 2px solid #e0e0e0;
  text-align: center;
}

th {
  background: linear-gradient(135deg, #4a90e2, #1e3a8a);
  color: white;
  font-size: 18px;
}

td {
  font-size: 18px;
}

.word {
  font-weight: bold;
  color: #1e3a8a;
}

.transcription {
  font-size: 16px;
  font-style: italic;
  color: #555;
}

.translation {
  font-size: 18px;
  font-weight: bold;
  color: #008000;
}

.speak-btn {
  background: none;
  border: none;
  font-size: 20px;
  cursor: pointer;
  transition:
    transform 0.2s,
    color 0.2s;
  color: #4a90e2;
}

.speak-btn:hover {
  transform: scale(1.3);
  color: #1e3a8a;
}

@media (max-width: 768px) {
  .vocabulary {
    width: 90%;
    padding: 20px;
  }

  th,
  td {
    padding: 10px;
    font-size: 16px;
  }
}
</style>
