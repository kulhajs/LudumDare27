using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.Phone.Notification;

namespace LD27 
{
    public class Score
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }

        public float BestTime { get; set; }

        public string Channel { get; set; }
    }

    public static class ScoreHandler
    {
        public static void SaveScore(string deviceId, float time)
        {
            Score score = new Score { DeviceId = deviceId, BestTime = time, Channel = Game1.CurrentChannel.ChannelUri.ToString() };
            Game1.MobileService.GetTable<Score>().InsertAsync(score);
        }

        public static bool LoadScore(string deviceId, float time)
        {
            return false;
        }
    }
}
