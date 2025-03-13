<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()
const isFinished = ref(false)

const goToEducation = () => {
  router.push('/education/english')
}

const finishLearning = () => {
  isFinished.value = true
}

const restoreLearning = () => {
  isFinished.value = false
}
</script>

<template>
  <div class="my-lang-container">
    <div class="content-container">
      <h1 class="title">Англійська мова</h1>
      <div class="my-lang-content">
        <p class="highlight">5 тем у вільному доступі</p>
        <p>Вивчайте слова, граматику, розуміння тексту. Практикуйте вимову та написання.</p>
        <p>Проходьте квізи та отримуйте бали.</p>
      </div>
    </div>
    <div class="btns-container">
      <template v-if="!isFinished">
        <button class="continue-btn" @click="goToEducation">Продовжити</button>
        <button class="finish-btn" @click="finishLearning">Завершити</button>
      </template>
      <button v-else class="restore-btn" @click="restoreLearning">Відновити навчання</button>
    </div>
  </div>
</template>

<style scoped>
.my-lang-container {
  position: relative;
  width: 812px;
  padding: 32px;
  margin: 0 auto;
  background: #ade8f4;
  border-radius: 8px;
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25);
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
}

.title {
  color: #032a5e;
  font-family: Jost, sans-serif;
  font-size: 36px;
  font-weight: 500;
  text-align: left;
  margin-bottom: 10px;
}

.content-container {
  display: flex;
  flex-direction: column;
  flex: 1;
}

.my-lang-content {
  font-family: Inter, sans-serif;
  font-size: 16px;
  font-weight: 600;
  color: #000;
  text-align: left;
  width: 500px;
}

p {
  margin-bottom: 12px;
}

.highlight {
  font-size: 18px;
  font-weight: bold;
}

.btns-container {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  gap: 20px;
  align-items: flex-end;
  height: 100%;
}

button {
  width: 200px;
  height: 42px;
  border-radius: 8px;
  font-family: Inter, sans-serif;
  font-size: 18px;
  font-weight: 600;
  cursor: pointer;
  text-align: center;
  transition: 0.3s ease-in-out;
  border: none;
}

.continue-btn {
  background: #0077b6;
  color: #ffffff;
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25) inset;
}

.continue-btn:hover {
  background: #005b8f;
}

.finish-btn {
  background: #b60003;
  color: #ffffff;
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25) inset;
}

.finish-btn:hover {
  background: #920002;
}

.restore-btn {
  background: #28a745;
  color: white;
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25) inset;
}

.restore-btn:hover {
  background: #218838;
}
</style>
