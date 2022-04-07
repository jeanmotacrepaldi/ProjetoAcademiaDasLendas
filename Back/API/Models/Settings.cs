namespace API.Models
{
    public class Settings
    {
        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                }
                return instance;
            }
        }
        public string Secret { get; set; }  
    }
}
