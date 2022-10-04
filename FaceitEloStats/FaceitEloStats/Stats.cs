using System;

namespace FaceitEloStats
{
    class Stats
    {
        public static int maxGames = 1002; // for max games, btw, if maxGames == 1000 => real games might be 998, so if u need 1000 games => maxGames = 1002 
        public static int[] kills = new int[maxGames];
        public static int[] deaths = new int[maxGames];
        public static int[] assists = new int[maxGames];
        public static int[] hs = new int[maxGames];
        public static int[] elo = new int[maxGames];
        public static String[] result = new String[maxGames];
        public static int matches;
    }
}
