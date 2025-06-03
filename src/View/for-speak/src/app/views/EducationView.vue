<script setup lang="ts">
import { ref, computed, watch, onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { fetchLessons } from '../services/lessonsService'
import { useLanguagesStore } from '../stores/languages'
import PageLayout from '../layouts/PageLayout.vue'
import LessonCard from '../components/LessonCard.vue'
import { fetchLanguages, type Language } from '../services/languageService'

interface Lesson {
  id: number
  title: string
  difficulty: string
}

const route = useRoute()
const router = useRouter()
const langsStore = useLanguagesStore()

const languages = ref<Language[]>([])
const isLoadingLanguages = ref(true)
onMounted(async () => {
  try {
    languages.value = await fetchLanguages()
  } catch {
    console.error('Помилка при завантаженні мов')
  } finally {
    isLoadingLanguages.value = false
  }
})

const languageId = computed<number>(() => {
  const p = route.params.languageId
  return p ? +(Array.isArray(p) ? p[0] : p) : 0
})
const currentLanguage = computed(() => languages.value.find((l) => l.id === languageId.value))

const lessons = ref<Lesson[]>([])
const searchQuery = ref('')
const selectedDifficulty = ref('all')
const selectedSort = ref('newest')

watch(
  languageId,
  async (newId) => {
    if (newId) {
      lessons.value = await fetchLessons(newId)
      langsStore.setSelectedLanguage(newId)
    }
  },
  { immediate: true },
)

watch(
  () => langsStore.selectedLanguageId,
  (newId) => {
    if (newId !== null && newId !== languageId.value) {
      router.push(`/education/${newId}`)
    }
  },
)

const filteredLessons = computed(
  () =>
    lessons.value.filter((lesson) => {
      const mSearch = lesson.title.toLowerCase().includes(searchQuery.value.toLowerCase())
      const mDiff =
        selectedDifficulty.value === 'all' ||
        lesson.difficulty.toLowerCase() === selectedDifficulty.value
      return mSearch && mDiff
    }),
  // .sort((a, b) => {
  //   return selectedSort.value === 'newest'
  //     ? new Date(b.date).getTime() - new Date(a.date).getTime()
  //     : new Date(a.date).getTime() - new Date(b.date).getTime()
  // })
)

const goToLesson = (lessonId: number) => {
  router.push(`/education/${languageId.value}/${lessonId}`)
}

const isAllFinished = computed(
  () => langsStore.list.length > 0 && langsStore.list.every((l) => l.isFinished),
)

const isCurrentLanguageFinished = computed(() => {
  const lang = langsStore.list.find((l) => l.id === languageId.value)
  return lang?.isFinished ?? false
})
</script>

<template>
  <PageLayout>
    <div v-if="isAllFinished" class="all-done">
      <p>Ви завершили всі мови. Можете відновити їх у вкладці "Мої мови".</p>
    </div>

    <div v-else-if="currentLanguage && isCurrentLanguageFinished">
      <p>Навчання з {{ currentLanguage.name }} завершено.</p>
      <p>Щоб повернутися до уроків, натисніть “Відновити” у вкладці "Мої мови".</p>
    </div>

    <template v-else
      ><div class="education-page">
        <div class="header-container">
          <template v-if="!isLoadingLanguages && currentLanguage">
            <div class="lang-header">
              <h1 class="lang-title">{{ currentLanguage.name }}</h1>
            </div>
          </template>
          <template v-else>
            <h1 class="lang-title">Завантаження мови…</h1>
          </template>

          <div class="search-filter-container">
            <div class="search-container">
              <input
                type="text"
                class="search-input"
                placeholder="Уведіть тему..."
                v-model="searchQuery"
              />
              <span class="search-icon">🔍</span>
            </div>

            <div class="filter-container">
              <select class="filter-select" v-model="selectedDifficulty">
                <option value="all">Всі рівні</option>
                <option value="elementary">Легкий</option>
                <option value="intermediate">Середній</option>
                <option value="advanced">Важкий</option>
              </select>

              <select class="filter-select" v-model="selectedSort">
                <option value="newest">Найновіші</option>
                <option value="oldest">Найстаріші</option>
              </select>
            </div>
          </div>
        </div>

        <div
          class="cards-container"
          v-for="lesson in filteredLessons"
          :key="lesson.id"
          @click="goToLesson(lesson.id)"
        >
          <LessonCard :id="lesson.id" :title="lesson.title" :difficulty="lesson.difficulty" />
        </div>

        <p v-if="filteredLessons.length === 0" class="no-results">Нічого не знайдено 😕</p>
      </div></template
    >
  </PageLayout>
</template>

<style scoped>
.education-page {
  margin-top: 100px;
}

.header-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-left: 200px;
  margin-right: 200px;
}

.lang-title {
  color: #023e8a;
  font-family: Inter, sans-serif;
  font-size: 36px;
  font-weight: 600;
  line-height: 1.2;
}

.search-filter-container {
  display: flex;
  align-items: center;
  gap: 20px;
}

.search-container {
  display: flex;
  align-items: center;
  position: relative;
  width: 400px;
}

.search-input {
  width: 100%;
  padding: 10px 40px 10px 15px;
  font-size: 14px;
  border: 2px solid #0077b6;
  border-radius: 12px;
  background: #caf0f8;
  box-shadow: 2px 4px 6px rgba(0, 119, 182, 0.3);
  outline: none;
  color: #03045e;
  font-weight: 500;
}

.search-icon {
  position: absolute;
  right: 10px;
  font-size: 18px;
  color: #0077b6;
}

.filter-container {
  display: flex;
  gap: 10px;
}

.filter-select {
  padding: 8px 12px;
  font-size: 14px;
  border: 2px solid #0077b6;
  border-radius: 8px;
  background: #90e0ef;
  cursor: pointer;
  color: #03045e;
  font-weight: 500;
  transition:
    background 0.3s ease,
    border-color 0.3s ease;
}

.filter-select:hover {
  background: #48cae4;
  border-color: #023e8a;
}

.cards-container {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  justify-items: center;
  align-items: center;
  gap: 50px;
  width: 500px;
  margin-left: 15%;
  margin-bottom: 64px;
}

.no-results {
  text-align: center;
  font-size: 18px;
  color: #6c757d;
  margin-top: 20px;
}

.lang-header {
  display: flex;
  align-items: center;
  gap: 16px;
}
</style>
