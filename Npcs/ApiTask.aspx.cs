using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Npcs
{
    public partial class ApiTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET")
            {
                string userIdString = Request.QueryString["userId"];

                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                {
                    Response.ContentType = "application/json";
                    Response.StatusCode = 400;
                    Response.Write("{\"error\":\"userId inválido ou não fornecido.\"}");
                    return;
                }

                using (var context = new AppDbContext())
                {
                    // Pega tarefas com base no userId
                    var tasks = context.Tasks
                                       .Where(t => t.UserId == userId)
                                       .Select(t => new
                                       {
                                           t.TaskName,
                                           t.TaskDescription,
                                           t.CreationDate,
                                           t.Status
                                       })
                                       .ToList();

                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Serialize(tasks);

                    Response.ContentType = "application/json";
                    Response.StatusCode = 200;
                    Response.Write(json);
                    Page.Visible = false;
                }
            }
        }
    }
}
