<script setup lang="ts">
import { ref, shallowRef } from 'vue'
import { useRouter } from 'vue-router'
import StepOne from './StepOne.vue'
import StepTwo from './StepTwo.vue'
import { loginUser, registerUser } from '../../services/authService'

const router = useRouter()

const step = ref(1)
const formData = ref({
  email: '',
  username: '',
  password: '',
  passwordHash: '',
  confirmPassword: '',
  gender: '',
  birthdate: Date.now(),
  country: '',
  selectedLanguageIds: [] as number[],
})

const steps = shallowRef([StepOne, StepTwo])

const nextStep = (data: {
  email: string
  username: string
  password: string
  passwordHash: string
  confirmPassword: string
}) => {
  formData.value = { ...formData.value, ...data }
  if (step.value < steps.value.length) step.value++
}

const previousStep = () => {
  if (step.value > 1) step.value--
}

const finalStep = (data: {
  gender: string
  birthdate: string
  country: string
  languageIds: number[]
}) => {
  console.log('languageIds:', formData.value.selectedLanguageIds)

  formData.value = {
    ...formData.value,
    gender: data.gender,
    birthdate: new Date(data.birthdate).getTime(),
    country: data.country,
    selectedLanguageIds: data.languageIds,
  }

  submitForm(formData.value)
}

const submitForm = async (data: {
  email: string
  username: string
  password: string
  confirmPassword: string
  gender: string
  birthdate: number
  country: string
  selectedLanguageIds: number[]
}) => {
  const updatedData = {
    email: data.email,
    username: data.username,
    password: data.password,
    confirmPassword: data.confirmPassword,
    gender: data.gender,
    birthdate: new Date(data.birthdate),
    country: data.country,
    selectedLanguageIds: data.selectedLanguageIds,
  }

  console.log('email ', updatedData.email)
  console.log('updatedData ', updatedData)

  try {
    const response = await registerUser(updatedData)
    console.log('Response:', response)

    const loginResponse = await loginUser({
      email: updatedData.email,
      password: updatedData.password,
    })
    localStorage.setItem('token', loginResponse.token)

    router.push('/')
  } catch (error) {
    console.log(error)
  }
}
</script>

<template>
  <div class="registration-container">
    <div class="form-box">
      <h2>Реєстрація</h2>
      <component
        :is="steps[step - 1]"
        @next="nextStep"
        @previous="previousStep"
        @submit="finalStep"
      />
      <p class="switch-form" @click="router.push('/login')">Уже є акаунт? <span>Увійти</span></p>
    </div>
  </div>
</template>

<style scoped>
.registration-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background: linear-gradient(135deg, #89f7fe, #66a6ff);
}

.form-box {
  background: white;
  padding: 40px;
  border-radius: 15px;
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.2);
  text-align: center;
  max-width: 680px;
  width: 100%;
}

.switch-form {
  margin-top: 15px;
  font-size: 14px;
  color: #555;
  cursor: pointer;
}

.switch-form span {
  color: #007bff;
  text-decoration: underline;
}
</style>
