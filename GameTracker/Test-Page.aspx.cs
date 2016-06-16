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

        
        protected void Page_Load(object sender, EventArgs e)
        {
            //connect to the database
            using (DefaultContent db = new DefaultContent())
            {
                //get todays date
                DateTime dateRange = DateTime.Today;
                //set up a query that selects only the proper date to load into the array
                IQueryable<baseballgametracker> games = from allgames in db.baseballgametrackers
                                                        where allgames.gameDate < dateRange
                                                        select allgames;

                //set up gamesarray to put data into
                    gamesArray = games.ToArray();

                }

            
        }
    }
}