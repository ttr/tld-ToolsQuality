﻿using HarmonyLib;
using UnityEngine;
using Il2Cpp;


namespace ToolsQuality
{
    internal static class Patches
    {
        [HarmonyPatch(typeof(Panel_BreakDown), nameof(Panel_BreakDown.UpdateDurationLabel))]

        public class Panel_BreakDown_UpdateDurationLabel
        {
            private static void Postfix(Panel_BreakDown __instance)
            {
                if (__instance.m_BreakDown.name.Contains("Branch"))
                {
                    __instance.m_DurationHours *= Settings.options.BreakBranchTimeMultiplier;
                }

                else if (__instance.m_BreakDown.name.Contains("Limb"))
                {
                    __instance.m_DurationHours *= Settings.options.BreakLimbTimeMultiplier;
                }
                else if (__instance.m_BreakDown.name.Contains("PalletPile"))
                {
                    __instance.m_DurationHours *= Settings.options.BreakPalletTimeMultiplier;
                }


                if (__instance.GetSelectedTool())
                {
                    __instance.m_DurationHours *= ToolsQuality.ToolsQualityMod(__instance.GetSelectedTool());
                    __instance.m_BreakdownInfo.m_DurationLabel.text = Utils.GetExpandedDurationString(Mathf.RoundToInt(__instance.m_DurationHours * 60f));
                }
            }
        }

        [HarmonyPatch(typeof(Panel_BodyHarvest), nameof(Panel_BodyHarvest.GetHarvestDurationMinutes))]
        public class Panel_BodyHarvest_GetHarvestDurationMinutes
        {
            //[HarmonyBefore(new string[] {"CarcassYieldTweaker"})]
            [HarmonyPriority(Priority.High)] 
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

        [HarmonyPatch(typeof(Panel_BodyHarvest), nameof(Panel_BodyHarvest.GetQuarterDurationMinutes))]
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
                if (__instance.m_Label_EstimatedTime != null)
                {
                  __instance.m_Label_EstimatedTime.text = Utils.GetExpandedDurationString(Mathf.RoundToInt(__result));
                }
                
            }
        }

        [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.GetModifiedCraftingDuration))]
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
        [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.Update))]
        public class Panel_Crafting_Update {
          private static void Prefix(Panel_Crafting __instance, out float __state){
            ToolsQuality.Log("Panel_Crafting_update +");
            __state = 0f;
            InProgressCraftItem wip = __instance.SelectedWIP;
            if (wip){
              __state = wip.m_PercentComplete;
            }
          }
          private static void Postfix(Panel_Crafting __instance, ref float __state){
            InProgressCraftItem wip = __instance.SelectedWIP;
            GearItem tool = __instance.m_RequirementContainer.GetSelectedTool();
            if (wip && tool){
              wip.m_PercentComplete = __state + ((wip.m_PercentComplete - __state) / ToolsQuality.ToolsQualityMod(tool));
            }
            ToolsQuality.Log("Panel_Crafting_update: " + __state + " " + wip?.m_PercentComplete.ToString());
          }

        }
    }
}