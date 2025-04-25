import axios from 'axios'

export interface QuizQuestion {
  question: string
  options: string[]
  correctOptionIndex: number
}

export interface QuizModule {
  questions: QuizQuestion[]
}

const API = 'https://localhost:7058/api'

export async function fetchQuiz(languageId: number, lessonId: number) {
  const { data } = await axios.get<QuizModule>(
    `${API}/languages/${languageId}/lessons/${lessonId}/quiz`,
  )
  return data
}

export async function saveQuiz(languageId: number, lessonId: number, payload: QuizModule) {
  return axios.put(`${API}/languages/${languageId}/lessons/${lessonId}/quiz`, payload)
}
