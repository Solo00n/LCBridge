# Как залить этот проект на GitHub

Ниже три способа — выбери любой. Имя репозитория используй **LCBridge**
(тогда ссылка `https://github.com/solo00n/LCBridge` станет рабочей).

---

## Шаг 0. Создай пустой репозиторий на GitHub

1. Зайди на https://github.com → кнопка **New** (или https://github.com/new).
2. **Repository name:** `LCBridge`
3. Описание (по желанию): `Lethal Company → WebSocket stream overlay bridge`
4. Сделай его **Public**.
5. **НЕ** ставь галочки «Add README / .gitignore / license» — они у нас уже есть в папке.
6. Нажми **Create repository**.

---

## Способ 1 — через веб-интерфейс (проще всего, без программ)

1. На странице нового репозитория нажми **uploading an existing file**.
2. Перетащи в окно **всё содержимое папки LCBridge** (не саму папку, а файлы и подпапки внутри).
3. Внизу напиши commit-сообщение, например `Initial commit: LCBridge mod + overlay`.
4. Нажми **Commit changes**.

> Минус: перетаскивание вложенных папок иногда капризничает. Если структура
> папок не сохранится — используй Способ 2 или 3.

---

## Способ 2 — через команды git (терминал)

Установи [git](https://git-scm.com/), затем в папке проекта:

```bash
cd путь/к/LCBridge

git init
git add .
git commit -m "Initial commit: LCBridge mod + overlay"
git branch -M main
git remote add origin https://github.com/solo00n/LCBridge.git
git push -u origin main
```

При первом push GitHub попросит авторизоваться (логин + Personal Access Token
вместо пароля — токен создаётся в Settings → Developer settings → Tokens).

---

## Способ 3 — через GitHub Desktop (графический клиент)

1. Установи [GitHub Desktop](https://desktop.github.com/), войди в аккаунт.
2. **File → Add Local Repository** → выбери папку `LCBridge`.
3. Desktop предложит создать git-репозиторий здесь — согласись.
4. Слева внизу впиши Summary (`Initial commit`), нажми **Commit to main**.
5. Вверху **Publish repository** → имя `LCBridge`, снять галочку «Keep private»
   если хочешь публичный → **Publish**.

---

## После заливки

- Проверь, что структура папок сохранилась (`BepInEx/plugins/LCBridge.dll`,
  `overlay/overlay.html` и т.д.).
- Ссылка на сайте турнира и в письмах (`github.com/solo00n/LCBridge`) теперь живая.
- Для релиза удобно сделать **Release** на GitHub (вкладка Releases → Draft a new
  release) и приложить туда `LCBridge.dll` — людям будет легко скачать.

## Потом — Thunderstore

Когда соберёшься публиковать на Thunderstore: в папке `thunderstore/` уже лежат
`manifest.json` и `icon.png`. Нужно будет собрать zip со структурой
`manifest.json` + `icon.png` + `README.md` + `BepInEx/plugins/LCBridge.dll`
и залить через сайт Thunderstore. Перед этим проверь манифест через
Manifest Validator и смени `version_number`, если потребуется.
