<script setup lang="ts">
import PageLayout from '../layouts/PageLayout.vue'
import LessonCard from '../components/LessonCard.vue'
</script>

<template>
  <PageLayout>
    <div class="education-page">
      <div class="header-container">
        <h1 class="lang-title">Англійська мова</h1>

        <div class="search-filter-container">
          <div class="search-container">
            <input type="text" class="search-input" placeholder="Уведіть тему..." />
            <span class="search-icon">🔍</span>
          </div>

          <div class="filter-container">
            <select class="filter-select">
              <option value="all">Всі рівні</option>
              <option value="easy">Легкий</option>
              <option value="medium">Середній</option>
              <option value="hard">Важкий</option>
            </select>
            <select class="filter-select">
              <option value="newest">Найновіші</option>
              <option value="oldest">Найстаріші</option>
            </select>
          </div>
        </div>
      </div>

      <div class="cards-container">
        <LessonCard />
        <LessonCard />
        <LessonCard />
        <LessonCard />
        <LessonCard />
      </div>
    </div>
  </PageLayout>
</template>

<style>
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
</style>
