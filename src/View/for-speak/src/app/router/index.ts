import { createRouter, createWebHistory } from 'vue-router'
import { useAuthStore } from '../stores/auth'

import HomeView from '../views/HomeView.vue'
import MyLanguagesView from '../views/MyLanguagesView.vue'
import EducationView from '../views/EducationView.vue'
import ProfileView from '../views/ProfileView.vue'
import RegisterView from '../views/RegisterView.vue'
import LoginView from '../views/LoginView.vue'
import LessonView from '../views/LessonView.vue'
import TheoryTaskView from '../views/TaskViews/TheoryTaskView.vue'
import QuizTaskView from '../views/TaskViews/QuizTaskView.vue'
import ReadingTaskView from '../views/TaskViews/ReadingTaskView.vue'
import SpeakingTaskView from '../views/TaskViews/SpeakingTaskView.vue'
import VocabularyTaskView from '../views/TaskViews/VocabularyTaskView.vue'
import AdminView from '../views/AdminView.vue'
import { useLanguagesStore } from '../stores/languages'

const routes = [
  { path: '/', name: 'home', component: HomeView },
  {
    path: '/my-languages',
    name: 'my-languages',
    component: MyLanguagesView,
    meta: { requiresAuth: true },
  },
  {
    path: '/education',
    redirect: () => {
      const langsStore = useLanguagesStore()
      return `/education/${langsStore.defaultLanguageId}`
    },
  },
  {
    path: '/education/:languageId',
    name: 'education',
    component: EducationView,
    meta: { requiresAuth: true },
  },
  {
    path: '/education/:languageId/:id',
    name: 'lesson',
    component: LessonView,
    meta: { requiresAuth: true },
  },
  {
    path: '/education/:languageId/:id/theory',
    name: 'theory',
    component: TheoryTaskView,
    meta: { requiresAuth: true },
  },
  {
    path: '/education/:languageId/:id/vocabulary',
    name: 'vocabulary',
    component: VocabularyTaskView,
    meta: { requiresAuth: true },
  },
  {
    path: '/education/:languageId/:id/quiz',
    name: 'quiz',
    component: QuizTaskView,
    meta: { requiresAuth: true },
  },
  {
    path: '/education/:languageId/:id/reading',
    name: 'reading',
    component: ReadingTaskView,
    meta: { requiresAuth: true },
  },
  {
    path: '/education/:languageId/:id/speaking',
    name: 'speaking',
    component: SpeakingTaskView,
    meta: { requiresAuth: true },
  },
  {
    path: '/profile',
    name: 'profile',
    component: ProfileView,
    meta: { requiresAuth: true },
  },
  {
    path: '/register',
    name: 'register',
    component: RegisterView,
    meta: { guestOnly: true },
  },
  {
    path: '/login',
    name: 'login',
    component: LoginView,
    meta: { guestOnly: true },
  },
  {
    path: '/admin/modules/create',
    name: 'admin-create-module',
    component: AdminView,
    meta: { requiresAuth: true, requiresAdmin: true },
  },
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

router.beforeEach((to, from, next) => {
  const auth = useAuthStore()
  const isLoggedIn = !!auth.currentUser
  const role = auth.currentUser?.role.toLowerCase() || ''

  if (to.meta.guestOnly && isLoggedIn) {
    return next({ name: 'home' })
  }

  if (to.meta.requiresAuth && !isLoggedIn) {
    return next({ name: 'login', query: { redirect: to.fullPath } })
  }

  if (to.meta.requiresAdmin && role !== 'admin') {
    return next({ name: 'home' })
  }

  next()
})

export default router
