import axios from 'axios'

const API_URL = 'https://localhost:7058/api/Auth'

export const registerUser = async (userData: {
  email: string
  username: string
  passwordHash: string
  confirmPassword: string
  gender: string
  birthdate: Date
  country: string
  selectedLanguages: string[]
}) => {
  try {
    const response = await axios.post(`${API_URL}/register`, userData)
    return response.data
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      console.log(error.response)
      throw new Error(error.response?.data?.message || 'Помилка реєстрації')
    } else if (error instanceof Error) {
      throw new Error(error.message || 'Помилка реєстрації')
    } else {
      throw new Error('Помилка реєстрації')
    }
  }
}

export const loginUser = async (credentials: { email: string; password: string }) => {
  try {
    const response = await axios.post(`${API_URL}/login`, credentials)
    return response.data
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || 'Помилка входу')
    } else if (error instanceof Error) {
      throw new Error(error.message || 'Помилка входу')
    } else {
      throw new Error('Помилка входу')
    }
  }
}
