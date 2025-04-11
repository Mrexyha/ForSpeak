import axios from 'axios'

const API_URL = 'https://localhost:7058/api/User'

export const getUserProfile = async () => {
  const token = localStorage.getItem('token')
  const userId = localStorage.getItem('userId')

  if (!token || !userId) throw new Error('User is not authorized!')

  try {
    const response = await axios.get(`${API_URL}/${userId}`, {
      headers: { Authorization: `Bearer ${token}` },
    })
    return response.data
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || 'Failed to retrieve profile')
    } else {
      throw new Error('Failed to retrieve profile')
    }
  }
}
