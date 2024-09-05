using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Npcs
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Request.HttpMethod == "POST")
            {

                string taskname = Request.Form["taskname"];
                string taskdescription = Request.Form["taskdescription"];

                int userId = Convert.ToInt32(Request.Form["userId"]);

                using (var context = new AppDbContext())
                {
                    var task = new Task
                    {
                        TaskName = taskname,
                        TaskDescription = taskdescription,
                        CreationDate = DateTime.Now,
                        Status = TaskStatus.Incompleto,
                        UserId = userId,
                        CategoryId = null,
                    };
                    context.Tasks.Add(task);
                    context.SaveChanges();
                }
            }
        }                     
    }
}