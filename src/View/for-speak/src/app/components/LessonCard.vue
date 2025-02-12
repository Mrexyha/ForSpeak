<script setup lang="ts">
defineProps({
  title: String,
  difficulty: String,
})
</script>

<template>
  <div class="main-lesson-container">
    <div class="points">+5</div>
    <div class="card">
      <h1 class="main-lesson-title">{{ title }}</h1>
      <img src="../../assets/lessons/family.png" alt="family photo" class="main-lesson-photo" />
      <div class="difficulty">
        <div class="difficulty-color"></div>
        <div class="difficulty-label">{{ difficulty }}</div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.main-lesson-container {
  position: relative;
  width: 520px;
  margin: 10px;
}

.main-lesson-container:hover {
  transform: scale(1.05);
}

.points {
  position: relative;
  top: 24px;
  margin-left: -12px;
  padding: 20px;
  left: 0px;
  width: 32px;
  height: 32px;
  background-color: #023e8a;
  color: #ffffff;
  border-radius: 50%;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 16px;
  font-weight: bold;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
  z-index: 1;
}

.card {
  position: relative;
  width: 100%;
  height: 380px;
  background: #ade8f4;
  border-radius: 16px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
  overflow: hidden;
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  transition: all 0.3s ease-in-out;
}
.main-lesson-title {
  color: #023e8a;
  font-family: Inter, sans-serif;
  font-size: 24px;
  font-weight: 600;
  text-align: center;
  margin: 0;
}

.main-lesson-photo {
  width: 80%;
  height: auto;
  margin: 10px auto;
  border-radius: 8px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.2);
}

.difficulty {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
}

.difficulty-color {
  background-color: #4ed536;
  width: 24px;
  height: 24px;
  border-radius: 50%;
}

.difficulty-label {
  font-size: 14px;
  color: #023e8a;
  font-weight: 500;
}
</style>
