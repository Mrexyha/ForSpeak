<script setup lang="ts">
import { ref } from 'vue'
import PageLayout from '../layouts/PageLayout.vue'
import ChartPoints from '../components/ChartPoints.vue'
import profileDefault from '../../assets/general/man-icon.png'

const profileImage = ref(profileDefault)

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
          <!-- <img src="../../assets/general/man-icon.png" alt="man photo" class="profile-image" /> -->
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

.statistics {
  margin-top: 30px;
  text-align: center;
  padding: 20px;
  background: #f8f9fa;
  border-radius: 10px;
}

.statistics h2 {
  font-size: 22px;
  color: #333;
  margin-bottom: 15px;
  font-weight: 600;
}
</style>
