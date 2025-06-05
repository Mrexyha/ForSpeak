<script setup lang="ts">
import { computed, defineProps } from 'vue'
import MarkdownIt from 'markdown-it'

const md = new MarkdownIt()

interface TheoryModule {
  text: string
}

interface Lesson {
  id: number
  title: string
  theory: TheoryModule | null
}

const props = defineProps<{ lesson: Lesson }>()

const theoryHtml = computed(() => {
  const markdownText = props.lesson.theory?.text || ''
  return md.render(markdownText)
})
</script>

<template>
  <div class="task">
    <h2>📖 Теоретичний матеріал</h2>
    <div v-if="props.lesson.theory">
      <div v-html="theoryHtml"></div>
    </div>
    <p v-else>❌ Теоретичний матеріал відсутній</p>
  </div>
</template>

<style scoped>
.task {
  margin: 40px auto;
  padding: 30px;
  background-color: #ffffff;
  border-radius: 10px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  max-width: 800px;
  text-align: left;
  margin-top: 100px;
}

h2 {
  font-size: 24px;
  color: #3f51b5;
  font-weight: bold;
  margin-bottom: 20px;
}

p {
  font-size: 16px;
  color: #555;
  line-height: 1.6;
  margin-top: 20px;
}

p::before {
  content: '📘 ';
  font-size: 20px;
  color: #3f51b5;
}

p:empty::before {
  content: '❌ Матеріал відсутній';
  color: #e64a19;
}
</style>
