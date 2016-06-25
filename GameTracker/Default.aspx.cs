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
        /**
         * <summary>
         * This method querys the database and gets the game info
         * from the database and gets the games from the week
         * </summary>
         * 
         */
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

        /**
         * <summary>
         * This method subtracts 7 days from the dateRange DateTime onclick
         * </summary>
         * 
         */
        protected void PreviousWeek_Click(object sender, EventArgs e)
        {
            //take away 7 days from the date
            this.days = days - 7;
            dateRange = tempDate.AddDays(days);
            this.GetGames();


        }
        /**
         * <summary>
         * This method returns the current date onclick
         * </summary>
         * 
         */
        protected void CurrentWeek_Click(object sender, EventArgs e)
        {
            //get the current weeks games
            this.dateRange = DateTime.Today;
            this.GetGames();
            
        }

        /**
         * <summary>
         * This method adds 7 days to the dateRange DateTime onclick
         * </summary>
         * 
         */
        protected void NextWeek_Click(object sender, EventArgs e)
        {
            //add 7 days to the date
            this.days = days + 7;
            dateRange = tempDate.AddDays(days);
            this.GetGames();

        }

        /**
         * <summary>
         * This method returns the first day of the week using the current culture
         * </summary>
         * 
         */
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, cultureInfo);
        }

        /**
         * <summary>
         * This method returns the first day of the week
         * </summary>
         */
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayOfWeek = dayInWeek.Date;
            while (firstDayOfWeek.DayOfWeek != firstDay)
                firstDayOfWeek = firstDayOfWeek.AddDays(-1);

            return firstDayOfWeek;
        }
    }
}