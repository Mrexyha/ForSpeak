<script setup lang="ts">
import PageLayout from '../../layouts/PageLayout.vue'
import SpeakingTask from '@/app/components/Tasks/SpeakingTask.vue'
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
    <SpeakingTask />
  </PageLayout>
</template>

<style scoped></style>
