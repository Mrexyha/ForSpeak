<script setup lang="ts">
import { ref, onMounted } from 'vue'
import axios from 'axios'
import { useRoute } from 'vue-router'

import PageLayout from '../../layouts/PageLayout.vue'
import GoToLessonButton from '@/app/components/GoToLessonButton.vue'
import TheoryTask from '@/app/components/Tasks/TheoryTask.vue'

interface TheoryModule {
  text: string
}

interface Lesson {
  id: number
  title: string
  theory: TheoryModule | null
}

const route = useRoute()
const lessonId = parseInt(route.params.id as string)
const languageId = route.params.languageId as string

const lesson = ref<Lesson>({
  id: lessonId,
  title: '',
  theory: { text: '' },
})

const fetchLessonTheory = async () => {
  const API_URL = `https://localhost:7058/api/languages/${languageId}/lessons/${lessonId}/theory`
  try {
    const response = await axios.get<TheoryModule>(API_URL)
    lesson.value.theory = response.data
  } catch (error) {
    console.error('Помилка отримання теоретичного матеріалу:', error)
    lesson.value.theory = { text: 'Теоретичний матеріал недоступний' }
  }
}

onMounted(fetchLessonTheory)
</script>

<template>
  <PageLayout>
    <GoToLessonButton />
    <h1>{{ lesson.title }}</h1>
    <TheoryTask :lesson="lesson" />
  </PageLayout>
</template>

<style scoped></style>
