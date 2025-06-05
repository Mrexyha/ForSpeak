<template>
  <div class="chart-container">
    <div class="chart-block">
      <h3 class="chart-block__title">Відсотки за поточну мову</h3>
      <div class="progress-circle-wrapper">
        <svg viewBox="0 0 36 36" class="progress-circle">
          <path
            d="M18 2.0845
               a 15.9155 15.9155 0 0 1 0 31.831
               a 15.9155 15.9155 0 0 1 0 -31.831"
            fill="none"
            stroke="#eee"
            stroke-width="2"
          />
          <path
            class="progress"
            :stroke-dasharray="`${languagePercent}, 100`"
            d="M18 2.0845
               a 15.9155 15.9155 0 0 1 0 31.831
               a 15.9155 15.9155 0 0 1 0 -31.831"
            fill="none"
            stroke="#007bff"
            stroke-width="2"
          />
          <text x="18" y="20.35" class="percentage">{{ languagePercent }}%</text>
        </svg>
      </div>
    </div>

    <div class="chart-block">
      <h3 class="chart-block__title">Загальний відсоток навчання</h3>
      <div class="progress-circle-wrapper">
        <svg viewBox="0 0 36 36" class="progress-circle">
          <path
            d="M18 2.0845
               a 15.9155 15.9155 0 0 1 0 31.831
               a 15.9155 15.9155 0 0 1 0 -31.831"
            fill="none"
            stroke="#eee"
            stroke-width="2"
          />
          <path
            class="progress"
            :stroke-dasharray="`${totalPercent}, 100`"
            d="M18 2.0845
               a 15.9155 15.9155 0 0 1 0 31.831
               a 15.9155 15.9155 0 0 1 0 -31.831"
            fill="none"
            stroke="#28a745"
            stroke-width="2"
          />
          <text x="18" y="20.35" class="percentage">{{ totalPercent }}%</text>
        </svg>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, defineProps } from 'vue'

const props = defineProps<{
  languagePoints: number
  totalPoints: number
}>()

const maxLanguagePoints: number = 100
const maxTotalPoints: number = 500

const languagePercent = computed(() => {
  if (maxLanguagePoints === 0) return 0
  const pct = Math.round((props.languagePoints / maxLanguagePoints) * 100)
  return pct > 100 ? 100 : pct
})

const totalPercent = computed(() => {
  if (maxTotalPoints === 0) return 0
  const pct = Math.round((props.totalPoints / maxTotalPoints) * 100)
  return pct > 100 ? 100 : pct
})
</script>

<style scoped>
.chart-container {
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
  gap: 30px;
}

.chart-block {
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 1px 8px rgba(0, 0, 0, 0.08);
  padding: 20px;
  width: 180px;
  text-align: center;
  transition: transform 0.2s;
}

.chart-block:hover {
  transform: translateY(-4px);
}

.chart-block__title {
  font-size: 18px;
  margin-bottom: 12px;
  color: #333;
  font-weight: 500;
}

.progress-circle-wrapper {
  position: relative;
  width: 100px;
  height: 100px;
  margin: 0 auto 10px;
}

.progress-circle {
  width: 100%;
  height: 100%;
  transform: rotate(-90deg);
}

path.progress {
  transition: stroke-dasharray 0.6s ease;
  stroke-linecap: round;
}

.percentage {
  fill: #333;
  font-size: 0.6em;
  text-anchor: middle;
  transform: rotate(90deg);
}

.points-label {
  font-size: 16px;
  color: #555;
  font-weight: 500;
}
</style>
