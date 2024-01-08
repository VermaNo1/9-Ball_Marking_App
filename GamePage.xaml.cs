using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.Intrinsics.X86;
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
        UpdateInfo();
        //Load Player1 info
        P1_Name_lbl.Text = match.Player1;
        P1_Skill_lbl.Text = "Skill: " + match.P1Skill.ToString();
        P1_Points_lbl.Text = "Points: " + match.P1CurrentPoints.ToString() + "/" + match.P1PointsRquired.ToString();
        //Load Player2 Info
        P2_Name_lbl.Text = match.Player2;
        P2_Skill_lbl.Text = "Skill: " + match.P2Skill.ToString();
        P2_Points_lbl.Text = "Points: " + match.P2CurrentPoints.ToString() + "/" + match.P2PointsRquired.ToString();
        match.P1CurrentPoints = 0;
        match.P2CurrentPoints = 0;
        match.Innings = 0;
        match.Rack = 1;
        match.Deadballs = 0;
        if (match.LagPlayer == match.Player1)
        {
            P1_Turn_lbl.IsVisible = true;
        }
        else if (match.LagPlayer == match.Player2)
        { P2_Turn_lbl.IsVisible = true; }

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
        if (imageButton.StyleId == "ball_9s")
        {
            AddPoints(2, m.CurrentPlayer);
            StartNewGame();
        }
        else
        {
            AddPoints(1, m.CurrentPlayer);
        }
        DeadballBTN.IsEnabled = true;
    }

    private void Undo_Last(object sender, EventArgs e)
    {
        try
        {
            Match m = new Match();
            GameInfo info = gameInfoS.Pop();
            string b = info.ball.ToString();
            string a = info.done.ToString();
            string s = info.shooter;
            if (info != null)
            {
                ImageButton imgbtn = this.FindByName<ImageButton>(b);
                imgbtn.Source = b;
                if (a.ToString() == "dead")
                {
                    imgbtn.IsEnabled = false;
                    m.Deadballs--;
                    AddPoints(1, s);
                    DeadballBTN.IsEnabled = true;
                }
                else
                {
                    imgbtn.IsEnabled = true;
                    if (b == "ball_9s")
                    {
                        AddPoints(-2, s);
                    }
                    else
                    {
                        AddPoints(-1, s);
                    }

                }
            }
        }
        catch
        {
        }
        UpdateInfo();
    }

    private void Dead_Ball(object sender, EventArgs e)
    {
        try
        {
            Match m = new Match();
            GameInfo info = gameInfoS.Peek();
            string b = info.ball.ToString();
            string a = info.done.ToString();
            string s = info.shooter;
            if (info != null)
            {
                if (b == "ball_9s")
                {
                    AddPoints(-2, s);
                    ball_9s.IsEnabled = true;
                }
                else
                {
                    ImageButton imgbtn = this.FindByName<ImageButton>(b);
                    imgbtn.IsEnabled = false;
                    imgbtn.Source = "scratch";
                    GameInfo gameInfo = new GameInfo(b, ActionDone.dead, s);
                    gameInfoS.Push(gameInfo);
                    m.Deadballs++;
                    AddPoints(-1, s);
                }

            }
        }
        catch (Exception)
        {

            throw;
        }
        DeadballBTN.IsEnabled = false;
        UpdateInfo();
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
        //UpdateInfo();
    }

    private void AddPoints(int i, string s)
    {
        Match m = new Match();
        if (s == m.Player1)
        {
            m.P1CurrentPoints += i;
        }
        else
        {
            m.P2CurrentPoints += i;
        }
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        Match m = new Match();
        P1_Points_lbl.Text = "Points: " + m.P1CurrentPoints.ToString() + "/" + m.P1PointsRquired.ToString();
        P2_Points_lbl.Text = "Points: " + m.P2CurrentPoints.ToString() + "/" + m.P2PointsRquired.ToString();
        Innings_lbl.Text = "Innings: " + m.Innings.ToString();
        Rack_lbl.Text = "Racks: " + m.Rack.ToString();
        DeadBall_lbl.Text = "DeadBalls: " + m.Deadballs.ToString();
    }

    private async void StartNewGame()
    {
        Match m = new Match();
        if (await (DisplayAlert("New Rack", "9 Ball pocketed! Start new Rack?", "OK", "Cancel")))
        {
            m.Rack++;
            for (int i = 1; i <= 9; i++)
            {
                ImageButton img = this.FindByName<ImageButton>("ball_" + i.ToString() + "s");
                img.IsEnabled = true;
            }

        }
        else
        {
            Undo_Last(this, EventArgs.Empty);
        }
        UpdateInfo();
    }
}