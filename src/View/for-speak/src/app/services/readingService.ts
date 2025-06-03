import axios from 'axios'

export interface FillInBlank {
  sentence: string
  correctWord: string
}
export interface ReadingModule {
  text: string
  tasks: FillInBlank[]
}

const API = 'https://localhost:7058/api'

export async function fetchReading(languageId: number, lessonId: number) {
  const { data } = await axios.get<ReadingModule>(
    `${API}/languages/${languageId}/lessons/${lessonId}/reading`,
  )
  return data
}

export async function saveReadingResult(languageId: number, lessonId: number, score: number) {
  await axios.post(`/api/languages/${languageId}/lessons/${lessonId}/reading/results`, {
    score,
  })
}
