<script setup lang="ts">
import { computed, watch } from 'vue'
import { RouterLink, useRoute } from 'vue-router'
import { useAuthStore } from '../stores/auth'
import { useLanguagesStore } from '../stores/languages'

const route = useRoute()
const isActive = (path: string) => route.path === path

const auth = useAuthStore()
const userRole = computed(() => auth.currentUser?.role ?? '')
const isAdmin = computed(() => userRole.value.toLowerCase() === 'admin')

const langsStore = useLanguagesStore()
watch(
  () => langsStore.ready,
  (ready) => {
    if (!ready) langsStore.fetchUserLanguages()
  },
  { immediate: true },
)

const languageId = computed<number>(() => {
  return langsStore.selectedLanguageId ?? langsStore.defaultLanguageId
})
const isHomePage = route.path === '/'
</script>

<template>
  <div class="main-container">
    <nav class="navs">
      <RouterLink class="nav" :class="{ active: isActive('/') }" to="/">Головна</RouterLink>
      <RouterLink class="nav" :class="{ active: isActive('/my-languages') }" to="/my-languages">
        Мої мови
      </RouterLink>
      <RouterLink
        class="nav"
        :class="{ active: isActive(`/education/${languageId}`) }"
        :to="`/education/${languageId}`"
      >
        Навчання
      </RouterLink>

      <RouterLink v-if="isAdmin" class="nav" to="/admin/modules/create">Створити модуль</RouterLink>

      <div :class="['pic', { 'right-corner': !isHomePage }]">
        <RouterLink class="nav profile" to="/profile"></RouterLink>
      </div>
    </nav>
  </div>
</template>

<style scoped>
.main-container {
  position: relative;
  display: flex;
  justify-content: space-between;
}

.pic {
  width: 36px;
  height: 36px;
  background: url('../../../public/assets/general/user-profile.svg') no-repeat center;
  background-size: cover;
  border-radius: 50%;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2);
  position: absolute;
  top: 16px;
  left: 100%;
  z-index: 10;
}

.right-corner {
  top: 16px;
  right: 24px;
  left: auto;
  position: fixed;
}

.navs {
  display: flex;
  align-items: center;
  gap: 16px;
  width: 45%;
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
  transition: color 0.3s;
}

.nav.active {
  color: #03045e;
}

.nav:not(.active) {
  color: #ffffff;
}
</style>
