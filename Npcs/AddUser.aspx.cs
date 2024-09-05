using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Npcs
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                string username = Request.Form["username"];
                string password = Request.Form["password"];
                string emailadress = Request.Form["emailadress"];


                using (var context = new AppDbContext())
                {
                    var user = new User
                    {
                        Username = username,
                        Password = PasswordHelper.HashPassword(password),
                        EmailAdress = emailadress,
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }

        }
    }
}