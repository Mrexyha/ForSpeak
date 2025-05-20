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

export const getUserLanguages = async () => {
  const userId = localStorage.getItem('userId')
  const token = localStorage.getItem('token')
  if (!userId || !token) throw new Error('User is not authorized!')

  try {
    const { data } = await axios.get(`${API_URL}/${userId}/languages`, {
      headers: { Authorization: `Bearer ${token}` },
    })
    return data
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || 'Не вдалося завантажити мови')
    }
    throw new Error('Сталася невідома помилка при завантаженні мов')
  }
}

export const addLanguageToUser = async (languageId: number) => {
  const userId = localStorage.getItem('userId')
  const token = localStorage.getItem('token')

  if (!userId || !token) throw new Error('User is not authorized!')

  try {
    await axios.post(`${API_URL}/${userId}/languages/${languageId}`, null, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data || 'Не вдалося додати мову')
    } else {
      throw new Error('Помилка при додаванні мови')
    }
  }
}

export const deleteLanguageFromUser = async (languageId: number) => {
  const userId = localStorage.getItem('userId')
  const token = localStorage.getItem('token')

  if (!userId || !token) throw new Error('User is not authorized!')

  try {
    await axios.delete(`${API_URL}/${userId}/languages/${languageId}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      throw new Error(error.response?.data?.message || 'Не вдалося видалити мову')
    } else {
      throw new Error('Сталася невідома помилка при видаленні мови')
    }
  }
}
