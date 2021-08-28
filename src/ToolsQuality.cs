using MelonLoader;
using UnityEngine;


namespace ToolsQuality
{
	public static class BuildInfo
	{
		public const string Name = "ToolsQuality"; // Name of the Mod.  (MUST BE SET)
		public const string Description = "Keep Your tools sharp."; // Description for the Mod.  (Set as null if none)
		public const string Author = "ttr"; // Author of the Mod.  (MUST BE SET)
		public const string Company = null; // Company that made the Mod.  (Set as null if none)
		public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
		public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
	}
	internal class ToolsQuality : MelonMod
	{

		public override void OnApplicationStart()
		{
			Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
			Settings.OnLoad();
		}

		public static float ToolsQualityMod(GearItem tool)
        {
			string tname = tool.m_GearName;
			float tcond = tool.GetNormalizedCondition() * 100;
			if ((tname == "GEAR_KnifeImprovised") || (tname == "GEAR_KnifeScrapMetal") || (tname == "GEAR_HatchetImprovised"))
			{
				if (tcond > Settings.options.ImpHighQpct) { return 1f; }
				else if (tcond <= Settings.options.ImpLowQpct) { return Settings.options.ImpLowQTime; }
				else {
					float TimeDiff = Settings.options.ImpLowQTime - 1f;
					float QualityRatio = 1f - Mathf.InverseLerp(Settings.options.ImpLowQpct, Settings.options.ImpHighQpct, tcond);
					return 1f + (TimeDiff * QualityRatio);
				}
			}
			else if ((tname == "GEAR_Hacksaw") || (tname == "GEAR_Knife") || (tname == "GEAR_Hatchet"))
			{
				if (tcond > Settings.options.ManBoostQpct) {

					float TimeDiff = 1f - Settings.options.ManLowQTime;
					float QualitryRatio = Mathf.InverseLerp(Settings.options.ManHighQpct, Settings.options.ManBoostQpct, tcond);
					return 1f - (TimeDiff * QualitryRatio);
				}
				else if (tcond > Settings.options.ManHighQpct) { return 1f; }
				else if (tcond <= Settings.options.ManLowQpct) { return Settings.options.ManLowQTime; }
				else
				{
					float TimeDiff = Settings.options.ManLowQTime - 1f;
					float QualityRatio = 1f - Mathf.InverseLerp(Settings.options.ManLowQpct, Settings.options.ManHighQpct, tcond);
					return 1f + (TimeDiff * QualityRatio);
				}
			}
			else
			{
				return 1f;
			}

		}
	}

}