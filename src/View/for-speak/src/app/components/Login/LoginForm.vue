<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()
const formData = ref({
  email: '',
  password: '',
})

const submitLogin = () => {
  console.log('Logging in with:', formData.value)
}
</script>

<template>
  <div class="login-container">
    <div class="form-box">
      <h2>Вхід</h2>
      <form @submit.prevent="submitLogin">
        <input type="email" v-model="formData.email" placeholder="Електронна пошта" required />
        <input type="password" v-model="formData.password" placeholder="Пароль" required />
        <button type="submit">Увійти</button>
      </form>
      <p class="switch-form" @click="router.push('/register')">
        Ще не маєте акаунту? <span>Зареєструватися</span>
      </p>
    </div>
  </div>
</template>

<style scoped>
.login-container {
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
  max-width: 600px;
  width: 100%;
}

input {
  width: 100%;
  padding: 10px;
  margin: 10px 0;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 1rem;
}

button {
  width: 100%;
  padding: 10px;
  margin-top: 10px;
  background-color: #ff6b6b;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 1.2rem;
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
