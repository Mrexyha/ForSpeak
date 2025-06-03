import api from './api'

export const getLanguagePoints = async (languageId: number): Promise<number> => {
  const res = await api.get<number>(`/Progress/language/${languageId}/points`)
  return res.data
}

export const getTotalPointsHistory = async (): Promise<number> => {
  const res = await api.get<number>(`/Progress/total-points`)
  return res.data
}

export const getLanguageHistory = async (languageId: number): Promise<number[]> => {
  const res = await api.get<number[]>(`/Progress/language/${languageId}/history`)
  return res.data
}

export const getTotalHistory = async (): Promise<number[]> => {
  const res = await api.get<number[]>(`/Progress/total-points/history`)
  return res.data
}
