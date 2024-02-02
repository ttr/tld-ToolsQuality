using ModSettings;
using System.Reflection;

namespace ToolsQuality
{
	internal class ToolsQualitySettings : JsonModSettings
	{
		[Section("Main Settings")]
		[Name("Branch Breaking Time Multiplier")]
		[Description("Adjusts the time multiplier for chopping or breaking branches. Recommended value: 0.5.")]
		[Slider(0.1f, 3f)]
		public float BreakBranchTimeMultiplier = 1f;
		
		[Name("Limb Chopping Time Multiplier")]
		[Description("Adjusts the time multiplier for chopping limbs. Recommended value: 0.5.")]
		[Slider(0.1f, 3f)]
		public float BreakLimbTimeMultiplier = 1f;
		
		[Name("Wood Pallet Chopping Time Multiplier")]
		[Description("Adjusts the time multiplier for chopping wood pallets. Recommended value: 0.5.")]
		[Slider(0.1f, 3f)]
		public float BreakPalletTimeMultiplier = 1f;
		
		[Name("Animal Harvesting Time Multiplier")]
		[Description("Adjusts the time multiplier for animal harvesting.")]
		[Slider(0.1f, 3f)]
		public float HarvestTimeMultiplier = 1f;
		
		[Name("Quartering Time Multiplier")]
		[Description("Adjusts the time multiplier for quartering during harvesting.")]
		[Slider(0.1f, 3f)]
		public float QuarterTimeMultiplier = 1f;
		
		[Name("Tool Quality Impact")]
		[Description("Enables or disables the feature where a tool's lower condition increases the action time. Disabled by default.")]
		public bool ToolsQualityEnabled = false;
		
		[Section("Manufactured Tools")]
		[Name("Low-Quality Condition Threshold")]
		[Description("The condition threshold below which a tool is considered low quality and performs with an increased time multiplier.")]
		[Slider(0, 100, 101)]
		public int ManLowQpct = 10;
		
		[Name("Low-Quality Time Multiplier")]
		[Description("The time multiplier for tools in bad condition. Recommended value: 3-4.")]
		[Slider(1f, 10f)]
		public int ManLowQTime = 3;
		
		[Name("High-Quality Condition Threshold")]
		[Description("The condition threshold above which a tool is considered high quality and incurs no penalty.")]
		[Slider(0, 100, 101)]
		public int ManHighQpct = 85;
		
		[Name("Boost Quality Condition Threshold")]
		[Description("The condition threshold above which a tool receives an efficiency bonus. Set to 100 to disable.")]
		[Slider(0, 100, 101)]
		public int ManBoostQpct = 100;
		
		[Name("Boost Quality Time Multiplier")]
		[Description("The time multiplier for tools in perfect condition. Recommended value: 0.7 (if used).")]
		[Slider(0.1f, 1f)]
		public float ManBoostQTime = 0.7f;
		
		[Section("Hacksaw")]
		[Name("Low-Quality Condition Threshold")]
		[Description("The condition threshold below which a hacksaw is considered low quality and performs with an increased time multiplier.")]
		[Slider(0, 100, 101)]
		public int HackLowQpct = 0;
		
		[Name("Low-Quality Time Multiplier")]
		[Description("The time multiplier for hacksaws in bad condition. Recommended value: 3-4.")]
		[Slider(1f, 10f)]
		public int HackLowQTime = 3;
		
		[Name("High-Quality Condition Threshold")]
		[Description("The condition threshold above which a hacksaw is considered high quality and incurs no penalty.")]
		[Slider(0, 100, 101)]
		public int HackHighQpct = 70;
		
		[Section("Improvised Tools")]
		[Name("Low-Quality Condition Threshold")]
		[Description("The condition threshold below which an improvised tool is considered low quality and performs with an increased time multiplier.")]
		[Slider(0, 100, 101)]
		public int ImpLowQpct = 0;
		
		[Name("Low-Quality Time Multiplier")]
		[Description("The time multiplier for improvised tools in bad condition. Recommended value: 2-3.")]
		[Slider(1f, 10f)]
		public int ImpLowQTime = 2;
		
		[Name("High-Quality Condition Threshold")]
		[Description("The condition threshold above which an improvised tool is considered high quality and incurs no penalty.")]
		[Slider(0, 100, 101)]
		public int ImpHighQpct = 100;
		protected override void OnChange(FieldInfo field, object oldValue, object newValue)
		{
			RefreshFields();
		}

		internal void RefreshFields()
		{
			if (ManBoostQpct< ManHighQpct)
			{
				ManBoostQpct = ManHighQpct;
			}
			if (ManHighQpct < ManLowQpct)
			{
				ManHighQpct = ManLowQpct;
			}
			if (ImpHighQpct < ImpLowQpct)
			{
				ImpHighQpct = ImpLowQpct;
			}
			if (ToolsQualityEnabled)
            {
				SetFieldVisible(nameof(ManLowQpct), true);
				SetFieldVisible(nameof(ManLowQTime), true);
				SetFieldVisible(nameof(ManHighQpct), true);
				SetFieldVisible(nameof(ManBoostQpct), true);
				SetFieldVisible(nameof(ManBoostQTime), true);
				SetFieldVisible(nameof(ImpLowQpct), true);
				SetFieldVisible(nameof(ImpLowQTime), true);
				SetFieldVisible(nameof(ImpHighQpct), true);
			}
			else
            {
				SetFieldVisible(nameof(ManLowQpct), false);
				SetFieldVisible(nameof(ManLowQTime), false);
				SetFieldVisible(nameof(ManHighQpct), false);
				SetFieldVisible(nameof(ManBoostQpct), false);
				SetFieldVisible(nameof(ManBoostQTime), false);
				SetFieldVisible(nameof(ImpLowQpct), false);
				SetFieldVisible(nameof(ImpLowQTime), false);
				SetFieldVisible(nameof(ImpHighQpct), false);
			}
			RefreshGUI();
		}
	}
	internal static class Settings
	{
		public static ToolsQualitySettings options;
		public static void OnLoad()
		{
			options = new ToolsQualitySettings();
			options.RefreshFields();
			options.AddToModSettings("Tools Quality Settings");
		}
	}
}
