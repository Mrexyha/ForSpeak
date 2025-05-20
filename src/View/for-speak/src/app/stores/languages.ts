import { defineStore } from 'pinia'
import axios from 'axios'
import { fetchLanguages, type Language } from '../services/languageService'

const API_BASE = 'https://localhost:7058/api'

export const useLanguagesStore = defineStore('languages', {
  state: () => ({
    list: [] as (Language & { progress: number; tasksCount: number; isFinished: boolean })[],
    ready: false,
    selectedLanguageId: null as number | null,
  }),
  getters: {
    defaultLanguageId: (s) => (s.list.length > 0 ? Math.min(...s.list.map((l) => l.id)) : 1),
  },
  actions: {
    async fetchUserLanguages() {
      const token = localStorage.getItem('token')
      const userId = localStorage.getItem('userId')
      if (!token || !userId) return

      const allLangs = await fetchLanguages()
      const { data: userLangs } = await axios.get<
        { id: number; progress: number; tasksCount: number; isFinished: boolean }[]
      >(`${API_BASE}/User/${userId}/languages`, {
        headers: { Authorization: `Bearer ${token}` },
      })

      this.list = userLangs
        .map((ul) => {
          const lang = allLangs.find((l: Language) => l.id === ul.id)
          if (!lang) return null
          return {
            ...lang,
            progress: ul.progress,
            tasksCount: ul.tasksCount,
            isFinished: ul.isFinished,
          }
        })
        .filter(
          (x): x is Language & { progress: number; tasksCount: number; isFinished: boolean } => !!x,
        )

      this.ready = true
      if (this.selectedLanguageId === null) {
        this.selectedLanguageId = this.defaultLanguageId
      }
    },

    setSelectedLanguage(id: number) {
      this.selectedLanguageId = id
    },

    async markAsFinished(id: number) {
      const token = localStorage.getItem('token')
      const userId = localStorage.getItem('userId')
      if (!token || !userId) return

      await axios.patch(
        `${API_BASE}/User/${userId}/languages/${id}`,
        { isFinished: true },
        { headers: { Authorization: `Bearer ${token}` } },
      )

      const lang = this.list.find((l) => l.id === id)
      if (lang) lang.isFinished = true
    },

    async restoreLanguage(id: number) {
      const token = localStorage.getItem('token')
      const userId = localStorage.getItem('userId')
      if (!token || !userId) return

      await axios.patch(
        `${API_BASE}/User/${userId}/languages/${id}`,
        { isFinished: false },
        { headers: { Authorization: `Bearer ${token}` } },
      )

      const lang = this.list.find((l) => l.id === id)
      if (lang) lang.isFinished = false
    },
  },
})
