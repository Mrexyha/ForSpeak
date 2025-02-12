<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'

const showButton = ref(false)

const checkScroll = () => {
  if (window.scrollY > 100) {
    showButton.value = true
  } else {
    showButton.value = false
  }
}

const scrollToTop = () => {
  window.scrollTo({ top: 0, behavior: 'smooth' })
}

onMounted(() => {
  window.addEventListener('scroll', checkScroll)
})

onUnmounted(() => {
  window.removeEventListener('scroll', checkScroll)
})
</script>

<template>
  <div :class="['up-btn', { show: showButton }]" @click="scrollToTop">⬆</div>
</template>

<style scoped>
.up-btn {
  position: fixed;
  bottom: 20px;
  right: 20px;
  width: 50px;
  height: 50px;
  background-color: #130a48;
  color: white;
  font-size: 24px;
  border-radius: 50%;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
  transition:
    opacity 0.3s ease,
    background-color 0.3s ease;
  opacity: 0;
  z-index: 1;
}

.up-btn.show {
  opacity: 1;
}

.up-btn:hover {
  background-color: #023e8a;
}
</style>
