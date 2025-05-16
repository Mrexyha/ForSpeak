<script setup lang="ts">
import { ref } from 'vue'

const selectedLanguageId = ref<number | null>(null)
const moduleTitle = ref('')
const theory = ref('')
const quizQuestions = ref([{ question: '', options: ['', '', ''], correctOptionIndex: 0 }])
const vocabulary = ref([{ word: '', transcription: '', pronunciationUrl: '', translation: '' }])
const readingTask = ref({ text: '', questions: [{ sentenceWithGap: '', correctWord: '' }] })
const speakingPhrases = ref([''])

const addQuizQuestion = () =>
  quizQuestions.value.push({ question: '', options: ['', '', ''], correctOptionIndex: 0 })
const addVocabularyWord = () =>
  vocabulary.value.push({ word: '', transcription: '', pronunciationUrl: '', translation: '' })
const addReadingQuestion = () =>
  readingTask.value.questions.push({ sentenceWithGap: '', correctWord: '' })
const addSpeakingPhrase = () => speakingPhrases.value.push('')

const submitModule = () => {
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
    <h2 class="title">🛠️ Створити новий модуль</h2>

    <div class="section">
      <label class="field">
        <span>Мова</span>
        <select v-model="selectedLanguageId" class="input">
          <option disabled value="">Оберіть мову</option>
          <option :value="1">Англійська</option>
          <option :value="2">Німецька</option>
        </select>
      </label>
      <label class="field">
        <span>Назва модуля</span>
        <input v-model="moduleTitle" type="text" class="input" />
      </label>
      <label class="field">
        <span>Теорія</span>
        <textarea v-model="theory" rows="4" class="input" />
      </label>
    </div>

    <details class="section" open>
      <summary class="section-title">🧠 Тести</summary>
      <div v-for="(q, idx) in quizQuestions" :key="idx" class="card small-card">
        <input v-model="q.question" placeholder="Питання" class="input mb" />
        <div class="grid options-grid mb">
          <input
            v-for="(opt, i) in q.options"
            :key="i"
            v-model="q.options[i]"
            placeholder="Варіант"
            class="input"
          />
        </div>
        <label class="field-inline">
          <span>Правильний індекс</span>
          <input type="number" v-model="q.correctOptionIndex" min="0" max="2" class="input-small" />
        </label>
      </div>
      <button class="btn" @click="addQuizQuestion">➕ Додати питання</button>
    </details>

    <details class="section">
      <summary class="section-title">📚 Словник</summary>
      <div class="grid vocab-grid">
        <div v-for="(w, idx) in vocabulary" :key="idx" class="card small-card">
          <input v-model="w.word" placeholder="Слово" class="input mb" />
          <input v-model="w.transcription" placeholder="Транскрипція" class="input mb" />
          <input v-model="w.pronunciationUrl" placeholder="URL до вимови" class="input mb" />
          <input v-model="w.translation" placeholder="Переклад" class="input" />
        </div>
      </div>
      <button class="btn" @click="addVocabularyWord">➕ Додати слово</button>
    </details>

    <details class="section">
      <summary class="section-title">📖 Читання</summary>
      <textarea
        v-model="readingTask.text"
        rows="3"
        placeholder="Текст для читання"
        class="input mb"
      />
      <div v-for="(q, idx) in readingTask.questions" :key="idx" class="card small-card">
        <input v-model="q.sentenceWithGap" placeholder="Речення з пропуском" class="input mb" />
        <input v-model="q.correctWord" placeholder="Правильне слово" class="input" />
      </div>
      <button class="btn" @click="addReadingQuestion">➕ Додати питання</button>
    </details>

    <details class="section">
      <summary class="section-title">🗣️ Говоріння</summary>
      <div class="space-y">
        <input
          v-for="(p, idx) in speakingPhrases"
          :key="idx"
          v-model="speakingPhrases[idx]"
          placeholder="Фраза для повторення"
          class="input"
        />
      </div>
      <button class="btn" @click="addSpeakingPhrase">➕ Додати фразу</button>
    </details>

    <button class="btn submit-btn" @click="submitModule">📤 Надіслати модуль</button>
  </div>
</template>

<style scoped>
.admin-module-creator {
  max-width: 720px;
  margin: 2rem auto;
  padding: 1.5rem;
  background: #ffffff;
  border-radius: 1rem;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
}
.title {
  font-size: 1.75rem;
  margin-bottom: 1rem;
  color: #1a202c;
}
.section {
  margin-bottom: 1.5rem;
}
.section-title {
  font-size: 1.25rem;
  font-weight: 600;
  cursor: pointer;
  margin-bottom: 1rem;
}
.field {
  margin-bottom: 1rem;
}
.field span {
  display: block;
  margin-bottom: 0.25rem;
  font-size: 0.95rem;
  color: #2d3748;
}
.input {
  width: 100%;
  padding: 0.5rem;
  border: 1px solid #e2e8f0;
  border-radius: 0.5rem;
  font-size: 1rem;
  color: #2d3748;
}
.input-small {
  width: 4rem;
  padding: 0.4rem;
}
.mb {
  margin-bottom: 0.75rem;
}
.grid {
  display: grid;
  gap: 1rem;
}
.options-grid {
  grid-template-columns: repeat(3, 1fr);
}
.vocab-grid {
  grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
}
.card {
  background: #f7fafc;
  padding: 1rem;
  border-radius: 0.75rem;
}
.small-card {
  margin-bottom: 1rem;
}
.field-inline {
  display: flex;
  align-items: center;
  gap: 0.5rem;
}
.btn {
  display: inline-flex;
  align-items: center;
  gap: 0.5rem;
  padding: 0.6rem 1.2rem;
  background: #4f46e5;
  color: #fff;
  border: none;
  border-radius: 0.75rem;
  cursor: pointer;
  transition: background 0.2s;
}
.btn:hover {
  background: #4338ca;
}
.submit-btn {
  width: 100%;
  margin-top: 2rem;
  justify-content: center;
}
.space-y > * + * {
  margin-top: 0.75rem;
}
</style>
