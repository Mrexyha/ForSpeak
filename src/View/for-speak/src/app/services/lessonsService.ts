import axios from 'axios'

export async function fetchLessons(languageId: number | string) {
  const API_URL = `https://localhost:7058/api/Lessons/get-lessons-by-language-id/${languageId}`
  try {
    const response = await axios.get(API_URL)
    console.log('LESSONS DATA:', response.data)
    return response.data
  } catch (error) {
    console.error('Помилка отримання уроків:', error)
    return []
  }
}
