<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { getUserProfile } from '../services/userService'
import PageLayout from '../layouts/PageLayout.vue'
import ChartPoints from '../components/ChartPoints.vue'
import profileMan from '../../assets/general/man-icon.png'
import profileWoman from '../../assets/general/woman-icon.png'

const router = useRouter()
const profileImage = ref()
const isEditing = ref(false)
const isEditingPassword = ref(false)

const userInfo = ref({
  name: '',
  email: '',
  age: 0,
  country: '',
  registered: '',
  gender: '',
})

const studyTime = ref({
  english: 12,
  french: 8,
})

const recentActivities = ref([
  { id: 1, text: 'Пройдено тест з англійської – 85%' },
  { id: 2, text: 'Вивчено 10 нових слів у французькій' },
  { id: 3, text: '30 хвилин навчання сьогодні' },
])

const passwordData = ref({
  currentPassword: '',
  newPassword: '',
  confirmNewPassword: '',
})

const saveChanges = () => {
  isEditing.value = false
}

const saveNewPassword = () => {
  if (passwordData.value.newPassword !== passwordData.value.confirmNewPassword) {
    alert('Новий пароль і підтвердження не співпадають!')
    return
  }
  alert('Пароль успішно змінено!')
  passwordData.value = { currentPassword: '', newPassword: '', confirmNewPassword: '' }
  isEditingPassword.value = false
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
    router.push('/login')
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

      <div class="password-section">
        <h2>Зміна пароля</h2>
        <button v-if="!isEditingPassword" @click="isEditingPassword = true" class="edit-btn">
          Змінити пароль
        </button>
        <div v-if="isEditingPassword" class="password-form">
          <input
            v-model="passwordData.currentPassword"
            type="password"
            placeholder="Поточний пароль"
          />
          <input v-model="passwordData.newPassword" type="password" placeholder="Новий пароль" />
          <input
            v-model="passwordData.confirmNewPassword"
            type="password"
            placeholder="Підтвердження пароля"
          />
          <button @click="saveNewPassword" class="save-btn">Зберегти</button>
        </div>
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

.password-section {
  margin-top: 30px;
  padding: 20px;
  background: #f8f9fa;
  border-radius: 10px;
  text-align: center;
}

.password-form input {
  width: 100%;
  padding: 8px;
  margin: 5px 0;
  border-radius: 5px;
  border: 1px solid #ccc;
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
