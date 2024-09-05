using System;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Npcs
{
    public partial class ApiLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                var username = Request.Form["username"];
                var password = Request.Form["password"];

                var pwd = PasswordHelper.HashPassword(password);

                using (var context = new AppDbContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == pwd);
                    if (user != null)
                    {
                        // Cria uma resposta JSON com o userId
                        var responseObject = new
                        {
                            userId = user.Id
                        };
                        var serializer = new JavaScriptSerializer();
                        var jsonResponse = serializer.Serialize(responseObject);

                        Response.ContentType = "application/json";
                        Response.StatusCode = 200;
                        Response.Write(jsonResponse);
                        Response.End(); // Encerra a resposta
                    }
                    else
                    {
                        Response.StatusCode = 401;
                        Response.Write("Invalid username or password");
                        Response.End(); // Encerra a resposta
                    }
                }
            }
            else if (Request.HttpMethod == "GET")
            {
                using (var context = new AppDbContext())
                {
                    var users = context.Users.Select(u => new { u.Id, u.Username, u.Password }).ToList();
                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Serialize(users);

                    Response.ContentType = "application/json";
                    Response.StatusCode = 200;
                    Response.Write(json);
                    Response.End(); // Encerra a resposta
                }
            }
        }
    }
}
