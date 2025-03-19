<script setup lang="ts">
import PageLayout from '../../layouts/PageLayout.vue'
import QuizTask from '@/app/components/Tasks/QuizTask.vue'
import GoToLessonButton from '@/app/components/GoToLessonButton.vue'
import { defineProps } from 'vue'

interface Lesson {
  id: number
  title: string
  description: string
  theory: string
}

defineProps<{ lesson: Lesson }>()
</script>

<template>
  <PageLayout>
    <GoToLessonButton />
    <QuizTask :lesson="lesson" />
  </PageLayout>
</template>

<style scoped></style>
