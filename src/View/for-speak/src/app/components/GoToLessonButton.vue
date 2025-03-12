<script setup lang="ts">
import { useRouter } from 'vue-router'

const router = useRouter()

const goToLesson = (id: number) => {
  router.push(`/education/english/${id}/`)
}
</script>

<template>
  <div class="btn-container">
    <button @click="goToLesson(1)" class="nav-button">Назад 📚</button>
  </div>
</template>

<style scoped>
.btn-container {
  position: absolute;
  margin-top: 100px;
  margin-left: 20px;
}

.nav-button {
  background: linear-gradient(135deg, #4a90e2, #1e3a8a);
  color: white;
  border: none;
  padding: 15px 25px;
  font-size: 18px;
  font-weight: bold;
  border-radius: 8px;
  cursor: pointer;
  transition: all 0.3s ease-in-out;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

.nav-button:hover {
  background: linear-gradient(135deg, #1e3a8a, #4a90e2);
  transform: translateY(-2px);
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.25);
}

.nav-button:active {
  transform: translateY(2px);
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
}
</style>
