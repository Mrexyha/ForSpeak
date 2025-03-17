import axios from 'axios'

const API_URL = 'https://localhost:7058/api/Language/get-all-languages'

export async function fetchLanguages() {
  try {
    const response = await axios.get(API_URL)
    return response.data
  } catch (error) {
    console.error('Помилка отримання мов:', error)
    return []
  }
}
