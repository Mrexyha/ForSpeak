<script setup lang="ts">
import { reactive, defineEmits } from 'vue'

interface Form {
  email: string
  username: string
  password: string
  passwordHash: string
  confirmPassword: string
}

const form = reactive<Form>({
  email: '',
  username: '',
  password: '',
  passwordHash: '',
  confirmPassword: '',
})

const emit = defineEmits<{
  (e: 'next', payload: Form): void
}>()

function validatePassword(password: string): string | null {
  if (password.length < 8) {
    return 'Пароль має містити щонайменше 8 символів.'
  }
  if (!/\d/.test(password)) {
    return 'Пароль має містити хоча б одну цифру.'
  }
  if (!/[A-Z]/.test(password)) {
    return 'Пароль має містити хоча б одну велику літеру.'
  }
  return null
}

const nextStep = () => {
  if (!form.email || !form.username || !form.password || !form.confirmPassword) {
    alert('Заповніть всі поля!')
    return
  }

  const passwordError = validatePassword(form.password)
  if (passwordError) {
    alert(passwordError)
    return
  }

  if (form.password !== form.confirmPassword) {
    alert('Паролі не співпадають!')
    return
  }
  emit('next', { ...form })
}
</script>

<template>
  <div class="step-one">
    <input type="email" v-model="form.email" placeholder="Електронна пошта" required />
    <input type="text" v-model="form.username" placeholder="Користувацьке ім'я" required />
    <input
      type="password"
      v-model="form.password"
      placeholder="Пароль (мінімум 8 символів, велика літера, цифра)"
      required
    />
    <input
      type="password"
      v-model="form.confirmPassword"
      placeholder="Підтвердити пароль"
      required
    />
    <button @click="nextStep">Далі</button>
  </div>
</template>

<style scoped>
input {
  display: block;
  width: 100%;
  margin: 15px 0;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 8px;
  font-size: 1rem;
}

button {
  background-color: #ff6b6b;
  color: white;
  padding: 12px;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  width: 100%;
  font-size: 1.2rem;
}

button:hover {
  background-color: #ff4d4d;
}
</style>
