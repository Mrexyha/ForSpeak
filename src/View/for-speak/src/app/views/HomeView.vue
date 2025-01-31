<script setup lang="ts">
import MainLayout from '../layouts/MainLayout.vue'
</script>

<template>
  <MainLayout>
    <h1>ForSpeak</h1>
    <img class="main-img" src="../../assets/main.jpeg" alt="main page" />
  </MainLayout>
</template>

<style scoped>
h1 {
  margin: 12% 17%;
  color: #032a5e;
  font-family:
    Istok Web,
    var(--default-font-family);
  font-size: 42px;
  font-weight: 700;
  line-height: 52px;
  letter-spacing: 3.6px;
}

.main-img {
  position: absolute;
  top: 0;
  right: 0;
  width: 50%;
}
</style>
