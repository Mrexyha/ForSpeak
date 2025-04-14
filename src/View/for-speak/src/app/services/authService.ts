import axios from 'axios'

const API_URL = 'https://localhost:7058/api/Auth'

export const registerUser = async (userData: {
  email: string
  username: string
  password: string
  confirmPassword: string
  gender: string
  birthdate: Date
  country: string
  selectedLanguageIds: number[]
}) => {
  try {
    const response = await axios.post(`${API_URL}/register`, userData)
    return response.data
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      console.log(error.response)
      throw new Error(error.response?.data?.message || 'Registration failed')
    } else if (error instanceof Error) {
      throw new Error(error.message || 'Registration failed')
    } else {
      throw new Error('Registration failed')
    }
  }
}

export const loginUser = async (credentials: { email: string; password: string }) => {
  try {
    const response = await axios.post(`${API_URL}/login`, credentials)
    console.log('Login response:', response.data)

    const { token, userId } = response.data

    if (!userId) {
      throw new Error('userId not received during login!')
    }

    console.log('Login UserID:', userId)

    localStorage.setItem('token', token)
    localStorage.setItem('userId', userId)

    return response.data
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || 'Login failed')
    } else {
      throw new Error('Login failed')
    }
  }
}
