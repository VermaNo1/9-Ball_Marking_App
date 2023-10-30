using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marking_App
{
    public class Match
    {
        private static string _player1, _player2, _lagPlayer, _currentPlayer;

        private static int _p1Skill, _p2Skill, _p1PointsRequired, _p2PointsRequired, _p1CurrentPoints, _p2CurrentPoints;

        private static int innings, rack, deadballs;

        public int Innings
        {
            get => innings;
            set => innings = value;
        }

        public int Rack
        {
            get => rack;
            set => rack = value;
        }

        public int Deadballs
        {
            get { return deadballs; }
            set { deadballs = value; }
        }

        public string Player1
        {
            get => _player1;
            set => _player1 = value;
        }

        public string Player2
        {
            get => _player2;
            set => _player2 = value;
        }

        public string LagPlayer
        {
            get => _lagPlayer;
            set => _lagPlayer = value;
        }

        public string CurrentPlayer
        {
            get=>_currentPlayer;
            set => _currentPlayer = value;
        }

        public int P1Skill
        {
            get => _p1Skill;
            set => _p1Skill = value;
        }

        public int P2Skill
        {
            get => _p2Skill;
            set => _p2Skill = value;
        }

        public int P1PointsRquired
        {
            get => _p1PointsRequired;
            set => _p1PointsRequired = value;
        }

        public int P2PointsRquired
        {
            get => _p2PointsRequired;
            set => _p2PointsRequired = value;
        }

        public int P1CurrentPoints
        {
            get => _p1CurrentPoints;
            set => _p1CurrentPoints = value;
        }

        public int P2CurrentPoints
        {
            get => _p2CurrentPoints;
            set => _p2CurrentPoints = value;
        }

       /* public Match(string player1, string player2, string lagPlayer, int p1Skill, int p2Skill, int p1PointsRequired, int p2PointsRequired)
        {
            Player1 = player1;
            Player2 = player2;
            LagPlayer = lagPlayer;
            P1Skill = p1Skill;
            P2Skill = p2Skill;
            P1PointsRquired = p1PointsRequired;
            P2PointsRquired = p2PointsRequired;
            P1CurrentPoints = 0;
            P2CurrentPoints = 0;
            Innings = 0;
            Rack = 0;
            Deadballs = 0;
        }*/

        public Match()
        {
            /*P1CurrentPoints = 0;
            P2CurrentPoints = 0;
            Innings = 0;
            Rack = 0;
            Deadballs = 0;*/
            //gameStack = new Stack<GameInfo>();            
        }

        //public Stack<GameInfo> gameStack;
    }

    
}
