<script setup lang="ts">
import { ref } from 'vue'

const quizQuestion = ref('What is Vue.js?')
const quizOptions = ref(['A framework', 'A database', 'An API'])
const quizCorrectAnswer = ref('A framework')
const quizResult = ref<string | null>(null)

function checkAnswer(option: string) {
  quizResult.value = option === quizCorrectAnswer.value ? '✅ Правильно!' : '❌ Неправильно!'
}
</script>

<template>
  <div class="task">
    <h2>📝 Квіз</h2>
    <p class="question">{{ quizQuestion }}</p>
    <ul class="options">
      <li v-for="(option, index) in quizOptions" :key="index">
        <button @click="checkAnswer(option)" class="option-button">{{ option }}</button>
      </li>
    </ul>
    <p
      v-if="quizResult !== null"
      :class="{
        correct: quizResult.includes('Правильно'),
        incorrect: quizResult.includes('Неправильно'),
      }"
    >
      {{ quizResult }}
    </p>
  </div>
</template>

<style scoped>
.task {
  padding: 20px;
  background-color: #ffffff;
  border-radius: 12px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  max-width: 500px;
  margin: 20px auto;
  text-align: center;
  margin-top: 100px;
}

h2 {
  font-size: 24px;
  color: #2b6cb0;
  margin-bottom: 15px;
}

.question {
  font-size: 18px;
  margin-bottom: 15px;
  color: #333;
}

.options {
  list-style-type: none;
  padding: 0;
}

.option-button {
  width: 100%;
  padding: 12px;
  font-size: 16px;
  background: #4a90e2;
  color: white;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  margin: 10px 0;
  transition:
    background-color 0.3s,
    transform 0.3s;
}

.option-button:hover {
  background: #1e3a8a;
}

.option-button:active {
  transform: scale(0.98);
}

.correct {
  color: #28a745;
  font-weight: bold;
}

.incorrect {
  color: #dc3545;
  font-weight: bold;
}

p {
  font-size: 18px;
  font-weight: bold;
  margin-top: 20px;
}
</style>
