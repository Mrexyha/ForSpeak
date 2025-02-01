<script setup lang="ts"></script>

<template>
  <div class="btn-container">
    <span class="text">Почати вивчення</span>
    <div class="group"></div>
  </div>
</template>

<style scoped>
.btn-container {
  position: relative;
  width: 200px;
  height: 32px;
  margin: 0 auto;
  font-size: 0px;
  border-radius: 12px;
}
.text {
  display: block;
  position: relative;
  height: 17px;
  margin: 12px 34px;
  color: #ffffff;
  font-family:
    Abhaya Libre,
    var(--default-font-family);
  font-size: 16px;
  font-weight: 700;
  line-height: 16.516px;
  text-align: left;
  white-space: nowrap;
  z-index: 1;
}
.group {
  position: absolute;
  width: 200px;
  height: 42px;
  top: 0;
  left: 0;
  background: #0096c7;
  border-radius: 12px;
}
</style>
