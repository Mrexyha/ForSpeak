<script setup lang="ts"></script>

<template>
  <div class="lang-container">
    <img class="lang-pic" src="../../assets/main/UK-main.jpg" alt="United Kingdom" />
    <div class="lang-content">
      <h1 class="title">Англійська мова</h1>
      <div class="flag"></div>
      <p class="description">
        Англійська мова відкриває доступ до кращих освітніх, кар'єрних та культурних можливостей у
        світі, а також допомагає спілкуватися з людьми з різних країн. Це універсальний інструмент
        для подорожей, саморозвитку та успіху в багатьох сферах життя.
      </p>
      <div class="btn-container">
        <span class="text">Почати вивчення</span>
        <div class="group"></div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.lang-container {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  margin-bottom: 36px;
}

.lang-pic {
  width: 50%;
  height: auto;
}

.lang-content {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  padding-left: 20px;
  text-align: center;
  max-width: 50%;
}

.title {
  color: #032a5e;
  font-family: Jost, var(--default-font-family);
  font-size: 42px;
  font-weight: 500;
}

.flag {
  background: url('../../assets/general/flag-united-kingdom.png') no-repeat center;
  background-size: cover;
  width: 42px;
  height: 42px;
  margin-bottom: 36px;
  margin-top: 24px;
}

.description {
  color: #000000;
  font-family: Abel, var(--default-font-family);
  font-size: 16px;
  font-weight: 400;
  line-height: 1.6;
  margin-bottom: 54px;
  max-width: 50%;
}

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
