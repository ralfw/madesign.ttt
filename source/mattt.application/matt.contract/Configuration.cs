namespace matt.contract
{
    public class Configuration
    {
        private const int DIMENSION = 10;
        private const int WIN_DIMENSION = 5;
        private const int WINNING_SPACE = DIMENSION - WIN_DIMENSION;
        private const bool IS_GRAVITY_ON = false;

        private static Configuration _configuration;


        private Configuration()
        {
            Dimension = DIMENSION;
            WinDimension = WIN_DIMENSION;
            WinningSpace = WINNING_SPACE;
            IsGravityOn = IS_GRAVITY_ON;
        }

        public static Configuration Instance
        {
            get
            {
                return _configuration ?? (_configuration = new Configuration());
            }
        }

        public int Dimension { get; set; }
        public int WinDimension { get; set; }
        public int WinningSpace { get; set; }

        public bool IsGravityOn { get; set; }
    }
}
