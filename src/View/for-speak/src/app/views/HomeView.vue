<script setup lang="ts">
import MainLayout from '../layouts/MainLayout.vue'
import SearchLang from '../components/SearchLang.vue'
import LanguageCardMain from '../components/LanguageCardMain.vue'
</script>

<template>
  <MainLayout>
    <div class="header">
      <h1>ForSpeak</h1>
      <SearchLang />
      <img class="main-img" src="../../assets/main/main.jpeg" alt="main page" />
    </div>
    <div class="content">
      <LanguageCardMain />
      <div class="reverse-card">
        <LanguageCardMain />
      </div>
      <LanguageCardMain />
    </div>
  </MainLayout>
</template>

<style scoped>
h1 {
  margin: 15% 12%;
  color: #032a5e;
  font-family:
    Istok Web,
    var(--default-font-family);
  font-size: 72px;
  font-weight: 700;
  line-height: 52px;
  letter-spacing: 3.6px;
  margin-bottom: 500px;
}

.main-img {
  position: absolute;
  top: 0;
  right: 0;
  width: 50%;
}

.content {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.reverse-card .lang-container {
  flex-direction: row-reverse;
}
</style>
