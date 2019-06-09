using ICities;

namespace ZoomIt
{
    public class ModInfo : IUserMod
    {
        public string Name => "Zoom It!";
        public string Description => "Allows to change min and max zoom level in-game.";

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            bool selected;
            float selectedValue;

            group = helper.AddGroup(Name);

            selectedValue = ModConfig.Instance.MinDistance;
            group.AddSlider("Minimum Distance", 0f, 40f, 5f, selectedValue, sel =>
            {
                ModConfig.Instance.MinDistance = sel;
                ModConfig.Instance.Save();
            });

            selectedValue = ModConfig.Instance.MaxDistance;
            group.AddSlider("Maximum Distance", 3000f, 27000f, 3000f, selectedValue, sel =>
            {
                ModConfig.Instance.MaxDistance = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.IgnoreBorders;
            group.AddCheckbox("Ignore Borders", selected, sel =>
            {
                ModConfig.Instance.IgnoreBorders = sel;
                ModConfig.Instance.Save();
            });
        }
    }
}