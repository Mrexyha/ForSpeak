import { createRouter, createWebHistory, type RouteLocationNormalized } from 'vue-router'
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

const lessons = [
  {
    id: 1,
    title: 'Вивчення Vue.js',
    description: 'Основи фреймворку Vue.js для розробки інтерфейсів.',
    theory: 'Це основи фреймворку Vue.js, який дозволяє створювати інтерактивні інтерфейси.',
  },
]

const getLessonProps = (route: RouteLocationNormalized) => {
  const lessonId = parseInt(route.params.id as string)
  return {
    lesson: lessons.find((l) => l.id === lessonId) || {
      id: 0,
      title: 'Невідомий урок',
      description: 'Опис недоступний',
      theory: 'Теоретичний матеріал недоступний',
    },
  }
}

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
      path: '/education/english',
      name: 'education',
      component: EducationView,
      props: true,
    },
    {
      path: '/education/english/1',
      name: 'lesson',
      component: LessonView,
      props: true,
    },
    {
      path: '/education/english/:id/theory',
      name: 'theory',
      component: TheoryTaskView,
      props: getLessonProps,
    },
    {
      path: '/education/english/:id/quiz',
      name: 'quiz',
      component: QuizTaskView,
      props: getLessonProps,
    },
    {
      path: '/education/english/:id/reading',
      name: 'reading',
      component: ReadingTaskView,
      props: getLessonProps,
    },
    {
      path: '/education/english/:id/speaking',
      name: 'speaking',
      component: SpeakingTaskView,
      props: getLessonProps,
    },
    {
      path: '/profile',
      name: 'profile',
      component: ProfileView,
    },
    {
      path: '/register',
      name: 'register',
      component: RegisterView,
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView,
    },
  ],
})

export default router
