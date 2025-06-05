<script setup lang="ts">
import { ref, onMounted, computed } from 'vue'
import { useRouter } from 'vue-router'
import { getUserProfile } from '@/app/services/userService'
import { getLanguagePercent, getOverallPercent } from '@/app/services/progressService'
import { useAuthStore } from '@/app/stores/auth'
import PageLayout from '@/app/layouts/PageLayout.vue'
import ChartPoints from '@/app/components/ChartPoints.vue'
import profileMan from '../../../public/assets/general/man-icon.png'
import profileWoman from '../../../public/assets/general/woman-icon.png'

const router = useRouter()
const auth = useAuthStore()
auth.initFromLocalStorage()

const profileImage = ref<string>()
const isEditing = ref(false)

const userInfo = ref({
  name: '',
  email: '',
  age: 0,
  country: '',
  registered: '',
  gender: '',
})

const languageId = ref<number | null>(null)
const languagePercent = ref<number>(0)

const overallPercent = ref<number>(0)

const formattedDate = computed(() => {
  if (!userInfo.value.registered) return ''
  const d = new Date(userInfo.value.registered)
  const day = String(d.getDate()).padStart(2, '0')
  const month = String(d.getMonth() + 1).padStart(2, '0')
  const year = d.getFullYear()
  return `${day}.${month}.${year}`
})

const fetchData = async () => {
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

    languageId.value = data.selectedLanguageId ?? null

    if (languageId.value !== null) {
      languagePercent.value = await getLanguagePercent(languageId.value)
    }

    overallPercent.value = await getOverallPercent()
  } catch (error) {
    console.error(error)
    localStorage.removeItem('token')
    localStorage.removeItem('user')
    localStorage.removeItem('userId')
    auth.clearUser()
    router.push({ name: 'login', query: { redirect: '/profile' } })
  }
}

const saveChanges = () => {
  isEditing.value = false
}

const handleImageUpload = (event: Event) => {
  const file = (event.target as HTMLInputElement).files?.[0]
  if (file) {
    profileImage.value = URL.createObjectURL(file)
  }
}

const logout = () => {
  localStorage.removeItem('token')
  localStorage.removeItem('user')
  localStorage.removeItem('userId')
  auth.clearUser()
  alert('Ви вийшли з профілю!')
  router.push('/')
}

onMounted(fetchData)
</script>

<template>
  <PageLayout>
    <div class="profile-page">
      <div class="profile-card">
        <div class="profile-card__left">
          <label for="file-upload" class="file-upload-wrapper">
            <input id="file-upload" type="file" @change="handleImageUpload" />
            <img :src="profileImage" alt="user photo" class="profile-card__avatar" />
          </label>
        </div>
        <div class="profile-card__right">
          <h1 class="profile-card__title">Особиста інформація</h1>

          <div v-if="isEditing" class="profile-card__form">
            <div class="input-group">
              <label>Ім'я</label>
              <input v-model="userInfo.name" type="text" />
            </div>
            <div class="input-group">
              <label>Вік</label>
              <input v-model="userInfo.age" type="number" />
            </div>
            <div class="input-group">
              <label>Країна</label>
              <input v-model="userInfo.country" type="text" />
            </div>
            <div class="input-group">
              <label>Електронна пошта</label>
              <p class="static-text">{{ userInfo.email }}</p>
            </div>
            <div class="input-group">
              <label>Зареєстровано</label>
              <p class="static-text">{{ formattedDate }}</p>
            </div>
            <button @click="saveChanges" class="btn-save">Зберегти</button>
          </div>

          <div v-else class="profile-card__info">
            <h2 class="name">{{ userInfo.name }}</h2>
            <p class="detail">{{ userInfo.country }}</p>
            <p class="detail"><strong>Email:</strong> {{ userInfo.email }}</p>
          </div>
        </div>
      </div>

      <div class="stats-card">
        <h2 class="stats-card__title">Статистика навчання</h2>
        <ChartPoints :languagePercent="languagePercent" :overallPercent="overallPercent" />
      </div>

      <button @click="logout" class="btn-logout">Вийти з профілю</button>
    </div>
  </PageLayout>
</template>

<style scoped>
.profile-page {
  margin-top: 60px;
  padding: 0 20px 40px;
  max-width: 900px;
  margin-left: auto;
  margin-right: auto;
}

.profile-card {
  display: flex;
  flex-wrap: wrap;
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 12px rgba(0, 0, 0, 0.1);
  overflow: hidden;
  margin-bottom: 30px;
}

.profile-card__left {
  flex: 0 0 160px;
  background: #f7f9fc;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 20px;
}

.file-upload-wrapper {
  position: relative;
  cursor: pointer;
}

.file-upload-wrapper input[type='file'] {
  display: none;
}

.profile-card__avatar {
  width: 120px;
  height: 120px;
  border-radius: 50%;
  object-fit: cover;
  border: 3px solid #007bff;
}

.profile-card__right {
  flex: 1;
  padding: 20px 25px;
}

.profile-card__title {
  font-size: 24px;
  margin-bottom: 15px;
  color: #333;
  font-weight: 600;
}

.profile-card__info .name {
  font-size: 20px;
  color: #222;
  margin-bottom: 8px;
}

.profile-card__info .detail {
  font-size: 16px;
  color: #555;
  margin: 6px 0;
}

.profile-card__info .btn-edit {
  margin-top: 15px;
  background: #007bff;
  color: #fff;
  padding: 8px 14px;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  transition: background 0.3s;
}

.profile-card__info .btn-edit:hover {
  background: #0056b3;
}

.profile-card__form .input-group {
  margin-bottom: 12px;
  display: flex;
  flex-direction: column;
}

.profile-card__form .input-group label {
  font-size: 14px;
  color: #555;
  margin-bottom: 4px;
}

.profile-card__form .input-group input {
  padding: 8px 10px;
  border: 1px solid #ccc;
  border-radius: 6px;
  font-size: 15px;
  transition: border-color 0.2s;
}

.profile-card__form .input-group input:focus {
  border-color: #007bff;
  outline: none;
}

.profile-card__form .static-text {
  font-size: 15px;
  color: #333;
  padding: 8px 0;
}

.profile-card__form .btn-save {
  margin-top: 10px;
  background: #28a745;
  color: #fff;
  padding: 10px 16px;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  transition: background 0.3s;
}

.profile-card__form .btn-save:hover {
  background: #1e7e34;
}

.stats-card {
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 12px rgba(0, 0, 0, 0.1);
  padding: 20px 25px;
  margin-bottom: 30px;
}

.stats-card__title {
  font-size: 22px;
  margin-bottom: 15px;
  color: #333;
  font-weight: 500;
}

.btn-logout {
  display: block;
  width: 100%;
  max-width: 240px;
  margin: 0 auto;
  padding: 12px 0;
  font-size: 16px;
  text-align: center;
  background-color: #dc3545;
  color: #fff;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  transition: background 0.3s;
}

.btn-logout:hover {
  background-color: #c82333;
}
</style>
