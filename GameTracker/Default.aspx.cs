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
            ///load the page with the current weeks game data
            if(!IsPostBack)
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
                             select allgames);

                GamesGridView.DataSource = Games.ToList();
                GamesGridView.DataBind();

                GamesGridView2.DataSource = Games.ToList();
                GamesGridView2.DataBind();

                GamesGridView1.DataSource = Games.ToList();
                GamesGridView1.DataBind();

            }
        }

        protected void GamesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

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
    }
}