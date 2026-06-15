using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;

namespace LCBridge
{
    [BepInPlugin(GUID, NAME, VERSION)]
    // StreamOverlays: жёсткая авто-установка задана в манифесте Thunderstore
    // (Zehs-StreamOverlays). Здесь — мягкая, чтобы LCBridge не блокировался,
    // даже если GUID не совпадёт. Часть функций оверлея требует StreamOverlays.
    [BepInDependency("Zehs.StreamOverlays", BepInDependency.DependencyFlags.SoftDependency)]
    // мягкие зависимости: мост работает и без них, просто будет меньше данных
    [BepInDependency("SoftDiamond.BrutalCompanyMinusExtraReborn", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("mrov.WeatherTweaks", BepInDependency.DependencyFlags.SoftDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "gdlp.lcbridge";
        public const string NAME = "LCBridge";
        public const string VERSION = "1.1.0";

        public static Plugin Instance { get; private set; }
        public static ManualLogSource Log { get; private set; }

        private Harmony _harmony;

        private void Awake()
        {
            Instance = this;
            Log = Logger;

            // конфиг порта (можно менять в r2modman / LethalConfig если установлен)
            int port = Config.Bind("Server", "WebSocketPort", 8181,
                "Порт WebSocket-сервера моста. Оверлей должен слушать этот же порт.").Value;

            Log.LogInfo($"{NAME} v{VERSION} запускается...");

            // патчи Harmony
            _harmony = new Harmony(GUID);
            _harmony.PatchAll(typeof(Patches.PlayerControllerB_Patches));
            _harmony.PatchAll(typeof(Patches.StartOfRound_Patches));
            Log.LogInfo("Harmony-патчи применены.");

            // старт WebSocket-сервера
            try
            {
                BridgeServer.Start(port);
                Log.LogInfo($"WebSocket-сервер моста запущен на ws://localhost:{port}");
            }
            catch (Exception e)
            {
                Log.LogError($"Не удалось запустить сервер: {e}");
            }

            // тикер: раз в секунду собираем состояние и шлём подключённым клиентам
            gameObject.AddComponent<BridgeTicker>();

            Log.LogInfo($"{NAME} готов.");
        }

        private void OnDestroy()
        {
            try { BridgeServer.Stop(); } catch { }
            _harmony?.UnpatchSelf();
        }
    }
}
