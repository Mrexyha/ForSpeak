<script setup lang="ts">
import { ref } from 'vue'

const readingAnswer = ref('')
const readingFeedback = ref<string | null>(null)

function checkReadingAnswer() {
  if (readingAnswer.value.toLowerCase() === 'framework') {
    readingFeedback.value = '✅ Правильно!'
  } else {
    readingFeedback.value = '❌ Спробуйте ще раз.'
  }
}
</script>

<template>
  <div class="task">
    <h2>📚 Завдання на читання</h2>
    <p>Вставте пропущене слово:</p>
    <p class="sentence">"Vue.js is a progressive JavaScript ____ for building user interfaces."</p>
    <input v-model="readingAnswer" placeholder="Введіть відповідь" />
    <button @click="checkReadingAnswer">Перевірити</button>
    <p
      v-if="readingFeedback"
      :class="{
        correct: readingFeedback.includes('Правильно'),
        incorrect: readingFeedback.includes('Спробуйте'),
      }"
    >
      {{ readingFeedback }}
    </p>
  </div>
</template>

<style scoped>
.task {
  padding: 20px;
  background-color: #ffffff;
  border-radius: 12px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  max-width: 500px;
  margin: 20px auto;
  text-align: center;
  margin-top: 100px;
}

h2 {
  font-size: 22px;
  color: #1e3a8a;
  margin-bottom: 15px;
}

.sentence {
  font-size: 18px;
  color: #333;
  margin-bottom: 15px;
}

input {
  padding: 10px;
  width: 80%;
  max-width: 300px;
  border: 1px solid #ccc;
  border-radius: 8px;
  font-size: 16px;
  margin-bottom: 15px;
  transition: border 0.3s;
}

input:focus {
  border: 1px solid #4a90e2;
  outline: none;
}

button {
  padding: 12px 20px;
  font-size: 16px;
  background: #4a90e2;
  color: white;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  transition: background 0.3s;
}

button:hover {
  background: #1e3a8a;
}

button:active {
  transform: scale(0.98);
}

p {
  margin-top: 20px;
  font-size: 18px;
  font-weight: bold;
}

.correct {
  color: #28a745;
}

.incorrect {
  color: #dc3545;
}
</style>
