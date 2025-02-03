import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import MyLanguagesView from '../views/MyLanguagesView.vue'
import EducationView from '../views/EducationView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/my-languages',
      name: 'my-languages',
      component: MyLanguagesView,
    },
    {
      path: '/education',
      name: 'education',
      component: EducationView,
    },
  ],
})

export default router
