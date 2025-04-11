<script setup lang="ts">
import { ref, onMounted } from 'vue'
import axios from 'axios'
import PageLayout from '../layouts/PageLayout.vue'
import LanguageCardMyLangs from '../components/LanguageCardMyLangs.vue'

interface UserLanguage {
  languageId: number
  name: string
  description: string
  flagImage: string
  countryImage: string
  progress: number
  tasksCount: number
}

const userLanguages = ref<UserLanguage[]>([])
const loading = ref(true)
const error = ref<string | null>(null)

onMounted(async () => {
  try {
    const token = localStorage.getItem('token')
    const userId = localStorage.getItem('userId')
    if (!token || !userId) throw new Error('Unauthorized')

    const { data } = await axios.get<UserLanguage[]>(`/api/user/${userId}/languages`, {
      headers: { Authorization: `Bearer ${token}` },
    })
    userLanguages.value = data
  } catch (e: unknown) {
    if (e instanceof Error) {
      error.value = e.message || 'Помилка при завантаженні'
    } else {
      error.value = 'Помилка при завантаженні'
    }
  } finally {
    loading.value = false
  }
})
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
          :languageId="lang.languageId"
          :name="lang.name"
          :description="lang.description"
          :flagImage="lang.flagImage"
          :countryImage="lang.countryImage"
          :progress="lang.progress"
          :tasksCount="lang.tasksCount"
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
