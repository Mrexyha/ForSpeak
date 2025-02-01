<script setup lang="ts"></script>

<template>
  <div class="search-container">
    <input
      type="text"
      name="search-lang"
      id="search-lang"
      class="search-lang"
      placeholder="Пошук мови..."
    />
    <div class="search-btn">🔍</div>
  </div>
</template>

<style scoped>
.search-container {
  display: flex;
  align-items: center;
  width: 250px;
  height: 40px;
  border-radius: 20px;
  border: 1px solid #023e8a;
  background: #f1f5f9;
  padding: 5px 10px;
  box-shadow: 2px 6px 6px rgba(0, 0, 0, 0.15);
  position: absolute;
  top: 50%;
  left: 15%;
}

.search-lang {
  flex-grow: 1;
  border: none;
  outline: none;
  font-size: 16px;
  background: transparent;
  color: #333;
  padding: 8px;
}

.search-btn {
  background: #023e8a;
  color: white;
  border: none;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  transition: 0.3s;
}

.search-btn:hover {
  background: #0077b6;
}
</style>
