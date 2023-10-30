using Android.App;
using Android.OS;
using Java.Lang;
using Java.Util.Functions;
using System;
using System.Resources;

namespace Marking_App
{
   
       
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Navigation.PushAsync(new GamePage());//delete and uncomment below
            p1rb.IsEnabled = false;
            p2rb.IsEnabled = false;
        }

       Match match1=new();

        private void Rb_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton rbBTN = (RadioButton)sender;
            /*if ( string.IsNullOrWhiteSpace(rbBTN.Content.ToString() ) ) 
            {
                emptyPN(rbBTN.StyleId);
                p1rb.IsEnabled = false;
                p2rb.IsEnabled = false;
                return;
            }*/
            match1.LagPlayer = rbBTN.Content.ToString();            
        }

        private static int GetPoints(int Skill)
        {
            int points=new();
            try
            {

                switch (Skill)
                {
                    case 1:
                        points= 14;
                        break;
                    case 2:
                        points = 19;
                        break;
                    case 3:
                        points = 25;
                        break;
                    case 4:
                        points = 31;
                        break;
                    case 5:
                        points = 38;
                        break;
                    case 6:
                        points = 46;
                        break;
                    case 7:
                        points = 55;
                        break;
                    case 8:
                        points = 65;
                        break;
                    case 9:
                        points = 75;
                        break;
                }
            }
            catch 
            {
                throw new System.Exception("Unexpected error");
                
            }
            return points;
        }

        private void Skill_ValueChanged(object sender, ValueChangedEventArgs e) //Set the skill level and points for player
        {
            int skill = ((int)e.NewValue);
            int points = MainPage.GetPoints(skill);
            Slider slider = (Slider)sender;
            //Setup points and skill for respective players
            if (slider.StyleId== "P1_Skill_slider")
            {
                P1_Skill_slider.Value = skill;
                p1_s_lbl.Text = "Skill : " + skill.ToString();
                p1_p_lbl.Text = "Points : " + points.ToString();
                match1.P1Skill= skill;
                match1.P1PointsRquired = points;
                return;                
            }
            else if (slider.StyleId== "P2_Skill_slider")
            {
                P2_Skill_slider.Value = skill;
                p2_s_lbl.Text = "Skill : " + skill.ToString();
                p2_p_lbl.Text = "Points : " + points.ToString();
                match1.P2Skill = skill;
                match1.P2PointsRquired = points;
                return;
            }
        }

        private async void OnCountinueClicked(object sender, EventArgs e)
        {
            if (match1.LagPlayer is null or "")
            {
                await DisplayAlert("Select Lag Winner", "Please select the winner of lag", "OK");
            }
            else
            {
                await Navigation.PushAsync(new GamePage(match1));

            }
        }

        private void Player_textChanged(object sender, TextChangedEventArgs e)
        {
            Entry player = (Entry)sender;

            if (player.StyleId == "p1name_txt")
            {
/*                if (string.IsNullOrWhiteSpace(player.Text))
                {
                    emptyPN(player.StyleId);
                    return;
                }*/
                p1rb.Content = player.Text;
                p1rb.IsEnabled = true;
                match1.Player1 = player.Text;
            }
            else if (player.StyleId == "p2name_txt")
            {
                /*if (string.IsNullOrWhiteSpace(player.Text))
                {
                    emptyPN(player.StyleId);
                    return; 
                }*/
                p2rb.Content = player.Text;
                p2rb.IsEnabled = true;
                match1.Player2 = player.Text;
            }
        }

        /*public void emptyPN(string s)
        {
            string v;
            v= s is "p1name_txt" or "p1rb" ? "Player 1" : "Player 2";
            DisplayAlert(v+" not given", "Please enter "+v, "OK");
            if (v == "Player 1")
            { p1name_txt.Focus(); }
            else { p2name_txt.Focus(); }
        }*/
    }
}