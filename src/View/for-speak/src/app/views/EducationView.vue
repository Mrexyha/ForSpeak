<script setup lang="ts">
import { ref, computed, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { fetchLessons } from '../services/lessonsService'

import PageLayout from '../layouts/PageLayout.vue'
import LessonCard from '../components/LessonCard.vue'

interface Lesson {
  id: number
  title: string
  difficulty: string
  //date: string
}

const route = useRoute()
const router = useRouter()
const lessons = ref<Lesson[]>([])
const searchQuery = ref('')
const selectedDifficulty = ref('all')
const selectedSort = ref('newest')

// const lessons = ref([
//   { id: 1, title: "Сім'я / Family", difficulty: 'Elementary', date: '2024-03-01' },
//   { id: 2, title: 'Друзі / Friends', difficulty: 'Intermediate', date: '2024-02-25' },
//   { id: 3, title: 'Робота / Work', difficulty: 'Advanced', date: '2024-02-20' },
//   { id: 4, title: 'Подорожі / Travel', difficulty: 'Elementary', date: '2024-03-05' },
//   { id: 5, title: 'Спорт / Sports', difficulty: 'Intermediate', date: '2024-02-28' },
// ])

const languageId = computed(() => {
  const id = route.params.languageId
  return Array.isArray(id) ? id[0] : id || 1
})

watch(
  languageId,
  async (newLanguageId) => {
    lessons.value = await fetchLessons(newLanguageId)
  },
  { immediate: true },
)

const filteredLessons = computed(() => {
  if (!Array.isArray(lessons.value)) return []

  return lessons.value.filter((lesson) => {
    const matchesSearch = lesson.title.toLowerCase().includes(searchQuery.value.toLowerCase())

    const matchesDifficulty =
      selectedDifficulty.value === 'all' ||
      lesson.difficulty.toLowerCase() === selectedDifficulty.value

    return matchesSearch && matchesDifficulty
  })
  // .sort((a, b) => {
  //   return selectedSort.value === 'newest'
  //     ? new Date(b.date).getTime() - new Date(a.date).getTime()
  //     : new Date(a.date).getTime() - new Date(b.date).getTime()
  // })
})

const goToMyLanguages = () => {
  router.push(`/education/${languageId.value}/some-id`)
}
</script>

<template>
  <PageLayout>
    <div class="education-page">
      <div class="header-container">
        <h1 class="lang-title">Англійська мова</h1>

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

      <div class="cards-container">
        <LessonCard
          @click="goToMyLanguages"
          v-for="lesson in filteredLessons"
          :key="lesson.id"
          :title="lesson.title"
          :difficulty="lesson.difficulty"
        />
      </div>

      <p v-if="filteredLessons.length === 0" class="no-results">Нічого не знайдено 😕</p>
    </div>
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
</style>
