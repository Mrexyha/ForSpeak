<script setup lang="ts">
import PageLayout from '../layouts/PageLayout.vue'
import LanguageCardMyLangs from '../components/LanguageCardMyLangs.vue'
</script>

<template>
  <PageLayout>
    <div class="langs-page">
      <LanguageCardMyLangs />
      <LanguageCardMyLangs />
    </div>
  </PageLayout>
</template>

<style>
.langs-page {
  margin-top: 100px;
  margin-bottom: 64px;
  display: flex;
  flex-direction: column;
  gap: 32px;
}
</style>
