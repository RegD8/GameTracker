using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connect to EF DB
using GameTracker.Models;
using System.Web.ModelBinding;


namespace GameTracker
{
    public partial class Test_Page : System.Web.UI.Page
    {
        //set up game array
        protected baseballgametracker[] gamesArray;
        //set up date variable
        protected DateTime dateRange;
        protected int days = 0;
        protected DateTime currentDate = DateTime.Today;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if page is being loaded for the first time
            if (!IsPostBack)
            {
                //load todays date on page load
                dateRange = currentDate;
                //get the games
                this.GetGames();
            }
        }

        protected void GetGames()
        {
            //connect to the database
            using (DefaultContent db = new DefaultContent())
            {
                //set up a query that selects only the proper date to load into the array
                IQueryable<baseballgametracker> games = from allgames in db.baseballgametrackers
                                                        where allgames.gameDate < dateRange
                                                        select allgames;

                //set up gamesarray to put data into
                gamesArray = games.ToArray();

            }
        }

        protected void PreviousWeek_Click(object sender, EventArgs e)
        {
            //take away 7 days from the date
            days = (days - 7);
            dateRange = currentDate.AddDays(days);
            this.GetGames();
        }

        protected void NextWeek_Click(object sender, EventArgs e)
        {
            //add 7 days to the date
            days = days + 7;
            dateRange = currentDate.AddDays(days);
            this.GetGames();
        }
    }
}