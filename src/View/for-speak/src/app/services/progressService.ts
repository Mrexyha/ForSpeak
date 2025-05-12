import axios from 'axios'

export const getLanguagePoints = (languageId: number): Promise<number[]> =>
  axios
    .get<number[]>(`https://localhost:7058/api/Progress/language/${languageId}/points`)
    .then((res) => res.data)

export const getTotalPointsHistory = (): Promise<number[]> =>
  axios.get<number[]>('https://localhost:7058/api/Progress/total-points').then((res) => res.data)
