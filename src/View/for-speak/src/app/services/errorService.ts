export const handleError = (error: any) => {
  console.error('Error:', error)
  alert(error.message || 'Щось пішло не так!')
}
