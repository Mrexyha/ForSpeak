<script setup lang="ts">
import { ref } from 'vue'
import PageLayout from '../layouts/PageLayout.vue'
import ChartPoints from '../components/ChartPoints.vue'
import profileDefault from '../../assets/general/man-icon.png'

const profileImage = ref(profileDefault)

const studyTime = ref({
  english: 12,
  french: 8,
})

const recentActivities = ref([
  { id: 1, text: 'Пройдено тест з англійської – 85%' },
  { id: 2, text: 'Вивчено 10 нових слів у французькій' },
  { id: 3, text: '30 хвилин навчання сьогодні' },
])

const handleImageUpload = (event: Event) => {
  const file = (event.target as HTMLInputElement).files?.[0]
  if (file) {
    profileImage.value = URL.createObjectURL(file)
  }
}
</script>

<template>
  <PageLayout>
    <div class="profile-page">
      <div class="profile-header">
        <h1>Особиста інформація</h1>
        <div class="profile-header-content">
          <label for="file-upload" class="custom-file-upload">
            <input id="file-upload" type="file" @change="handleImageUpload" />
            <img :src="profileImage" alt="user photo" class="profile-image" />
          </label>
          <div class="profile-details">
            <h2>Json Smith</h2>
            <p class="email">testuseremail@gmail.com</p>
            <p>27 років, Україна</p>
            <p>Зареєстровано: <span class="date">10/04/2024</span></p>
            <p class="languages">Мови, що вивчаються: <span>англійська, французька.</span></p>
          </div>
        </div>
      </div>

      <div class="statistics">
        <h2>Статистика навчання</h2>
        <ChartPoints />
      </div>

      <div class="study-time">
        <h2>Час навчання</h2>
        <ul>
          <li>
            Англійська: <span class="time">{{ studyTime.english }} год.</span>
          </li>
          <li>
            Французька: <span class="time">{{ studyTime.french }} год.</span>
          </li>
        </ul>
      </div>

      <div class="recent-activities">
        <h2>Останні активності</h2>
        <ul>
          <li v-for="activity in recentActivities" :key="activity.id">
            {{ activity.text }}
          </li>
        </ul>
      </div>
    </div>
  </PageLayout>
</template>

<style scoped>
.profile-page {
  margin-top: 80px;
  padding: 20px;
  max-width: 900px;
  margin-left: auto;
  margin-right: auto;
  background: #ffffff;
  border-radius: 12px;
  box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.1);
}

.profile-header {
  text-align: center;
  padding-bottom: 20px;
  border-bottom: 2px solid #f0f0f0;
}

.profile-header h1 {
  font-size: 26px;
  margin-bottom: 10px;
  color: #333;
  font-weight: 600;
}

.profile-header-content {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 20px;
  margin-top: 20px;
}

.profile-image {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  object-fit: cover;
  border: 3px solid #007bff;
}

.custom-file-upload input[type='file'] {
  display: none;
}

.profile-details {
  text-align: left;
}

.profile-details h2 {
  font-size: 22px;
  margin-bottom: 5px;
  color: #222;
}

.profile-details p {
  margin: 5px 0;
  font-size: 16px;
  color: #555;
}

.email {
  font-weight: bold;
  color: #007bff;
}

.date {
  font-weight: bold;
  color: #28a745;
}

.languages span {
  font-weight: bold;
  color: #6c757d;
}

.study-time {
  margin-top: 30px;
  padding: 20px;
  background: #e3f2fd;
  border-radius: 10px;
  text-align: center;
}

.study-time h2 {
  font-size: 22px;
  color: #333;
  margin-bottom: 10px;
  font-weight: 600;
}

.study-time ul {
  list-style: none;
  padding: 0;
}

.study-time li {
  font-size: 18px;
  margin: 5px 0;
}

.time {
  font-weight: bold;
  color: #007bff;
}

.recent-activities {
  margin-top: 30px;
  padding: 20px;
  background: #f8f9fa;
  border-radius: 10px;
  text-align: center;
}

.recent-activities h2 {
  font-size: 22px;
  color: #333;
  margin-bottom: 10px;
  font-weight: 600;
}

.recent-activities ul {
  list-style: none;
  padding: 0;
}

.recent-activities li {
  font-size: 16px;
  margin: 5px 0;
  color: #555;
}
</style>
