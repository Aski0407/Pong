namespace Common
{
    public struct UserStats
    {
        public int gamesWon;
        public int gamesLost;

        public UserStats(int gamesWon, int gamesLost)
        {
            this.gamesWon = gamesWon;
            this.gamesLost = gamesLost;
        }
    }
}
