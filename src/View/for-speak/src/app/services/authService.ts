import axios from 'axios'

const API_URL = 'https://localhost:7058/api/Auth'
const API_URL_USERS = 'https://localhost:7058/api/User'

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
    const { token, userId } = response.data

    const { data: user } = await axios.get(`${API_URL_USERS}/${userId}`, {
      headers: { Authorization: `Bearer ${token}` },
    })

    if (!userId) {
      throw new Error('userId not received during login!')
    }

    return { token, user }
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || 'Login failed')
    } else {
      throw new Error('Login failed')
    }
  }
}
