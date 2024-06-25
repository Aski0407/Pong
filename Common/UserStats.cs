namespace Common
{
    public struct UserStats //the struct for the scores of the players. contains the wins and losses.
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
