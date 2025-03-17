<script setup lang="ts">
import { ref, onMounted, computed } from 'vue'
import { fetchLanguages } from '../services/languageService'
import MainLayout from '../layouts/MainLayout.vue'
import LanguageCardMain from '../components/LanguageCardMain.vue'

interface Language {
  id: number
  name: string
  description: string
  image: string
  flag: string
}

const searchQuery = ref('')
// const languages = ref([
//   {
//     id: 1,
//     name: 'Англійська мова',
//     description:
//       "Англійська мова відкриває доступ до кращих освітніх, кар'єрних та культурних можливостей у світі, а також допомагає спілкуватися з людьми з різних країн. Це універсальний інструмент для подорожей, саморозвитку та успіху в багатьох сферах життя.",
//     image: new URL('../../assets/main/UK-main.jpg', import.meta.url).href,
//     flag: new URL('../../assets/main/UK-flag.jpg', import.meta.url).href,
//   },
//   {
//     id: 2,
//     name: 'Німецька мова',
//     description:
//       "Німецька мова відкриває доступ до якісної освіти, кар'єрних можливостей у Європі та культурної спадщини німецькомовних країн. Вона також корисна для подорожей і бізнесу, адже є однією з найпоширеніших мов у ЄС.",
//     image: new URL('../../assets/main/German-main.jpg', import.meta.url).href,
//     flag: new URL('../../assets/main/Germany-flag.jpg', import.meta.url).href,
//   },
//   {
//     id: 3,
//     name: 'Французька мова',
//     description:
//       'Французька мова є однією з основних мов міжнародної дипломатії, культури та мистецтва, відкриваючи доступ до освіти та роботи у франкомовних країнах. Вона також корисна для подорожей і розширює можливості у спілкуванні по всьому світу.',
//     image: new URL('../../assets/main/France-main.jpg', import.meta.url).href,
//     flag: new URL('../../assets/main/France-flag.jpg', import.meta.url).href,
//   },
// ])

const languages = ref<Language[]>([])

onMounted(async () => {
  languages.value = await fetchLanguages()
})

const filteredLanguages = computed(() => {
  return languages.value.filter((lang) =>
    lang.name.toLowerCase().includes(searchQuery.value.toLowerCase()),
  )
})
</script>

<template>
  <MainLayout>
    <div class="header">
      <h1>ForSpeak</h1>
      <div class="search-container">
        <input
          v-model="searchQuery"
          type="text"
          name="search-lang"
          id="search-lang"
          class="search-lang"
          placeholder="Пошук мови..."
        />
        <div class="search-btn">🔍</div>
      </div>
      <img class="main-img" src="../../assets/main/main.jpeg" alt="main page" />
    </div>
    <div class="content">
      <div
        v-for="(language, index) in filteredLanguages"
        :key="language.id"
        :language="language"
        :class="{ 'reverse-card': index % 2 !== 0 }"
      >
        <LanguageCardMain :language="language" />
      </div>
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

.search-container {
  display: flex;
  align-items: center;
  width: 250px;
  height: 40px;
  border-radius: 20px;
  border: 1px solid #023e8a;
  background: #f1f5f9;
  padding: 5px 10px;
  box-shadow: 2px 6px 6px rgba(0, 0, 0, 0.15);
  position: absolute;
  top: 60%;
  left: 15%;
}

.search-lang {
  flex-grow: 1;
  border: none;
  outline: none;
  font-size: 16px;
  background: transparent;
  color: #333;
  padding: 8px;
}

.search-btn {
  background: #023e8a;
  color: white;
  border: none;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  transition: 0.3s;
}

.search-btn:hover {
  background: #0077b6;
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
