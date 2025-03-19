<script setup lang="ts">
import { defineProps, computed } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const props = defineProps<{
  language: {
    id: number
    name: string
    description: string
    image: string
    flag: string
  }
  reverse?: boolean
}>()

const containerClass = computed(() => ({
  'lang-container': true,
  reverse: props.reverse,
}))

const goToMyLanguages = () => {
  router.push('/my-languages')
}
</script>

<template>
  <div :class="containerClass">
    <img class="lang-pic" :src="language.image" :alt="language.name" />
    <div class="lang-content">
      <h1 class="title">{{ language.name }}</h1>
      <div class="flag" :style="{ backgroundImage: `url(${language.flag})` }"></div>
      <p class="description">{{ language.description }}</p>
      <button class="lets-start-btn" @click="goToMyLanguages">Почати вивчення</button>
    </div>
  </div>
</template>

<style scoped>
.lang-container {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  margin-bottom: 36px;
}

.reverse {
  flex-direction: row-reverse;
}

.lang-pic {
  width: 50%;
  height: auto;
}

.lang-content {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  padding-left: 20px;
  text-align: center;
  max-width: 50%;
}

.title {
  color: #032a5e;
  font-family: Jost, var(--default-font-family);
  font-size: 42px;
  font-weight: 500;
}

.flag {
  width: 42px;
  height: 42px;
  background-size: cover;
  margin: 24px 0 36px;
}

.description {
  color: #000000;
  font-family: Abel, var(--default-font-family);
  font-size: 16px;
  font-weight: 400;
  line-height: 1.6;
  margin-bottom: 54px;
  max-width: 50%;
}

.lets-start-btn {
  position: relative;
  width: 200px;
  height: 42px;
  font-size: 16px;
  border-radius: 12px;

  margin: 12px 34px;
  color: #ffffff;
  font-family:
    Abhaya Libre,
    var(--default-font-family);
  font-weight: 700;
  line-height: 16.516px;
  text-align: center;
  white-space: nowrap;

  background: #0096c7;
}

.lets-start-btn:hover {
  background: #006598;
}
</style>
