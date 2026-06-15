# Текст для GitHub Release — LCBridge v1.1.0

При создании релиза (Releases -> Draft a new release):
- **Tag:** `v1.1.0`
- **Title:** `LCBridge v1.1.0`
- **Assets:** прикрепи `LCBridge.dll`

Тело релиза (скопируй ниже) ⬇️

---

## LCBridge v1.1.0 🛰️

Локальный мост между **Lethal Company** и стрим-оверлеем. Плагин раз в секунду
собирает состояние игры и отдаёт его по WebSocket (`ws://localhost:8181`),
а HTML-оверлей рисует это поверх стрима. Мод **только читает** игру — ничего
в неё не пишет.

### Что передаётся
- **Монстры:** списки снаружи и в комплексе, уникальные особи за забег, топ-монстр и «убийца».
- **ToilHead:** турель на голове даёт суффикс к имени (`Spring+Turret` и т.п.), если мод установлен.
- **Ловушки:** ванильные турели, мины, шипастые потолки числом по типам.
- **Лут:** накопительная сумма скрапа — не падает после продажи Компании.
- **Погода:** WeatherTweaks / WeatherRegistry, иначе ванильная.
- **События:** текущее событие Brutal Company.
- **Аналитика забега:** по квотам и лунам, пик монстров, время внутри/снаружи, таймлайн.

### Установка
1. [BepInExPack для Lethal Company](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/).
2. `LCBridge.dll` -> `…/Lethal Company/BepInEx/plugins/`.
3. Запусти игру один раз (создастся конфиг). Порт WebSocket — в `[Server] WebSocketPort` (по умолчанию 8181).

### Оверлей
`overlay.html` -> в OBS как Browser Source 1920x1080. Подключится к мосту сам.

### Зависимости
- BepInEx (обязательно).
- Мягкие (необязательные): BrutalCompanyMinusExtraReborn, WeatherTweaks, ToilHead.

---

**GDLP** · *Games Don't Like People* · https://solo00n.github.io/GDLP-tournament/
