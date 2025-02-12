<script setup lang="ts">
import PageLayout from '../layouts/PageLayout.vue'
import ChartPoints from '../components/ChartPoints.vue'
</script>

<template>
  <PageLayout>
    <div class="profile-page">
      <div class="profile-header">
        <h1>Особиста інформація</h1>
        <div class="profile-header-content">
          <img src="../../assets/general/man-icon.png" alt="man photo" />
          <div>
            <h1>Json Smith</h1>
            <p>testuseremail@gmail.com</p>
            <p>27 років, Україна</p>
            <p>Зареєстровано: 10/04/2024</p>
            <p>Мови, що вивчаються: англійська, французька.</p>
          </div>
        </div>
      </div>
      <div class="statistics">
        <ChartPoints />
      </div>
    </div>
  </PageLayout>
</template>

<style>
.profile-page {
  margin-top: 100px;
}
</style>
