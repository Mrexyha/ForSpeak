<script setup lang="ts">
import { reactive, defineEmits } from 'vue'

const form = reactive({
  gender: '',
  birthdate: '',
  country: '',
  language: [] as string[],
})

const countries = ['Україна', 'США', 'Німеччина', 'Франція', 'Велика Британія']
const languages = ['Англійська', 'Французька', 'Німецька']

const emit = defineEmits(['previous', 'submit'])

const submitForm = () => {
  emit('submit', form)
}

const toggleLanguageSelection = (language: string) => {
  const index = form.language.indexOf(language)
  if (index === -1) {
    form.language.push(language)
  } else {
    form.language.splice(index, 1)
  }
}
</script>

<template>
  <div class="step-two">
    <select v-model="form.gender">
      <option value="" disabled>Стать</option>
      <option value="male">Чоловіча</option>
      <option value="female">Жіноча</option>
    </select>

    <input type="date" v-model="form.birthdate" placeholder="Дата народження" required />

    <select v-model="form.country">
      <option value="" disabled>Країна</option>
      <option v-for="country in countries" :key="country" :value="country">{{ country }}</option>
    </select>

    <div class="language-selection">
      <p>Мови для вивчення:</p>
      <div
        v-for="language in languages"
        :key="language"
        class="language-item"
        :class="{ selected: form.language.includes(language) }"
        @click="toggleLanguageSelection(language)"
      >
        {{ language }}
      </div>
    </div>

    <button @click="$emit('previous')">Назад</button>
    <button @click="submitForm">Зареєструватися</button>
  </div>
</template>

<style scoped>
input,
select {
  display: block;
  width: 100%;
  margin: 15px 0;
  padding: 12px;
  border: 2px solid #ddd;
  border-radius: 10px;
  font-size: 1rem;
  background-color: #f9f9f9;
  transition: border-color 0.3s ease;
}

input:focus,
select:focus {
  border-color: #ff6b6b;
  outline: none;
}

select {
  height: auto;
  min-height: 40px;
  padding: 10px;
  background-color: #fff;
}

.language-selection {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
  margin-top: 20px;
}

.language-item {
  background-color: #f9f9f9;
  padding: 8px 15px;
  border: 2px solid #ddd;
  border-radius: 10px;
  font-size: 0.9rem;
  cursor: pointer;
  transition:
    background-color 0.3s ease,
    border-color 0.3s ease;
  display: inline-block;
}

.language-item:hover {
  background-color: #ffefef;
}

.language-item.selected {
  background-color: #ff6b6b;
  color: white;
  border-color: #ff6b6b;
}

button {
  background-color: #ff6b6b;
  color: white;
  padding: 15px;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  width: 100%;
  font-size: 1.2rem;
  margin-top: 20px;
  transition: background-color 0.3s ease;
}

button:hover {
  background-color: #ff4d4d;
}
</style>
