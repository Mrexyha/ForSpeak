<script setup lang="ts"></script>

<template>
  <div class="main-container">
    <div class="box"></div>
    <div class="pic"></div>
    <span class="text">ForSpeak</span><span class="text-2">Головна </span
    ><span class="text-3">Мої мови</span><span class="text-4">Профіль</span
    ><span class="text-5">Навчання</span>
  </div>
</template>

<style scoped>
:root {
  --default-font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Ubuntu,
    'Helvetica Neue', Helvetica, Arial, 'PingFang SC', 'Hiragino Sans GB', 'Microsoft Yahei UI',
    'Microsoft Yahei', 'Source Han Sans CN', sans-serif;
}
.main-container {
  overflow: hidden;
}
.main-container,
.main-container * {
  box-sizing: border-box;
}
input,
select,
textarea,
button {
  outline: 0;
}
.main-container {
  position: relative;
  width: 567px;
  height: 44px;
  margin: 0 auto;
}
.box {
  position: absolute;
  width: 567px;
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
  background: url('../assets/images/385be879-46a8-4777-b61c-19f3346384df.png') no-repeat center;
  background-size: cover;
  z-index: 1;
  overflow: hidden;
}
.text {
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
.text-2 {
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
.text-3 {
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
.text-4 {
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
.text-5 {
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
