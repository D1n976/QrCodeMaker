# QrCodeMaker
Десктопное приложение для создания стилизованных цветных QR-кодов с поддержкой пользовательских цветов и экспорта в изображение
# 🎨 Генератор цветных QR-кодов на C#

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Language](https://img.shields.io/badge/language-C%23-purple.svg)
![Platform](https://img.shields.io/badge/platform-Windows-blue)
![.NET](https://img.shields.io/badge/.NET-6.0+-red.svg)

Простое и стильное **десктопное приложение на C#**, которое создаёт **цветные QR-коды** — идеально для визиток, презентаций, рекламы и цифровых кампаний.

✨ Добавь цвет, логотип и фирменный стиль — и получи QR, который выделяется!

---
![Uploading изображение.png…]()

## 🖼 Пример

![Qr код](Examples/qr.png)

## 🖼 Интерфейс

![GUI Приложения](Examples/1.png)

## 🚀 Возможности

- ✅ Генерация QR-кода из текста или URL
- 🎨 Настройка цвета кода и фона
- 🖱 Удобный графический интерфейс (WPF)
- 💾 Локальное сохранение без интернета

---

## 🛠 Технологии

- **C# (.NET 8 или .NET Framework 4.7.2+)**
- **WPF** (укажи, что использовал)
- Библиотеки:
  - [`CommunityToolkit.Mvvm`](https://github.com/codebude/QRCoder) — MVVM model
  - [`Extended.Wpf.Toolkit`](https://github.com/codebude/QRCoder) — Wpf.Toolkit для интеграции окна выбора цвета
  - [`QRCoder-ImageSharp`](https://github.com/codebude/QRCoder) — MVVM model
  - [`QRCoder.Core`](https://github.com/codebude/QRCoder) — MVVM model
  - [`SixLabors.ImageSharp`](https://github.com/codebude/QRCoder) — MVVM model
  - `System.Drawing.Common` — для обработки изображений
- Поддержка **прозрачных PNG** (формат `PNG` с `Alpha`)
- Кроссплатформенно (если .NET 6+ и не использует WinForms)

---

## 📦 Установка и запуск

### 🔧 Требования
- .NET 6.0+

### 📥 Скачать и запустить

```bash
# Клонировать репозиторий
git clone https://github.com/ваше-имя/colored-qr-generator.git
cd colored-qr-generator

# Собрать проект
dotnet build

# Запустить
dotnet run
