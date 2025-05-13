import api from './api'

export const getLanguagePoints = (languageId: number): Promise<number> =>
  api.get<number>(`/Progress/language/${languageId}/points`).then((res) => res.data)

export const getTotalPointsHistory = (): Promise<number> =>
  api.get<number>(`/Progress/total-points`).then((res) => res.data)

export const getLanguageHistory = (languageId: number): Promise<number[]> =>
  api.get<number[]>(`/Progress/language/${languageId}/history`).then((res) => res.data)

export const getTotalHistory = (): Promise<number[]> =>
  api.get<number[]>(`/Progress/total-points/history`).then((res) => res.data)
