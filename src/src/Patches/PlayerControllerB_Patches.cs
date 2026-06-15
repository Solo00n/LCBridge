using HarmonyLib;
using GameNetcodeStuff;
using UnityEngine;

namespace LCBridge.Patches
{
    /// <summary>
    /// Считаем реальные смерти и пытаемся определить «убийцу» (ближайшего врага).
    /// </summary>
    [HarmonyPatch(typeof(PlayerControllerB))]
    public static class PlayerControllerB_Patches
    {
        [HarmonyPatch("KillPlayer")]
        [HarmonyPostfix]
        public static void OnKillPlayer(PlayerControllerB __instance, CauseOfDeath causeOfDeath)
        {
            if (__instance != null && __instance.isPlayerDead)
            {
                string killer = ResolveKiller(__instance, causeOfDeath);
                GameState.RegisterDeath(__instance, killer);
            }
        }

        // Кто/что убило: для смертей от врага — имя ближайшего живого врага; иначе обобщённая причина.
        private static string ResolveKiller(PlayerControllerB player, CauseOfDeath cause)
        {
            try
            {
                switch (cause)
                {
                    case CauseOfDeath.Gravity:       return "Падение";
                    case CauseOfDeath.Drowning:      return "Утопление";
                    case CauseOfDeath.Suffocation:   return "Удушье";
                    case CauseOfDeath.Burning:       return "Огонь";
                    case CauseOfDeath.Electrocution: return "Ток";
                    case CauseOfDeath.Crushing:      return "Раздавлен";
                }

                var rm = RoundManager.Instance;
                if (rm == null || rm.SpawnedEnemies == null) return "Неизвестно";
                Vector3 pos = player.transform.position;
                float best = 25f;
                string name = null;
                foreach (var ai in rm.SpawnedEnemies)
                {
                    if (ai == null || ai.isEnemyDead) continue;
                    float d = Vector3.Distance(pos, ai.transform.position);
                    if (d < best)
                    {
                        best = d;
                        name = LCBridge.EnemyResolver.Resolve(ai);
                    }
                }
                return string.IsNullOrEmpty(name) ? "Неизвестно" : name;
            }
            catch
            {
                return "Неизвестно";
            }
        }
    }
}
