<script setup lang="ts">
import { useRouter } from 'vue-router'

const router = useRouter()

const goToEducation = () => {
  router.push('/education/english')
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
      <button class="continue-btn" @click="goToEducation">Продовжити</button>
      <button class="finish-btn">Завершити</button>
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
  margin: 20px;
}

.continue-btn {
  position: relative;
  width: 200px;
  height: 42px;
  margin: 0 auto;
  border-radius: 8px;

  font-family: Inter, var(--default-font-family);
  font-size: 18px;
  font-weight: 600;
  line-height: 14.523px;
  text-align: left;

  white-space: nowrap;
  z-index: 1;
  display: block;
  color: #ffffff;
  top: 0;
  left: 0;
  background: #0077b6;
  border-radius: 8px;
  box-shadow: 0 4px 4px 0 rgba(0, 0, 0, 0.25) inset;
  text-align: center;
}

.finish-btn {
  position: relative;
  width: 200px;
  height: 42px;
  margin: 0 auto;
  border-radius: 8px;

  font-family: Inter, var(--default-font-family);
  font-size: 18px;
  font-weight: 600;
  line-height: 14.523px;
  text-align: left;

  white-space: nowrap;
  z-index: 1;
  display: block;
  color: #ffffff;
  top: 0;
  left: 0;
  background: #b60003;
  border-radius: 8px;
  box-shadow: 0 4px 4px 0 rgba(0, 0, 0, 0.25) inset;
  text-align: center;
}
</style>
