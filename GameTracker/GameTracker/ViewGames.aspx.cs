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
    public partial class View_Games : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the games grid
            if (!IsPostBack)
            {       
                // Get the game data
                this.GetGames();
            }
        }

        /**
         * <summary>
         * This method gets the game data from the DB
         * </summary>
         * 
         * @method GetGames
         * @returns {void}
         */
        protected void GetGames()
        {
            // connect to EF
            using (DefaultContent db = new DefaultContent())
            {

                // query the Games Table using EF and LINQ
                var Games = (from allGames in db.baseballgametrackers
                                select allGames);

                // bind the result to the GridView
                AllGamesGridView.DataSource = Games.AsQueryable().ToList();
                AllGamesGridView.DataBind();
            }
        }

        /**
         * <summary>
         * This event handler deletes a student from the db using EF
         * </summary>
         * 
         * @method GamesGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         */
        protected void GamesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected gameID using the Grid's DataKey collection
            int gameID = Convert.ToInt32(AllGamesGridView.DataKeys[selectedRow].Values["gameID"]);

            // use EF to find the selected student in the DB and remove it
            using (DefaultContent db = new DefaultContent())
            {
                // create object of the Student class and store the query string inside of it
                baseballgametracker deletedGame = (from gameRecords in db.baseballgametrackers
                                          where gameRecords.gameID == gameID
                                          select gameRecords).FirstOrDefault();

                // remove the selected game from the db
                db.baseballgametrackers.Remove(deletedGame);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GetGames();
            }
        }
    }
}