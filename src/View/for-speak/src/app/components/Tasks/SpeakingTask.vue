<script setup lang="ts">
import { ref } from 'vue'

const speakingTask = ref('Hello, how are you?')
const spokenText = ref('')
const speechFeedback = ref<string | null>(null)

function startSpeechRecognition() {
  if ('SpeechRecognition' in window || 'webkitSpeechRecognition' in window) {
    const recognition = new (window.SpeechRecognition || window.webkitSpeechRecognition)()
    recognition.lang = 'en-US'

    // recognition.onresult = (event: SpeechRecognitionEvent) => {
    //   spokenText.value = event.results[0][0].transcript
    //   speechFeedback.value =
    //     spokenText.value.toLowerCase() === speakingTask.value.toLowerCase()
    //       ? '✅ Вимова правильна!'
    //       : '❌ Спробуйте ще раз.'
    // }

    recognition.start()
  } else {
    speechFeedback.value = '❌ Ваш браузер не підтримує розпізнавання мови.'
  }
}
</script>

<template>
  <div class="task">
    <h2>🎤 Завдання на вимову</h2>
    <p class="instruction">Скажіть фразу: "{{ speakingTask }}"</p>
    <button @click="startSpeechRecognition" class="start-button">🎙️ Запис голосу</button>
    <p v-if="spokenText" class="spoken-text">Ви сказали: "{{ spokenText }}"</p>
    <p
      v-if="speechFeedback"
      :class="{
        correct: speechFeedback.includes('правильна'),
        incorrect: speechFeedback.includes('Спробуйте'),
      }"
    >
      {{ speechFeedback }}
    </p>
  </div>
</template>

<style scoped>
.task {
  padding: 30px;
  background-color: #fff;
  border-radius: 12px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  max-width: 600px;
  margin: 20px auto;
  text-align: center;
  margin-top: 100px;
}

h2 {
  font-size: 26px;
  color: #4caf50;
  margin-bottom: 20px;
}

.instruction {
  font-size: 18px;
  margin-bottom: 20px;
  color: #333;
}

.start-button {
  padding: 12px 25px;
  background-color: #ff5722;
  color: white;
  font-size: 18px;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  transition:
    background-color 0.3s,
    transform 0.2s;
}

.start-button:hover {
  background-color: #e64a19;
}

.start-button:active {
  transform: scale(0.98);
}

.spoken-text {
  font-size: 16px;
  margin-top: 15px;
  color: #555;
}

p {
  font-size: 18px;
  font-weight: bold;
  margin-top: 20px;
}

.correct {
  color: #28a745;
}

.incorrect {
  color: #dc3545;
}
</style>
