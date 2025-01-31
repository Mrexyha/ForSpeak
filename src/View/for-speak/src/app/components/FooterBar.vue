<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <div class="main-container">
    <div class="section"></div>
    <div class="imgs-wrapper">
      <div class="instagram"></div>
      <div class="facebook"></div>
      <div class="twitter"></div>
    </div>
    <nav class="navs">
      <RouterLink class="nav main" to="/">Головна</RouterLink>
      <RouterLink class="nav news" to="/">Новини</RouterLink>
      <RouterLink class="nav about" to="/">Про нас</RouterLink>
      <RouterLink class="nav team" to="/">Наша команда</RouterLink>
    </nav>
  </div>
</template>

<style scoped>
.main-container {
  position: relative;
  width: 100%;
  height: 64.955px;
  margin: 0 auto;
}
.section {
  position: absolute;
  width: 100%;
  height: 64.955px;
  top: 0;
  left: 0;
  background: #03045e;
}
.imgs-wrapper {
  position: absolute;
  width: 131.909px;
  height: 31.978px;
  top: 12.991px;
  left: 39.972px;
  z-index: 1;
}
.instagram {
  position: absolute;
  width: 31.978px;
  height: 31.978px;
  top: 0;
  left: 0;
  background: url('../../assets/inst.png') no-repeat center;
  background-size: cover;
  z-index: 2;
}
.facebook {
  position: absolute;
  width: 31.978px;
  height: 31.978px;
  top: 0;
  left: 49.965px;
  background: url('../../assets/facebook.png') no-repeat center;
  background-size: cover;
  z-index: 3;
}
.twitter {
  position: absolute;
  width: 31.978px;
  height: 31.978px;
  top: 0;
  left: 99.931px;
  background: url('../../assets/twitter.png') no-repeat center;
  background-size: cover;
  z-index: 4;
}

.nav {
  text-decoration: none;
}

.main {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  position: absolute;
  height: 14.49px;
  top: 19.986px;
  left: 247.828px;
  color: #ffffff;
  font-family: Inter, var(--default-font-family);
  font-size: 12px;
  font-weight: 400;
  line-height: 14.49px;
  text-align: left;
  white-space: nowrap;
  z-index: 5;
}
.news {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  position: absolute;
  height: 14.49px;
  top: 19.986px;
  left: 340.764px;
  color: #ffffff;
  font-family: Inter, var(--default-font-family);
  font-size: 12px;
  font-weight: 400;
  line-height: 14.49px;
  text-align: left;
  white-space: nowrap;
  z-index: 6;
}
.about {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  position: absolute;
  height: 14.49px;
  top: 19.986px;
  left: 430.202px;
  color: #ffffff;
  font-family: Inter, var(--default-font-family);
  font-size: 12px;
  font-weight: 400;
  line-height: 14.49px;
  text-align: left;
  white-space: nowrap;
  z-index: 7;
}
.team {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  position: absolute;
  height: 14.49px;
  top: 19.986px;
  left: 522.138px;
  color: #ffffff;
  font-family: Inter, var(--default-font-family);
  font-size: 12px;
  font-weight: 400;
  line-height: 14.49px;
  text-align: left;
  white-space: nowrap;
  z-index: 8;
}
</style>
