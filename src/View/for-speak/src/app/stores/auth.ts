import { defineStore } from 'pinia'

export interface User {
  id: number
  email: string
  username: string
  role: string
}

interface AuthState {
  currentUser: User | null
}

export const useAuthStore = defineStore('auth', {
  state: (): AuthState => ({
    currentUser: null,
  }),
  actions: {
    setUser(user: User) {
      this.currentUser = user
    },
    clearUser() {
      this.currentUser = null
    },
    initFromLocalStorage() {
      const raw = localStorage.getItem('user')
      if (raw) {
        try {
          this.currentUser = JSON.parse(raw)
        } catch (e) {
          console.error('Failed to parse stored user:', e)
          this.currentUser = null
        }
      }
    },
  },
})
