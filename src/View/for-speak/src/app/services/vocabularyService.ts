import axios from 'axios'

export interface Word {
  id?: number
  word: string
  transcription: string
  translation: string
  audioUrl?: string
}

export interface VocabularyModule {
  words: Word[]
}

const API_BASE = 'https://localhost:7058/api'

export async function fetchVocabulary(languageId: number, lessonId: number) {
  const { data } = await axios.get<VocabularyModule>(
    `${API_BASE}/languages/${languageId}/lessons/${lessonId}/vocabulary`,
  )
  return data
}

export async function saveVocabulary(
  languageId: number,
  lessonId: number,
  payload: VocabularyModule,
) {
  return axios.put(`${API_BASE}/languages/${languageId}/lessons/${lessonId}/vocabulary`, payload)
}
