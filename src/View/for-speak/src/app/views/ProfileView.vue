<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { getUserProfile } from '../services/userService'
import PageLayout from '../layouts/PageLayout.vue'
import ChartPoints from '../components/ChartPoints.vue'
import profileMan from '../../../public/assets/general/man-icon.png'
import profileWoman from '../../../public/assets/general/woman-icon.png'
import { useAuthStore } from '../stores/auth'

const router = useRouter()
const auth = useAuthStore()
const profileImage = ref()
const isEditing = ref(false)

const userInfo = ref({
  name: '',
  email: '',
  age: 0,
  country: '',
  registered: '',
  gender: '',
})

const saveChanges = () => {
  isEditing.value = false
}

const fetchUserProfile = async () => {
  try {
    const data = await getUserProfile()

    userInfo.value = {
      ...data,
      name: data.username,
      registered: data.registeredDate,
    }

    if (data.gender === 'male') {
      profileImage.value = profileMan
    } else if (data.gender === 'female') {
      profileImage.value = profileWoman
    }
  } catch (error) {
    console.error(error)

    localStorage.removeItem('token')
    localStorage.removeItem('user')
    localStorage.removeItem('userId')

    router.push({ name: 'login', query: { redirect: '/profile' } })
  }
}

const handleImageUpload = (event: Event) => {
  const file = (event.target as HTMLInputElement).files?.[0]
  if (file) {
    profileImage.value = URL.createObjectURL(file)
  }
}

onMounted(() => {
  fetchUserProfile()
})

const logout = () => {
  localStorage.removeItem('token')
  localStorage.removeItem('user')
  localStorage.removeItem('userId')
  auth.clearUser()

  alert('Ви вийшли з профілю!')
  router.push('/')
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
            <template v-if="isEditing">
              <input v-model="userInfo.name" type="text" class="edit-input" />
              <input v-model="userInfo.age" type="number" class="edit-input" />
              <input v-model="userInfo.country" type="text" class="edit-input" />
              <p class="email">{{ userInfo.email }}</p>
              <p>
                Зареєстровано: <span class="date">{{ userInfo.registered }}</span>
              </p>
              <button @click="saveChanges" class="save-btn">Зберегти</button>
            </template>
            <template v-else>
              <h2>{{ userInfo.name }}</h2>
              <p class="email">{{ userInfo.email }}</p>
              <p>{{ userInfo.age }} років, {{ userInfo.country }}</p>
              <p>
                Зареєстровано: <span class="date">{{ userInfo.registered }}</span>
              </p>
              <button @click="isEditing = true" class="edit-btn">Редагувати</button>
            </template>
          </div>
        </div>
      </div>

      <div class="statistics">
        <h2>Статистика навчання</h2>
        <ChartPoints />
      </div>

      <button @click="logout" class="logout-btn">Вийти з профілю</button>
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

.time {
  font-weight: bold;
  color: #007bff;
}

.edit-input {
  width: 100%;
  padding: 8px;
  margin: 5px 0;
  border-radius: 5px;
  border: 1px solid #ccc;
}

.edit-btn,
.save-btn {
  background: #007bff;
  color: white;
  padding: 8px 12px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-top: 10px;
}

.save-btn {
  background: #28a745;
}

.logout-btn {
  display: block;
  width: 100%;
  max-width: 200px;
  margin: 20px auto;
  padding: 10px 15px;
  font-size: 16px;
  text-align: center;
  background-color: #dc3545;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: 0.3s;
}

.logout-btn:hover {
  background-color: #c82333;
}
</style>
