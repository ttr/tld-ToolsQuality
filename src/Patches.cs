using HarmonyLib;
using MelonLoader;

namespace ToolsQuality
{
    internal static class Patches
    {
        [HarmonyPatch(typeof(BreakDown), "Start")]
        public class BreakDown_Start
        {
            private static void Postfix(BreakDown __instance)
            {

                if (__instance.m_DisplayName == "Branch")
                {
                    __instance.m_TimeCostHours *= Settings.options.BreakBranchTimeMultiplier;
                }

                if (__instance.m_DisplayName.EndsWith("Limb"))
                {
                    __instance.m_TimeCostHours *= Settings.options.BreakLimbTimeMultiplier;
                }
            }
        }

        [HarmonyPatch(typeof(Panel_BodyHarvest), "GetHarvestDurationMinutes")]
        public class Panel_BodyHarvest_GetHarvestDurationMinutes
        {
            private static void Postfix(Panel_BodyHarvest __instance, ref float __result)
            {
                GearItem tool = __instance.GetSelectedTool();
                float timemod = Settings.options.HarvestTimeMultiplier;
                if (tool)
                {
                    timemod *= ToolsQuality.ToolsQualityMod(tool);
                }
                __result *= timemod;
            }
        }

    }


}