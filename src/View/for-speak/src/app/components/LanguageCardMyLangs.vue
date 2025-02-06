<script setup lang="ts">
import ContinueBtn from './ContinueBtn.vue'
import FinishBtn from './FinishBtn.vue'
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
      <ContinueBtn class="btn" />
      <FinishBtn class="btn" />
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

.btn {
  margin: 20px;
}
</style>
