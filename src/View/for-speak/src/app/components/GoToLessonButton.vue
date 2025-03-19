<script setup lang="ts">
import { computed } from 'vue'
import { useRouter, useRoute } from 'vue-router'

const router = useRouter()
const route = useRoute()

const languageId = computed(() => route.params.languageId || 1)

const goToLesson = (id: number) => {
  router.push(`/education/${languageId.value}/${id}/`)
}
</script>

<template>
  <div class="btn-container">
    <button @click="goToLesson(1)" class="nav-button">⬅ Назад</button>
  </div>
</template>

<style scoped>
.btn-container {
  position: fixed;
  top: 100px;
  left: 60px;
}

.nav-button {
  background: linear-gradient(135deg, #3b82f6, #1e40af);
  color: white;
  border: none;
  padding: 12px 30px;
  font-size: 16px;
  font-weight: 600;
  border-radius: 12px;
  cursor: pointer;
  transition: all 0.3s ease;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 8px;
}

.nav-button:hover {
  background: linear-gradient(135deg, #1e40af, #3b82f6);
  transform: scale(1.05);
  box-shadow: 0 6px 14px rgba(0, 0, 0, 0.25);
}

.nav-button:active {
  transform: scale(0.98);
  box-shadow: 0 3px 6px rgba(0, 0, 0, 0.2);
}
</style>
