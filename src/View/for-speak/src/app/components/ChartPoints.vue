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

ChartJS.register(Title, Tooltip, Legend, LineElement, LinearScale, CategoryScale, PointElement)

interface ChartData {
  labels: string[]
  datasets: {
    label: string
    borderColor: string
    backgroundColor: string
    data: number[]
    fill: boolean
    tension: number
    pointRadius: number
    pointBackgroundColor: string
  }[]
}

const englishScores = [620, 580, 540, 500, 300, 245]
const frenchScores = [200, 220, 240, 180, 150, 120]

const chartData = ref<ChartData | null>(null)

const chartOptions = ref({
  responsive: true,
  maintainAspectRatio: false,
  plugins: {
    tooltip: {
      callbacks: {
        label: (tooltipItem: TooltipItem<'line'>) => {
          const datasetLabel = tooltipItem.dataset.label || ''
          const value = tooltipItem.raw as number
          return `${datasetLabel}: ${value} балів`
        },
      },
    },
    legend: {
      labels: {
        color: 'black',
      },
    },
  },
  scales: {
    x: {
      ticks: {
        color: 'black',
      },
    },
    y: {
      ticks: {
        color: 'black',
      },
    },
  },
})

onMounted(() => {
  chartData.value = {
    labels: ['Вер 2023', 'Жов 2023', 'Лис 2023', 'Гру 2023', 'Січ 2024', 'Лют 2024'],
    datasets: [
      {
        label: 'Англійська мова',
        borderColor: 'red',
        backgroundColor: 'rgba(255, 0, 0, 0.2)',
        data: englishScores,
        fill: true,
        tension: 0.3,
        pointRadius: 5,
        pointBackgroundColor: 'red',
      },
      {
        label: 'Французька мова',
        borderColor: 'blue',
        backgroundColor: 'rgba(0, 0, 255, 0.2)',
        data: frenchScores,
        fill: true,
        tension: 0.3,
        pointRadius: 5,
        pointBackgroundColor: 'blue',
      },
    ],
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
  max-width: 700px;
  height: 400px;
  margin: 0 auto;
  padding: 20px;
  background: white;
  border-radius: 10px;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
}
</style>
