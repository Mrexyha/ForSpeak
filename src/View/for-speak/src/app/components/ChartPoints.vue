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
  Filler,
  type TooltipItem,
  type ChartOptions,
  type Plugin,
} from 'chart.js'
import { getLanguageHistory, getTotalHistory } from '../services/progressService'
import { useLanguagesStore } from '../stores/languages'

const lineShadow: Plugin<'line'> = {
  id: 'lineShadow',
  beforeDatasetsDraw(chart) {
    const ctx = chart.ctx
    chart.data.datasets.forEach((_, i) => {
      ctx.save()
      ctx.shadowColor = 'rgba(0,0,0,0.1)'
      ctx.shadowBlur = 10
      ctx.shadowOffsetY = 4
      new LineElement({ _chart: chart, _datasetIndex: i }).draw(ctx)
      ctx.restore()
    })
  },
}

ChartJS.register(
  Title,
  Tooltip,
  Legend,
  LineElement,
  LinearScale,
  CategoryScale,
  PointElement,
  Filler,
  lineShadow,
)

const COLORS = ['#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0', '#9966FF', '#FF9F40']

interface ChartData {
  labels: string[]
  datasets: {
    label: string
    data: number[]
    fill: boolean
    tension: number
    pointRadius: number
    borderWidth?: number
    borderColor: string | CanvasGradient
    backgroundColor: string | CanvasGradient
    pointBackgroundColor: string
    pointBorderColor: string
    pointHoverRadius: number
  }[]
}

type LineChartOptions = ChartOptions<'line'>

const chartData = ref<ChartData | null>(null)
const chartOptions: LineChartOptions = {
  responsive: true,
  maintainAspectRatio: false,
  layout: { padding: { top: 20, right: 30, bottom: 20, left: 10 } },
  plugins: {
    tooltip: {
      backgroundColor: 'rgba(50,50,50,0.8)',
      titleFont: { size: 14, weight: 'bold' },
      bodyFont: { size: 12 },
      callbacks: {
        label: (ctx: TooltipItem<'line'>) => `${ctx.dataset.label}: ${ctx.parsed.y} балів`,
      },
    },
    legend: {
      position: 'bottom',
      labels: { boxWidth: 12, padding: 10, font: { size: 12 } },
    },
    title: {
      display: true,
      text: 'Прогрес у балах (останні 6 місяців)',
      font: { size: 16, weight: 'bold' },
      padding: { top: 10, bottom: 20 },
    },
  },
  scales: {
    x: {
      title: { display: true, text: 'Місяць', font: { size: 14 } },
      grid: { display: false },
    },
    y: {
      beginAtZero: true,
      title: { display: true, text: 'Бали', font: { size: 14 } },
      ticks: { stepSize: 10, font: { size: 12 } },
      grid: {
        color: 'rgba(200,200,200,0.2)',
      },
      border: {
        display: false,
      },
    },
  },
  animation: {
    duration: 800,
    easing: 'easeOutQuad',
  },
}

function lastNMonths(n: number): string[] {
  const labels: string[] = []
  const now = new Date()
  for (let i = n - 1; i >= 0; i--) {
    const d = new Date(now.getFullYear(), now.getMonth() - i, 1)
    labels.push(d.toLocaleString('uk-UA', { month: 'short', year: 'numeric' }))
  }
  return labels
}

function createGradient(ctx: CanvasRenderingContext2D, color: string) {
  const grad = ctx.createLinearGradient(0, 0, 0, 400)
  grad.addColorStop(0, color + '88')
  grad.addColorStop(1, color + '00')
  return grad
}

onMounted(async () => {
  try {
    const langsStore = useLanguagesStore()
    await langsStore.fetchUserLanguages()
    const langs = langsStore.list

    const labels = lastNMonths(6)

    const canvas = document.createElement('canvas')
    const ctx = canvas.getContext('2d')!

    canvas.width = 800
    canvas.height = 400

    const datasets = await Promise.all(
      langs.map(async (lang, idx) => {
        const data = await getLanguageHistory(lang.id)
        const baseColor = COLORS[idx % COLORS.length]
        return {
          label: lang.name,
          data,
          fill: true,
          tension: 0.4,
          pointRadius: 4,
          borderWidth: 2,
          borderColor: baseColor,
          backgroundColor: createGradient(ctx, baseColor),
          pointBackgroundColor: '#fff',
          pointBorderColor: baseColor,
          pointHoverRadius: 6,
        }
      }),
    )

    const total = await getTotalHistory()
    datasets.push({
      label: 'Усі мови (загалом)',
      data: total,
      fill: true,
      tension: 0.4,
      pointRadius: 0,
      borderWidth: 2,
      borderColor: '#333333',
      backgroundColor: createGradient(ctx, '#333333'),
      pointBackgroundColor: '#333333',
      pointBorderColor: '#333333',
      pointHoverRadius: 0,
    })

    chartData.value = { labels, datasets }
  } catch (err) {
    console.error('Не вдалося завантажити прогрес:', err)
  }
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
  max-width: 800px;
  height: 400px;
  margin: 2rem auto;
  padding: 1.5rem;
  background: var(--bg-graph, #fafafa);
  border-radius: 1rem;
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.05);
  transition: background 0.3s ease;
}
</style>
