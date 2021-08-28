using HarmonyLib;
using UnityEngine;
using MelonLoader;


namespace ToolsQuality
{
    internal static class Patches
    {
        [HarmonyPatch(typeof(Panel_BreakDown), "UpdateDurationLabel")]
        public class Panel_BreakDown_UpdateDurationLabel
        {
            private static void Postfix(Panel_BreakDown __instance)
            {

                if (__instance.m_BreakDown.m_DisplayName == "Branch")
                {
                    __instance.m_DurationHours *= Settings.options.BreakBranchTimeMultiplier;
                }

                if (__instance.m_BreakDown.m_DisplayName.EndsWith("Limb"))
                {
                    __instance.m_DurationHours *= Settings.options.BreakLimbTimeMultiplier;
                }

                if (__instance.GetSelectedTool())
                {
                    MelonLogger.Msg("IN " + __instance.m_DurationHours);
                    __instance.m_DurationHours *= ToolsQuality.ToolsQualityMod(__instance.GetSelectedTool());
                    MelonLogger.Msg("OUT " + __instance.m_DurationHours);
                    __instance.m_DurationLabel.text = Utils.GetExpandedDurationString(Mathf.RoundToInt(__instance.m_DurationHours * 60f));
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