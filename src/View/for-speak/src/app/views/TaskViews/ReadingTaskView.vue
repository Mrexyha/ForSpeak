<script setup lang="ts">
import PageLayout from '../../layouts/PageLayout.vue'
import ReadingTask from '@/app/components/Tasks/ReadingTask.vue'
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
    <ReadingTask :lesson="lesson" />
  </PageLayout>
</template>

<style scoped></style>
