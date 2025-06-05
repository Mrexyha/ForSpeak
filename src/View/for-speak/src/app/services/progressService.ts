import api from './api'

export const getLanguagePoints = async (languageId: number): Promise<number> => {
  const { data } = await api.get<number>(`/Progress/language/${languageId}/points`)
  return data
}

export const getTotalPoints = async (): Promise<number> => {
  const { data } = await api.get<number>(`/Progress/total-points`)
  return data
}

export const getLanguageHistory = async (languageId: number): Promise<number[]> => {
  const { data } = await api.get<number[]>(`/Progress/language/${languageId}/history`)
  return data
}

export const getTotalHistory = async (): Promise<number[]> => {
  const { data } = await api.get<number[]>(`/Progress/total-points/history`)
  return data
}

export const getLessonPercent = async (languageId: number, lessonId: number): Promise<number> => {
  const { data } = await api.get<number>(`/Progress/lesson/${lessonId}/percent`)
  return data
}

export const getLanguagePercent = async (languageId: number): Promise<number> => {
  const { data } = await api.get<number>(`/Progress/language/${languageId}/percent`)
  return data
}

export const getOverallPercent = async (): Promise<number> => {
  const { data } = await api.get<number>(`/Progress/overall-percent`)
  return data
}
