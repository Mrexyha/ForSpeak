import axios from 'axios'

export interface SpeakingPhrase {
  id: number
  text: string
}

export interface SpeakingModule {
  phrases: SpeakingPhrase[]
  averageAccuracy: number
  id: number
}

const API = 'https://localhost:7058/api'

export async function fetchSpeaking(languageId: number, lessonId: number): Promise<SpeakingModule> {
  const { data } = await axios.get<SpeakingModule>(
    `${API}/languages/${languageId}/lessons/${lessonId}/speaking`,
  )
  return data
}
