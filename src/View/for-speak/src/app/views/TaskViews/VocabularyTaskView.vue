<script setup lang="ts">
import PageLayout from '../../layouts/PageLayout.vue'
import VocabularyTask from '@/app/components/Tasks/VocabularyTask.vue'
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
    <VocabularyTask :lesson="lesson" />
  </PageLayout>
</template>

<style scoped></style>
