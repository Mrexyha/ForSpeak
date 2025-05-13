<script setup lang="ts">
import AdminModuleCreator from '../components/AdminModuleCreator.vue'
import PageLayout from '../layouts/PageLayout.vue'
</script>

<template>
  <PageLayout>
    <div class="admin-page">
      <AdminModuleCreator />
    </div>
  </PageLayout>
</template>

<style scoped>
.admin-page {
  margin-top: 100px;
}
</style>
