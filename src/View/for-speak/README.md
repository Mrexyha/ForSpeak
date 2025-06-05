# For Speak

**For Speak** — це мовна навчальна платформа, створена на основі Vue 3, Pinia, Vue Router, Chart.js та підтримкою синтезу мовлення через Web Speech API.

## 📦 Проєкт

- **Тип**: SPA (Single Page Application)
- **Фреймворк**: Vue 3 + TypeScript
- **Стан**: Ранній етап (v0.0.0)
- **Модульність**: ES-модулі (`type: module`)
- **Приватність**: Так (проєкт приватний)

---

## 🧩 Технології

| Технологія             | Призначення                         |
| ---------------------- | ----------------------------------- |
| Vue 3                  | Основний фреймворк                  |
| Pinia                  | Управління станом                   |
| Vue Router             | Клієнтська маршрутизація            |
| Chart.js + vue-chartjs | Побудова графіків                   |
| Markdown-it            | Рендеринг markdown контенту         |
| Web Speech API         | Голосове озвучення                  |
| TypeScript             | Типізація                           |
| Cypress                | E2E та unit-тестування              |
| Vite                   | Збірка та запуск локального сервера |
| ESLint + Prettier      | Лінтинг та форматування коду        |

---

## 🚀 Скрипти

| Команда                 | Опис                                                     |
| ----------------------- | -------------------------------------------------------- |
| `npm run dev`           | Запуск проєкту у режимі розробки                         |
| `npm run build`         | Збірка проєкту з перевіркою типів                        |
| `npm run preview`       | Перегляд зібраного додатку локально                      |
| `npm run type-check`    | Перевірка типів за допомогою `vue-tsc`                   |
| `npm run lint`          | Лінтинг коду з автоматичним виправленням                 |
| `npm run format`        | Форматування файлів у папці `src/` за допомогою Prettier |
| `npm run test:e2e`      | E2E тестування з Cypress (автоматичний режим)            |
| `npm run test:e2e:dev`  | E2E тестування з Cypress у режимі розробки               |
| `npm run test:unit`     | Компонентне тестування з Cypress                         |
| `npm run test:unit:dev` | Відкриття Cypress UI для компонентного тестування        |

---

## 📁 Структура (очікувана)

for-speak/
├── public/
├── src/
│ ├── assets/
│ ├── components/
│ ├── composables/
│ ├── router/
│ ├── store/
│ ├── views/
│ ├── App.vue
│ └── main.ts
├── tests/
├── vite.config.ts
├── tsconfig.json
├── package.json
└── README.md

---

## 🧪 Тестування

Проєкт підтримує компонентне та E2E тестування за допомогою Cypress:

- Компоненти: `npm run test:unit:dev`
- Кінець-кінцю: `npm run test:e2e` або `:dev`

---

## 🧰 Розробка

Після клонування репозиторію:

```bash
npm install
npm run dev
```

Для збірки:
npm run build
npm run preview
