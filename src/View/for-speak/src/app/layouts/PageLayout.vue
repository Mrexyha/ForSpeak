<script setup lang="ts">
import NavigationBar from '../components/NavigationBar.vue'
import FooterBar from '../components/FooterBar.vue'
</script>

<template>
  <div class="layout">
    <NavigationBar />
    <div class="content">
      <slot />
    </div>
    <FooterBar />
  </div>
</template>

<style scoped>
.layout {
  display: flex;
  flex-direction: column;
  height: 100vh;
  position: relative;
}
.content {
  flex-grow: 1;
}
</style>
