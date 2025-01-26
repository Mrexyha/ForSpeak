<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <div class="main-container">
    <div class="box"></div>
    <div class="pic"></div>
    <span class="title">ForSpeak</span>
    <nav class="navs">
      <RouterLink class="nav main" to="/">Головна</RouterLink>
      <RouterLink class="nav my-langs" to="/my-languages">Мої мови</RouterLink>
      <RouterLink class="nav education" to="/">Навчання</RouterLink>
      <RouterLink class="nav profile" to="/">Профіль</RouterLink>
    </nav>
  </div>
</template>

<style scoped>
.main-container {
  width: 100%;
}

.box {
  position: absolute;
  width: 100%;
  height: 44px;
  top: 0;
  left: 0;
  background: #0096c7;
  border-radius: 0 0 8px 8px;
  box-shadow: 0 4px 4px 0 rgba(0, 0, 0, 0.25);
}
.pic {
  position: absolute;
  width: 24px;
  height: 24px;
  top: 10px;
  left: 511px;
  background: url('../../../../../assets/user-profile.svg') no-repeat center;
  background-size: cover;
  z-index: 1;
  overflow: hidden;
}
.title {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  position: absolute;
  height: 23px;
  top: 10px;
  left: 364px;
  color: #ffffff;
  font-family:
    Istok Web,
    var(--default-font-family);
  font-size: 16px;
  font-weight: 700;
  line-height: 23px;
  text-align: left;
  white-space: nowrap;
  letter-spacing: 1.6px;
  z-index: 2;
}

.nav {
  text-decoration: none;
}

.main {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  position: absolute;
  height: 12px;
  top: 16px;
  left: 36px;
  color: #ffffff;
  font-family:
    Advent Pro,
    var(--default-font-family);
  font-size: 10px;
  font-weight: 700;
  line-height: 11.96px;
  text-align: left;
  white-space: nowrap;
  z-index: 3;
}
.my-langs {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  position: absolute;
  height: 12px;
  top: 16px;
  left: 104px;
  color: #ffffff;
  font-family:
    Advent Pro,
    var(--default-font-family);
  font-size: 10px;
  font-weight: 700;
  line-height: 11.96px;
  text-align: left;
  white-space: nowrap;
  z-index: 4;
}
.profile {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  position: absolute;
  height: 12px;
  top: 16px;
  left: 248px;
  color: #ffffff;
  font-family:
    Advent Pro,
    var(--default-font-family);
  font-size: 10px;
  font-weight: 700;
  line-height: 11.96px;
  text-align: left;
  white-space: nowrap;
  z-index: 5;
}
.education {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  position: absolute;
  height: 12px;
  top: 16px;
  left: 175px;
  color: #ffffff;
  font-family:
    Advent Pro,
    var(--default-font-family);
  font-size: 10px;
  font-weight: 700;
  line-height: 11.96px;
  text-align: left;
  white-space: nowrap;
  z-index: 6;
}
</style>
