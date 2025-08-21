using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using TMPro;


namespace TextUpgradesUIScale.Patches
{

    // Класс, содержащий патчи для игры
    [HarmonyPatch(typeof(StatsUI), "Fetch")]

    public static class StatsUIPatchMod

    {

        private static float _defaultFontSize;
        private static bool _defaultFontSizeInitialized = false;
        public static void Postfix(StatsUI __instance)


        {
            var mainText = (TextMeshProUGUI)AccessTools.Field(typeof(StatsUI), "Text").GetValue(__instance);

            var numbersText = (TextMeshProUGUI)AccessTools.Field(typeof(StatsUI), "textNumbers").GetValue(__instance);

            var playerUpgrades = (Dictionary<string, int>)AccessTools.Field(typeof(StatsUI), "playerUpgrades").GetValue(__instance);

            // Определяем количество активных апгрейдов
            int activeUpgradesCount = playerUpgrades.Count(kvp => kvp.Value > 0);


            if (!_defaultFontSizeInitialized)
            {
                _defaultFontSize = mainText.fontSize;
                _defaultFontSizeInitialized = true;
            }

            // Устанавливаем новый размер шрифта в зависимости от количества апгрейдов
            if (activeUpgradesCount >= 20)
            {
                mainText.fontSize = _defaultFontSize * 0.5f; // Уменьшаем на 50%
                numbersText.fontSize = _defaultFontSize * 0.5f;
            }
            else if (activeUpgradesCount >= 18)
            {
                mainText.fontSize = _defaultFontSize * 0.6f; // Уменьшаем на 40%
                numbersText.fontSize = _defaultFontSize * 0.6f;
            }
            else if (activeUpgradesCount >= 16)
            {
                mainText.fontSize = _defaultFontSize * 0.7f; // Уменьшаем на 30%
                numbersText.fontSize = _defaultFontSize * 0.7f;
            }
            else if (activeUpgradesCount >= 14)
            {
                mainText.fontSize = _defaultFontSize * 0.8f; // Уменьшаем на 20%
                numbersText.fontSize = _defaultFontSize * 0.8f;
            }
            else if (activeUpgradesCount >= 12)
            {
                mainText.fontSize = _defaultFontSize * 0.9f; // Уменьшаем на 10%
                numbersText.fontSize = _defaultFontSize * 0.9f;
            }
            else
            {
                mainText.fontSize = _defaultFontSize; // Возвращаем к стандартному размеру
                numbersText.fontSize = _defaultFontSize;
            }
        }
    }
}