<script setup lang="ts">
import { ref, computed, watch } from 'vue'
import { useRoute } from 'vue-router'
import PageLayout from '../layouts/PageLayout.vue'
import { fetchLessons } from '../services/lessonsService'

interface Lesson {
  id: number
  title: string
  difficulty: string
}

const route = useRoute()
const languageId = computed(() => {
  const id = route.params.languageId
  if (Array.isArray(id)) return id[0] || 1
  return id || 1
})
const lessons = ref<Lesson[]>([])
const lessonId = route.params.id as string

watch(
  languageId,
  async (newLanguageId) => {
    const id = typeof newLanguageId === 'string' ? parseInt(newLanguageId) : Number(newLanguageId)
    lessons.value = await fetchLessons(id)
  },
  { immediate: true },
)

const lesson = computed(() => {
  return lessons.value.find((l) => l.id === parseInt(lessonId)) || null
})
</script>

<template>
  <PageLayout>
    <div class="lesson-page">
      <h1>{{ lesson?.title || '❌ Урок не знайдено' }}</h1>
      <div v-if="lesson" class="task-buttons">
        <router-link :to="`/education/${languageId}/${lesson.id}/theory`">
          <button class="task-button">📖 Теорія</button>
        </router-link>
        <router-link :to="`/education/${languageId}/${lesson.id}/vocabulary`">
          <button class="task-button">📔 Словник</button>
        </router-link>
        <router-link :to="`/education/${languageId}/${lesson.id}/quiz`">
          <button class="task-button">📝 Тестування</button>
        </router-link>
        <router-link :to="`/education/${languageId}/${lesson.id}/reading`">
          <button class="task-button">📚 Читання</button>
        </router-link>
        <router-link :to="`/education/${languageId}/${lesson.id}/speaking`">
          <button class="task-button">🎤 Говоріння</button>
        </router-link>
      </div>

      <router-view v-if="lesson" :lesson="lesson" />
      <p v-else class="error-message">❌ Матеріал відсутній</p>
    </div>
  </PageLayout>
</template>

<style scoped>
body {
  background: linear-gradient(to bottom, #e3f2fd, #bbdefb);
}

.lesson-page {
  max-width: 500px;
  margin: 100px auto;
  padding: 30px;
  background: #ffffff;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
  border-radius: 12px;
  text-align: center;
  transition: all 0.3s ease-in-out;
}

h1 {
  font-size: 26px;
  color: #1e3a8a;
  margin-bottom: 10px;
}

.task-buttons {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 10px;
  margin-top: 20px;
  margin-bottom: 24px;
}

.task-button {
  width: 250px;
  background: linear-gradient(135deg, #4a90e2, #1e3a8a);
  color: #fff;
  border: none;
  padding: 20px;
  font-size: 20px;
  font-weight: bold;
  border-radius: 8px;
  cursor: pointer;
  transition: all 0.3s ease-in-out;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

.task-button:hover {
  background: linear-gradient(135deg, #1e3a8a, #4a90e2);
  transform: translateY(-2px);
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.25);
}

.task-button:active {
  transform: translateY(2px);
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
}

.error-message {
  color: red;
  font-weight: bold;
  margin-top: 20px;
}

@media (max-width: 600px) {
  .lesson-page {
    width: 90%;
    padding: 20px;
  }

  .task-button {
    width: 80%;
  }
}
</style>
