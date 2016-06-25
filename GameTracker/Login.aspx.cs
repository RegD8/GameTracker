using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for Identity and OWIN security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace GameTracker
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /**
         * <summary>
         * This method logs in the user onclick
         * </summary>
         * 
         */
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // create new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //search for and create user object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);

            //if a match is found for the user
            if(user != null)
            {
                //authenticate and login our new user
                var authentication = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in the user
                authentication.SignIn(new AuthenticationProperties() {IsPersistent = false }, userIdentity);

                //redirect to the dashboard page
                Response.Redirect("/GameTracker/Dashboard.aspx");
            }else
            {
                //if the user doesn't exist send an error to the alert div
                StatusLabel.Text = "Invalid Username or Password";
                AlertFlash.Visible = true;
            }

        }

       
    }
}