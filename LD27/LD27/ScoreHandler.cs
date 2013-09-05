using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LD27
{
    public class Score
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }

        public float BestTime { get; set; }
    }

    public static class ScoreHandler
    {
        public static void SaveScore(string deviceId, float time)
        {
            Score score = new Score { DeviceId = deviceId, BestTime = time };
            Game1.MobileService.GetTable<Score>().InsertAsync(score);
        }

        public static bool LoadScore(string deviceId, float time)
        {
           var results = Game1.MobileService.GetTable<Score>().Where(score => score.DeviceId == deviceId).ToListAsync();

            return true;
        }
    }
}
