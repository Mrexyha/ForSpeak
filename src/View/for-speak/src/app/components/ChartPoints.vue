<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { Line } from 'vue-chartjs'
import {
  Chart as ChartJS,
  Title,
  Tooltip,
  Legend,
  LineElement,
  LinearScale,
  CategoryScale,
  PointElement,
  type TooltipItem,
} from 'chart.js'
import { fetchLanguages, type Language } from '../services/languageService'
import { getLanguagePoints, getTotalPointsHistory } from '../services/progressService'

ChartJS.register(Title, Tooltip, Legend, LineElement, LinearScale, CategoryScale, PointElement)

interface ChartData {
  labels: string[]
  datasets: {
    label: string
    data: number[]
    fill: boolean
    tension: number
    pointRadius: number
  }[]
}

const chartData = ref<ChartData | null>(null)
const chartOptions = {
  responsive: true,
  maintainAspectRatio: false,
  plugins: {
    tooltip: {
      callbacks: {
        label: (ctx: TooltipItem<'line'>) => {
          return `${ctx.dataset.label}: ${ctx.parsed.y} балів`
        },
      },
    },
    legend: { position: 'bottom' as const },
    title: { display: true, text: 'Прогрес у балах' },
  },
  scales: {
    x: { title: { display: true, text: 'Місяць' } },
    y: { title: { display: true, text: 'Бали' } },
  },
}

onMounted(async () => {
  const langs: Language[] = await fetchLanguages()

  const labels = ['Вер 2024', 'Жов 2024', 'Лис 2024', 'Гру 2024', 'Січ 2025', 'Лют 2025']

  const datasets = await Promise.all(
    langs.map(async (lang: Language) => {
      const data: number[] = await getLanguagePoints(lang.id)
      return {
        label: lang.name,
        data,
        fill: false,
        tension: 0.3,
        pointRadius: 4,
      }
    }),
  )

  const total: number[] = await getTotalPointsHistory()
  datasets.push({
    label: 'Усі мови (загалом)',
    data: total,
    fill: false,
    tension: 0.3,
    pointRadius: 4,
  })

  chartData.value = { labels, datasets }
})
</script>

<template>
  <div class="chart-container">
    <Line v-if="chartData" :data="chartData" :options="chartOptions" />
  </div>
</template>

<style scoped>
.chart-container {
  width: 100%;
  max-width: 700px;
  height: 350px;
  margin: 0 auto;
  padding: 20px;
  background: white;
  border-radius: 10px;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
}
</style>
