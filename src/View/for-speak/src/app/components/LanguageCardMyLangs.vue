<script setup lang="ts">
import { defineProps, defineEmits } from 'vue'
import { useRouter } from 'vue-router'

const props = defineProps<{
  languageId: number
  name: string
  description: string
  progress: number
  tasksCount: number
  isFinished: boolean
}>()

const router = useRouter()

const goToEducation = () => {
  router.push(`/education/${props.languageId}`)
}

const emit = defineEmits<{
  (e: 'deleted', id: number): void
}>()

const handleDelete = () => {
  if (confirm(`Ви дійсно хочете видалити мову "${props.name}"?`)) {
    emit('deleted', props.languageId)
  }
}
</script>

<template>
  <div class="my-lang-container">
    <div class="content-container">
      <h1 class="title">{{ name }}</h1>
      <p class="highlight">{{ tasksCount }} тем у вільному доступі</p>
      <p>{{ description }}</p>
      <p>Прогрес: {{ Math.round(progress * 100) }}%</p>
    </div>

    <div class="btns-container">
      <button class="continue-btn" @click="goToEducation">
        {{ isFinished ? 'Почати спочатку' : 'Перемкнутися' }}
      </button>
      <button class="delete-btn" @click="handleDelete">Видалити</button>
    </div>
  </div>
</template>

<style scoped>
.my-lang-container {
  position: relative;
  width: 812px;
  padding: 32px;
  margin: 0 auto;
  background: #ade8f4;
  border-radius: 8px;
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25);
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
}

.title {
  color: #032a5e;
  font-family: Jost, sans-serif;
  font-size: 36px;
  font-weight: 500;
  text-align: left;
  margin-bottom: 10px;
}

.content-container {
  display: flex;
  flex-direction: column;
  flex: 1;
}

.my-lang-content {
  font-family: Inter, sans-serif;
  font-size: 16px;
  font-weight: 600;
  color: #000;
  text-align: left;
  width: 500px;
}

p {
  margin-bottom: 12px;
}

.highlight {
  font-size: 18px;
  font-weight: bold;
}

.btns-container {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  gap: 20px;
  align-items: flex-end;
  height: 100%;
}

button {
  width: 200px;
  height: 42px;
  border-radius: 8px;
  font-family: Inter, sans-serif;
  font-size: 18px;
  font-weight: 600;
  cursor: pointer;
  text-align: center;
  transition: 0.3s ease-in-out;
  border: none;
}

.continue-btn {
  background: #0077b6;
  color: #ffffff;
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25) inset;
}

.continue-btn:hover {
  background: #005b8f;
}

.delete-btn {
  width: 200px;
  height: 42px;
  border-radius: 8px;
  background: #b60003;
  color: #fff;
  font-size: 18px;
  font-weight: 600;
  cursor: pointer;
  border: none;
}
.delete-btn:hover {
  background: #920002;
}
</style>
