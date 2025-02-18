import axios from 'axios'

const API_URL = 'https://localhost:7058/api/Auth'

export const registerUser = async (userData: {
  email: string
  password: string
  gender: string
  birthdate: string
  country: string
  language: string[]
}) => {
  try {
    const response = await axios.post(`${API_URL}/register`, userData)
    return response.data
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || 'Помилка реєстрації')
    } else if (error instanceof Error) {
      throw new Error(error.message || 'Помилка реєстрації')
    } else {
      throw new Error('Помилка реєстрації')
    }
  }
}
