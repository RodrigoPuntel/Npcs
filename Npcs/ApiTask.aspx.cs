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
                using (var context = new AppDbContext())
                {
                    var tasks = context.Tasks.Select(u => new { u.TaskName, u.TaskDescription }).ToList();
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