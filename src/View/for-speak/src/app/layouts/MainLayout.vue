<script setup lang="ts">
import NavigationBar from '../components/NavigationBar.vue'
import FooterBar from '../components/FooterBar.vue'
import GoUpButton from '../components/GoUpButton.vue'
</script>

<template>
  <div class="layout">
    <NavigationBar />
    <div class="content">
      <slot />
    </div>
    <GoUpButton />
    <FooterBar />
  </div>
</template>

<style scoped>
.layout {
  display: flex;
  flex-direction: column;
  height: 100vh;
}
.content {
  flex-grow: 1;
}
</style>
