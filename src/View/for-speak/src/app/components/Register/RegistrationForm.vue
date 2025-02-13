<script setup lang="ts">
import { ref, shallowRef } from 'vue'
import StepOne from './StepOne.vue'
import StepTwo from './StepTwo.vue'

const step = ref(1)
const formData = ref({
  email: '',
  password: '',
  confirmPassword: '',
  gender: '',
  birthdate: '',
  country: '',
  language: [] as string[],
})

const steps = shallowRef([StepOne, StepTwo])

const nextStep = (data: { email: string; password: string; confirmPassword: string }) => {
  formData.value = { ...formData.value, ...data }
  if (step.value < steps.value.length) step.value++
}

const previousStep = () => {
  if (step.value > 1) step.value--
}

const submitForm = (data: {
  gender: string
  birthdate: string
  country: string
  language: string[]
}) => {
  formData.value = { ...formData.value, ...data }
  console.log('Submitted form:', formData.value)
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
        @submit="submitForm"
      />
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
  max-width: 600px;
  width: 100%;
}
</style>
