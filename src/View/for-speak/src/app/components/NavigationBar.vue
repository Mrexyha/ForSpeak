<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <div class="main-container">
    <div class="pic"></div>
    <nav class="navs">
      <RouterLink class="nav main" to="/">Головна</RouterLink>
      <RouterLink class="nav my-langs" to="/my-languages">Мої мови</RouterLink>
      <RouterLink class="nav education" to="/">Навчання</RouterLink>
      <!-- <RouterLink class="nav profile" to="/">Профіль</RouterLink> -->
    </nav>
  </div>
</template>

<style scoped>
.main-container {
  position: relative;
  width: 100%;
  display: flex;
  justify-content: space-between;
}

.pic {
  position: absolute;
  width: 36px;
  height: 36px;
  top: 16px;
  left: 45%;
  background: url('../../assets/user-profile.svg') no-repeat center;
  background-size: cover;
  z-index: 10;
}

.navs {
  display: flex;
  align-items: center;
  gap: 16px;
  position: absolute;
  left: 16px;
  z-index: 5;
}

.nav {
  text-decoration: none;
  color: #ffffff;
  font-family:
    Advent Pro,
    var(--default-font-family);
  font-size: 16px;
  font-weight: 700;
  padding: 16px 16px;
  border-radius: 4px;
  display: inline-block;
}

.main {
  color: #03045e;
}

.my-langs,
.education {
  color: #ffffff;
}
</style>
