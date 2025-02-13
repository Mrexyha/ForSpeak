<script setup lang="ts">
import { reactive, defineEmits } from 'vue'

const form = reactive({
  email: '',
  password: '',
  confirmPassword: '',
})

const emit = defineEmits(['next'])

const nextStep = () => {
  if (form.password !== form.confirmPassword) {
    alert('Паролі не співпадають!')
    return
  }
  emit('next', form)
}
</script>

<template>
  <div class="step-one">
    <input type="email" v-model="form.email" placeholder="Електронна пошта" required />
    <input type="password" v-model="form.password" placeholder="Пароль" required />
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
