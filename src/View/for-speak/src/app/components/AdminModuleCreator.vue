<script setup lang="ts">
import { ref } from 'vue'

const selectedLanguageId = ref<number | null>(null)
const moduleTitle = ref('')
const theory = ref('')
const quizQuestions = ref([{ question: '', options: ['', '', ''], correctOptionIndex: 0 }])
const vocabulary = ref([{ word: '', transcription: '', pronunciationUrl: '', translation: '' }])
const readingTask = ref({ text: '', questions: [{ sentenceWithGap: '', correctWord: '' }] })
const speakingPhrases = ref([''])

function addQuizQuestion() {
  quizQuestions.value.push({ question: '', options: ['', '', ''], correctOptionIndex: 0 })
}

function addVocabularyWord() {
  vocabulary.value.push({ word: '', transcription: '', pronunciationUrl: '', translation: '' })
}

function addReadingQuestion() {
  readingTask.value.questions.push({ sentenceWithGap: '', correctWord: '' })
}

function addSpeakingPhrase() {
  speakingPhrases.value.push('')
}

function submitModule() {
  const moduleData = {
    languageId: selectedLanguageId.value,
    title: moduleTitle.value,
    theory: theory.value,
    quizQuestions: quizQuestions.value,
    vocabulary: vocabulary.value,
    reading: readingTask.value,
    speaking: speakingPhrases.value,
  }

  console.log('Відправка модуля:', moduleData)
}
</script>

<template>
  <div class="admin-module-creator">
    <h2>🛠️ Створити модуль</h2>

    <label>
      Мова:
      <select v-model="selectedLanguageId">
        <option disabled value="">Оберіть мову</option>
        <option :value="1">Англійська</option>
        <option :value="2">Німецька</option>
        <!-- інші мови -->
      </select>
    </label>

    <label>
      Назва модуля:
      <input v-model="moduleTitle" type="text" />
    </label>

    <label>
      Теорія:
      <textarea v-model="theory" rows="5" />
    </label>

    <hr />

    <h3>🧠 Тести</h3>
    <div v-for="(q, index) in quizQuestions" :key="index">
      <input v-model="q.question" placeholder="Питання" />
      <div v-for="(opt, i) in q.options" :key="i">
        <input v-model="q.options[i]" placeholder="Варіант відповіді" />
      </div>
      <label>
        Правильний індекс:
        <input type="number" v-model="q.correctOptionIndex" min="0" max="2" />
      </label>
    </div>
    <button @click="addQuizQuestion">Додати питання</button>

    <hr />

    <h3>📚 Словник</h3>
    <div v-for="(w, index) in vocabulary" :key="index">
      <input v-model="w.word" placeholder="Слово" />
      <input v-model="w.transcription" placeholder="Транскрипція" />
      <input v-model="w.pronunciationUrl" placeholder="URL до вимови" />
      <input v-model="w.translation" placeholder="Переклад" />
    </div>
    <button @click="addVocabularyWord">Додати слово</button>

    <hr />

    <h3>📖 Читання</h3>
    <textarea v-model="readingTask.text" placeholder="Текст для читання" rows="5" />
    <div v-for="(q, index) in readingTask.questions" :key="index">
      <input v-model="q.sentenceWithGap" placeholder="Речення з пропуском" />
      <input v-model="q.correctWord" placeholder="Правильне слово" />
    </div>
    <button @click="addReadingQuestion">Додати питання до читання</button>

    <hr />

    <h3>🗣️ Говоріння</h3>
    <div v-for="(p, index) in speakingPhrases" :key="index">
      <input v-model="speakingPhrases[index]" placeholder="Фраза для повторення" />
    </div>
    <button @click="addSpeakingPhrase">Додати фразу</button>

    <hr />
    <button @click="submitModule">📤 Надіслати модуль</button>
  </div>
</template>

<style scoped>
.admin-module-creator {
  max-width: 800px;
  margin: 40px auto;
  background: #f7fafc;
  padding: 20px;
  border-radius: 12px;
}
input,
textarea,
select {
  display: block;
  width: 100%;
  margin-bottom: 12px;
  padding: 10px;
  border-radius: 6px;
  border: 1px solid #cbd5e0;
}
button {
  margin-top: 10px;
  background: #4a90e2;
  color: white;
  border: none;
  padding: 10px 16px;
  border-radius: 8px;
  cursor: pointer;
}
button:hover {
  background: #1e3a8a;
}
hr {
  margin: 24px 0;
}
</style>
