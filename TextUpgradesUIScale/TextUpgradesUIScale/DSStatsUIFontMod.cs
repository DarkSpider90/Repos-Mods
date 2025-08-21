using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using TextUpgradesUIScale.Patches;

namespace DSStatsUIFontMod

    
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class StatsUIFontMod : BaseUnityPlugin 
    {
        private const string modGUID = "DSModUI.StatsUIFontMod";
        private const string modName = "DarkSpiderStatsUIFontMod";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static StatsUIFontMod Instance;

        internal ManualLogSource mls;

            void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("HE IS ALIVEEEEEEEEEE");

            harmony.PatchAll(typeof(StatsUIFontMod));
            harmony.PatchAll(typeof(StatsUIPatchMod));

        }

}
}
