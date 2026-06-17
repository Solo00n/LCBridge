# LCBridge — сборка DLL (v1.1.3)

В этой версии исправлена хроника по дням (timeline): сквозной счётчик дней
1..9 за всю компанию (через gameStats.daysSpent), запись дня только при
реальной посадке на луну, лимит timeline поднят до 120.

## Что нужно
- .NET SDK 6.0+ (https://dotnet.microsoft.com/download)
- Доступ в интернет для NuGet (первая сборка скачает зависимости)

## Сборка (обычный путь, через NuGet GameLibs)
1. Распакуй архив, открой папку в терминале.
2. Выполни:
       dotnet build -c Release
3. Готовая DLL появится тут:
       bin/Release/LCBridge.dll
   (имя сборки фиксировано как LCBridge.dll)

NuGet сам подтянет BepInEx и игровые ссылки (LethalCompany.GameLibs.Steam).
Источники пакетов уже прописаны в nuget.config (nuget.org + BepInEx).

## Если NuGet GameLibs не скачивается
Открой LCBridge.csproj и:
1. Удали (или закомментируй) строку с PackageReference
   "LethalCompany.GameLibs.Steam".
2. Раскомментируй блок РУЧНОЙ ВАРИАНТ ссылок ниже в том же файле
   и поправь пути на свою установку игры, например:
       C:\Program Files (x86)\Steam\steamapps\common\Lethal Company\Lethal Company_Data\Managed\
   Нужны как минимум: Assembly-CSharp.dll, UnityEngine.dll,
   UnityEngine.CoreModule.dll. Возможно ещё Unity.Netcode.Runtime.dll,
   если линковка попросит.
3. Снова: dotnet build -c Release

## Установка / выкладка
- Локально для теста: положи LCBridge.dll в
      BepInEx/plugins/  (твой профиль r2modman)
- На Thunderstore: собери пакет как раньше — manifest.json (уже 1.1.3),
  icon.png, README, и LCBridge.dll внутри. Зависимости в манифесте:
  BepInEx 5.4.2305 и Zehs-StreamOverlays.

## Важно
- Менялся только мод (источник данных). Оверлей (lethal_overlay_live_34.html)
  уже обновлён отдельно и в пересборке не нуждается.
- После установки на тестовом забеге проверь, что дни идут сквозными 1..9
  за 3 квоты. Если номер дня смещён на 1 — скажи, поправим "+1" в GetDayCount().
