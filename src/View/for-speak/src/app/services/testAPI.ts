import { onMounted, ref } from 'vue'
import { useRoute } from 'vue-router'
import axios from 'axios'

export default {
  setup() {
    const route = useRoute()
    const lesson = ref(null)

    onMounted(async () => {
      try {
        const response = await axios.get(`/api/lessons/${route.params.id}`)
        lesson.value = response.data
      } catch (error) {
        console.error('Помилка при завантаженні уроку:', error)
      }
    })

    return { lesson }
  },
}
