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
                    __instance.m_DurationHours *= ToolsQuality.ToolsQualityMod(__instance.GetSelectedTool());
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

        [HarmonyPatch(typeof(Panel_BodyHarvest), "GetQuarterDurationMinutes")]
        public class Panel_BodyHarvest_GetQuarterDurationMinutes
        {
            private static void Postfix(Panel_BodyHarvest __instance, ref float __result)
            {
                GearItem tool = __instance.GetSelectedTool();
                float timemod = Settings.options.QuaterTimeMultiplier;
                if (tool)
                {
                    timemod *= ToolsQuality.ToolsQualityMod(tool);
                }
                __result *= timemod;
                // label does not update
                if (__instance.m_Label_QuarterEstimatedTime)
                {
                    __instance.m_Label_QuarterEstimatedTime.text = Utils.GetExpandedDurationString(Mathf.RoundToInt(__result));
                }
            }
        }

        [HarmonyPatch(typeof(Panel_Crafting), "GetModifiedCraftingDuration")]
        public class Panel_Crafting_GetModifiedCraftingDuration
        {
            private static void Postfix(Panel_Crafting __instance, ref int __result)
            {
                GearItem tool = __instance.m_RequirementContainer.GetSelectedTool();
                if (tool)
                {
                    __result = (int)(__result * ToolsQuality.ToolsQualityMod(tool));
                }
            }
        }
    }
}