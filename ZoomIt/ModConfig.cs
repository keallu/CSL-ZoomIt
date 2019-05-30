namespace ZoomIt
{
    [ConfigurationPath("ZoomItConfig.xml")]
    public class ModConfig
    {
        public bool ConfigUpdated { get; set; }
        public float MinDistance { get; set; } = 25f;
        public float MaxDistance { get; set; } = 12000f;
        public bool IgnoreBorders { get; set; } = true;

        private static ModConfig instance;

        public static ModConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Configuration<ModConfig>.Load();
                }

                return instance;
            }
        }

        public void Save()
        {
            Configuration<ModConfig>.Save();
            ConfigUpdated = true;
        }
    }
}