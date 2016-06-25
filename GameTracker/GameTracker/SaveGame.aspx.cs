using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GameTracker.Models;
using System.Web.ModelBinding;

namespace GameTracker
{
    public partial class Add_Game : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetGame();
            }
        }


        protected void GetGame()
        {
            int gameID = Convert.ToInt32(Request.QueryString["gameID"]);

            using (DefaultContent db = new DefaultContent())
            {
                baseballgametracker updateGame = (from game in db.baseballgametrackers
                                   where game.gameID == gameID
                                   select game).FirstOrDefault();
                // map the game properties to the form controls
                if (updateGame != null)
                {
                    homeTeamName.Text = updateGame.homeTeamName;
                    awayTeamName.Text = updateGame.awayTeamName;
                    homeScore.Text = updateGame.homeScore.ToString();
                    awayScore.Text = updateGame.awayScore.ToString();
                    description.Text = updateGame.description;
                    gameDateTextBox.Text = updateGame.gameDate.ToString();
                    spectators.Text = updateGame.spectators;
                } 
            }  
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (DefaultContent db = new DefaultContent())
            {
                
                baseballgametracker newGame = new baseballgametracker();

                int gameID = 0;

                if (Request.QueryString.Count > 0) // our URL has a GameID in it
                {
                    // get the id from the URL
                    gameID = Convert.ToInt32(Request.QueryString["gameID"]);

                    // get the current game from EF DB
                    newGame = (from game in db.baseballgametrackers
                                  where game.gameID == gameID
                                  select game).FirstOrDefault();
                }

                // add form data to the new game
                newGame.homeTeamName = homeTeamName.Text;
                newGame.awayTeamName = awayTeamName.Text;
                newGame.homeScore = Convert.ToInt32(homeScore.Text);
                newGame.awayScore = Convert.ToInt32(awayScore.Text);
                newGame.description = description.Text;
                newGame.gameDate = Convert.ToDateTime(gameDateTextBox.Text);
                newGame.spectators = spectators.Text;
                
                // use LINQ to ADO.NET to add / insert new game into the database

                if (gameID == 0)
                {
                    db.baseballgametrackers.Add(newGame);
                }
                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated games view page
                Response.Redirect("/GameTracker/ViewGames.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to dashboard page
            Response.Redirect("/GameTracker/dashboard.aspx");
        }
    }
}