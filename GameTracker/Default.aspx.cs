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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime theDate = DateTime.Today;
            todaysDate.Text = theDate.ToString("yyyy-MM-dd");
            
            ///load the page with the current weeks game data
            if (!IsPostBack)
            {
                //get the game data from the table
                this.GetGames();
            }
        }

        /**
         * <summary>
         * This method gets the game data from the database.
         * </summary>
         * @method GetGames
         * @returns {void}
         */

        protected void GetGames()
        {
            using (DefaultContent db = new DefaultContent())
            {
                var Games = (from allgames in db.baseballgametrackers
                             select allgames).Take(1);

                GamesGridView.DataSource = Games.ToList();
                GamesGridView.DataBind();

                GamesGridView1.DataSource = Games.ToList();
                GamesGridView1.DataBind();

                GamesGridView2.DataSource = Games.ToList();
                GamesGridView2.DataBind();

                GamesGridView3.DataSource = Games.ToList();
                GamesGridView3.DataBind();

                GamesGridView4.DataSource = Games.ToList();
                GamesGridView4.DataBind();

            }
        }


        protected void GetGameInfo()
        {
            using (DefaultContent db = new DefaultContent())
            {
                //get the game info from the database that matches the date
                var GameInfo = (from allgames in db.baseballgametrackers
                             select allgames).Take(1);

                //assign the game database info to variables
                
                

            }
        }

        protected void GamesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        /**
         * <summary>
         * This method sets a row class for each row as it's created.
         * </summary>
         * @method GamesGridView_RowCreate
         * @returns {void}
         */
        protected void GamesGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            int increment = 0;
            e.Row.CssClass = "row-" + increment++;

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                int index = 0;
                foreach (TableCell cell in e.Row.Cells)
                {
                    index++;
                    cell.CssClass = "cell-" + index;
                }

            }
        }
        /**
         * <summary>
         * This method loads the games from the previous week
         * </summary>
         * @method PreviousWeek_Click
         * @returns {void}
         */
        protected void PreviousWeek_Click(object sender, EventArgs e)
        {

        }
        /**
         * <summary>
         * This method loads the games from the next week
         * </summary>
         * @method NextWeek_Click
         * @returns {void}
         */
        protected void NextWeek_Click(object sender, EventArgs e)
        {

        }
    }
}