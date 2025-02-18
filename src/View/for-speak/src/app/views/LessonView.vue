<script setup lang="ts">
import { ref } from 'vue'
import { useRoute } from 'vue-router'
import PageLayout from '../layouts/PageLayout.vue'

interface Lesson {
  id: number
  title: string
  description: string
}

const route = useRoute()
const lessonId = route.params.id as string

const lessons = [
  {
    id: 1,
    title: 'Вивчення Vue.js',
    description: 'Основи фреймворку Vue.js для розробки інтерфейсів.',
  },
]

const lesson = ref<Lesson>(lessons.find((l) => l.id === parseInt(lessonId)) || lessons[0])
</script>

<template>
  <PageLayout>
    <div class="lesson-page">
      <h1>{{ lesson?.title || '❌ Урок не знайдено' }}</h1>
      <p class="description">{{ lesson?.description || 'Опис відсутній' }}</p>

      <div v-if="lesson" class="task-buttons">
        <router-link :to="`/education/english/${lesson.id}/theory`">
          <button class="task-button">📖 Теорія</button>
        </router-link>
        <router-link :to="`/education/english/${lesson.id}/quiz`">
          <button class="task-button">📝 Квіз</button>
        </router-link>
        <router-link :to="`/education/english/${lesson.id}/reading`">
          <button class="task-button">📚 Читання</button>
        </router-link>
        <router-link :to="`/education/english/${lesson.id}/speaking`">
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

.description {
  font-size: 18px;
  color: #555;
  margin-bottom: 20px;
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
