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
                    // Tratamento de duplicação: Username ou Email.
                    bool userExists = context.Users.Any(u => u.Username == username || u.EmailAdress == emailadress);

                    if (userExists)
                    {
                        Response.StatusCode = 409;
                        Response.Write("Nome de usuário ou e-mail já existente.");
                        return;
                    }

                    // Insere User
                    var user = new User
                    {
                        Username = username,
                        Password = PasswordHelper.HashPassword(password),
                        EmailAdress = emailadress,
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    Response.StatusCode = 200;
                    Response.Write("Usuário cadastrado com sucesso.");
                }
            }
        }
    }
}