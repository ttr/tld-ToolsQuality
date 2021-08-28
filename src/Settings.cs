using ModSettings;

namespace ToolsQuality
{
	internal class ToolsQualitySettings : JsonModSettings
	{
		[Section("Base timers")]
		[Name("Time multiplier when breaking branches")]
        [Description("Time multiplier when chopping or breaking branches - recommened 0.5")]
        [Slider(0.1f, 3f)]
        public float BreakBranchTimeMultiplier = 0.5f;

        [Name("Time multiplier when chopping limbs")]
        [Description("Time multiplier when chopping limbs - recommened 0.5")]
        [Slider(0.1f, 3f)]
        public float BreakLimbTimeMultiplier = 0.5f;

		[Name("Time multiplier when harvesting")]
		[Description("Time multiplier when harvesting")]
		[Slider(0.1f, 3f)]
		public float HarvestTimeMultiplier = 1f;

		[Section("Manufactured tools")]
		[Name("Low Qulaity condition point")]
		[Description("Below (incluisive) this condition tool will be perfoemin with mutiplier of next value.")]
		[Slider(0, 100, 101)]
		public int ManLowQpct = 10;

		[Name("Low Qulaity time mutiplier")]
		[Description("Time mutiplier for bad condtion")]
		[Slider(1f, 5f)]
		public int ManLowQTime = 3;

		[Name("High Qulaity condition point")]
		[Description("Above (incluisive) this condition, tool will not have penalty")]
		[Slider(0, 100, 101)]
		public int ManHighQpct = 85;

		[Name("Boost Qulaity condition point")]
		[Description("Above this point, tool will have efficiency bonus, used with next value. Set to 100 to disable.")]
		[Slider(0, 100, 101)]
		public int ManBoostQpct = 100;

		[Name("Boost Qulaity time mutiplier")]
		[Description("")]
		[Slider(0.1f, 1f)]
		public float ManBoostQTime = 0.7f;

		[Section("Improvised tools")]
		[Name("Low Qulaity condition point")]
		[Description("Below (incluisive) this condition tool will be perfoemin with mutiplier of next value.")]
		[Slider(0, 100, 101)]
		public int ImpLowQpct = 0;

		[Name("Low Qulaity time mutiplier")]
		[Description("Time mutiplier for bad condtion")]
		[Slider(1f, 5f)]
		public int ImpLowQTime = 2;

		[Name("High Qulaity condition point")]
		[Description("Above (incluisive) this condition, tool will not have penalty")]
		[Slider(0, 100, 101)]
		public int ImpHighQpct = 100;

	}
	internal static class Settings
	{
		public static ToolsQualitySettings options;
		public static void OnLoad()
		{
			options = new ToolsQualitySettings();
			options.AddToModSettings("Tools Quality Settings");
		}
	}
}