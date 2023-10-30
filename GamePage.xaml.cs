using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Marking_App;


public partial class GamePage : ContentPage
{
    public GamePage()
    {
        InitializeComponent();
    }

    public GamePage(Match m)
    {
        InitializeComponent();
        LoadGame(m);
    }

    Stack<GameInfo> gameInfoS = new Stack<GameInfo>();

    //Popullate Match Info
    public void LoadGame(Match match)
    {
        //Load Player1 info
        P1_Name_lbl.Text = match.Player1;
        P1_Skill_lbl.Text = "Skill: " + match.P1Skill.ToString();
        P1_Points_lbl.Text = "Points: " + match.P1CurrentPoints.ToString() + "/" + match.P1PointsRquired.ToString();
        //Load Player2 Info
        P2_Name_lbl.Text = match.Player2;
        P2_Skill_lbl.Text = "Skill: " + match.P2Skill.ToString();
        P2_Points_lbl.Text = "Points: " + match.P2CurrentPoints.ToString() + "/" + match.P2PointsRquired.ToString();

        if (match.LagPlayer == match.Player1)
        {
            P1_Turn_lbl.IsVisible = true;
        }
        else if (match.LagPlayer == match.Player2)
        { P2_Turn_lbl.IsVisible = true;}

        Innings_lbl.Text = "Innings: " + match.Innings.ToString();
        Rack_lbl.Text = "Rack: " + match.Rack.ToString();
        DeadBall_lbl.Text = "Dead Balls: " + match.Deadballs.ToString();
        match.CurrentPlayer = match.LagPlayer; 

    }

    private void BallPocketed(object sender, EventArgs e)
    {
        Match m = new Match();
        ImageButton imageButton = new ImageButton();
        imageButton = sender as ImageButton;
        imageButton.IsEnabled = false;
        //DisplayAlert("Message",imageButton.StyleId + " image button clicked","ok");
        /*
         * Test code for the game stack
         */
        GameInfo gameInfo = new GameInfo(imageButton.StyleId, ActionDone.pocketed, m.CurrentPlayer);
        gameInfoS.Push(gameInfo);

        AddPoints(1);
    }



    private void Undo_Last(object sender, EventArgs e)
    {
        try
        {
            Match m = new Match();
            GameInfo info = gameInfoS.Pop();
            string s = info.ball.ToString();
            string a = info.done.ToString();
            if (info != null)
            {
                ImageButton imgbtn = this.FindByName<ImageButton>(s);
                imgbtn.Source = s;
                if (a.ToString() == "dead")
                {
                    imgbtn.IsEnabled = false;                    
                    m.Deadballs--;
                    DeadBall_lbl.Text = "Dead Balls: " + m.Deadballs.ToString();
                    AddPoints(1);
                }
                else
                {
                    imgbtn.IsEnabled = true;
                    AddPoints(-1);
                }
            }
        }
        catch
        {
        }

    }

    private void Dead_Ball(object sender, EventArgs e)
    {
        try
        {
            Match m = new Match();
            GameInfo info = gameInfoS.Peek();
            string s = info.ball.ToString();
            if (info != null)
            {
                ImageButton imgbtn = this.FindByName<ImageButton>(s);
                //(ImageButton)imgbtn.so
                //imgbtn.source = "scratch";
                imgbtn.IsEnabled = false;
                imgbtn.Source = "scratch";
                //(ImageButton)fi
                //(ImageButton)FindByName(info.ball.ToString()).source = "scratch";
            }
            GameInfo gameInfo = new GameInfo(s, ActionDone.dead, m.CurrentPlayer);
            gameInfoS.Push(gameInfo);
            m.Deadballs++;
            DeadBall_lbl.Text = "Dead Balls: " + m.Deadballs.ToString();
            AddPoints(-1);
        }
        catch (Exception)
        {

            throw;
        }

    }

    private void Safty_Played(object sender, EventArgs e)
    {

    }

    private void Change_Shooter(object sender, EventArgs e)
    {
        Match m = new Match();
        if (m.CurrentPlayer == m.Player2)
        {
            P1_Turn_lbl.IsVisible = true;
            P2_Turn_lbl.IsVisible = false;
            m.CurrentPlayer = m.Player1;
        }
        else
        {
            if (m.CurrentPlayer == m.Player1)
            {
                P1_Turn_lbl.IsVisible = false;
                P2_Turn_lbl.IsVisible = true;
                m.CurrentPlayer = m.Player2;
            }
        }
    }

    private void AddPoints(int i)
    {
        Match m = new Match();
        if (m.CurrentPlayer == m.Player1)
        {
            m.P1CurrentPoints += i;
            P1_Points_lbl.Text = "Points: " + m.P1CurrentPoints.ToString() + "/" + m.P1PointsRquired.ToString();
        }
        else
        {
            m.P2CurrentPoints += i;
            P2_Points_lbl.Text = "Points: " + m.P2CurrentPoints.ToString() + "/" + m.P2PointsRquired.ToString();
        }

    }
}