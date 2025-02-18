<script setup lang="ts">
import PageLayout from '../../layouts/PageLayout.vue'
import TheoryTask from '@/app/components/Tasks/TheoryTask.vue'
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
    <TheoryTask :lesson="lesson" />
  </PageLayout>
</template>

<style scoped></style>
