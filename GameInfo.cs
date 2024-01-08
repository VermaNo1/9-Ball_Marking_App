using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marking_App
{
    public enum BallMade
        {
            noBall = 0,
            ball_1s = 1, ball_2s = 2, ball_3s = 3, ball_4s = 4, ball_5s = 5, ball_6s = 6,
            ball_7s = 7, ball_8s = 8, ball_9s = 9, ball_10s = 10, ball_11s = 11,
            ball_12s = 12, ball_13s = 13, ball_14s = 14, ball_15s = 15
        }

    public enum ActionDone
        {
            pocketed,
            dead,
            safty,
            breakShot
        }
    
    public class GameInfo
    {
        public BallMade ball {  get; set; }
        public ActionDone done { get; set; }
        public string shooter;
             

        public GameInfo(string b,ActionDone d, string s) 
        {
            ball = (BallMade)Enum.Parse(typeof(BallMade), b);
            //done = (ActionDone)Enum.Parse(typeof(ActionDone), d);
            done = d;
            shooter = s;
           
        }

        
    }

}
