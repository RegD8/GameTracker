using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connect to EF DB
using GameTracker.Models;
using System.Web.ModelBinding;

//needed for date
using System.Globalization;

namespace GameTracker
{
    public partial class Home : System.Web.UI.Page
    {
        //set up game array
        protected baseballgametracker[] gamesArray;
        //set up date variable
        protected DateTime dateRange;
        public int days = 0;
        protected DateTime currentDate = DateTime.Today;
        protected DateTime tempDate = DateTime.Today;
        protected DateTime weekOfGame;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if page is being loaded for the first time
            if (!IsPostBack)
            {

                //load todays date on page load
                dateRange = DateTime.Today;
                //get the games
                this.GetGames();

                
            }
            
        }

        protected void GetGames()
        {

            //get the sunday of the week of the game
            weekOfGame = GetFirstDayOfWeek(dateRange);
            //set the before date query
            DateTime before = weekOfGame.AddDays(7);
            


            //connect to the database
            using (DefaultContent db = new DefaultContent())
            {
                //set up a query that selects only the proper date to load into the array
                IQueryable<baseballgametracker> games = from allgames in db.baseballgametrackers
                                                        where allgames.gameDate < before
                                                        where allgames.gameDate > weekOfGame
                                                        
                                                        select allgames;

                
                //set up gamesarray to put data into
                gamesArray = games.ToArray();

            }
        }

        protected void PreviousWeek_Click(object sender, EventArgs e)
        {
            //take away 7 days from the date
            this.days = days - 7;
            dateRange = tempDate.AddDays(days);
            this.GetGames();


        }

        protected void CurrentWeek_Click(object sender, EventArgs e)
        {
            //get the current weeks games
            this.dateRange = DateTime.Today;
            this.GetGames();
            
        }


        protected void NextWeek_Click(object sender, EventArgs e)
        {
            //add 7 days to the date
            this.days = days + 7;
            dateRange = tempDate.AddDays(days);
            this.GetGames();

        }

        protected int Next_Week()
        {
            this.days = days + 7;
            return this.days;
        }

        /// <summary>
        /// Returns the first day of the week that the specified
        /// date is in using the current culture. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }
    }
}