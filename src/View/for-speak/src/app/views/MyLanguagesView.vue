<script setup lang="ts">
import { ref, onMounted } from 'vue'
import PageLayout from '../layouts/PageLayout.vue'
import LanguageCardMyLangs from '../components/LanguageCardMyLangs.vue'
import { getUserLanguages } from '../services/userService'

interface UserLanguage {
  languageId: number
  name: string
  description: string
  flagImage: string
  countryImage: string
  progress: number
  tasksCount: number
  isFinished: boolean
}

const userLanguages = ref<UserLanguage[]>([])
const loading = ref(true)
const error = ref<string | null>(null)

const fetchMyLangs = async () => {
  loading.value = true
  try {
    userLanguages.value = await getUserLanguages()
    error.value = null
  } catch (e: unknown) {
    error.value = e instanceof Error ? e.message : 'Помилка при завантаженні'
  } finally {
    loading.value = false
  }
}

onMounted(fetchMyLangs)
</script>

<template>
  <PageLayout>
    <div class="langs-page">
      <p v-if="loading">Завантаження...</p>
      <p v-else-if="error" class="error">{{ error }}</p>
      <template v-else>
        <LanguageCardMyLangs
          v-for="lang in userLanguages"
          :key="lang.languageId"
          v-bind="lang"
          :languageId="lang.languageId"
          :name="lang.name"
          :description="lang.description"
          :flagImage="lang.flagImage"
          :countryImage="lang.countryImage"
          :progress="lang.progress"
          :tasksCount="lang.tasksCount"
          :isFinished="lang.isFinished"
        />
      </template>
    </div>
  </PageLayout>
</template>

<style scoped>
.langs-page {
  margin-top: 100px;
  margin-bottom: 64px;
  display: flex;
  flex-direction: column;
  gap: 32px;
}
.error {
  color: red;
}
</style>
