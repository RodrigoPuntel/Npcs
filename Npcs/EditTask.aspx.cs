using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Npcs
{
    public partial class EditTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                // Revisar
                int taskId = Convert.ToInt32(Request.Form["taskId"]);
                string newTaskName = Request.Form["taskname"];
                string newTaskDescription = Request.Form["taskdescription"];
                int userId = Convert.ToInt32(Request.Form["userId"]);

                using (var context = new AppDbContext())
                {
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskId && t.UserId == userId);

                    if (task != null)
                    {
                        
                        task.TaskName = newTaskName;
                        task.TaskDescription = newTaskDescription;
                        //update task status?
                                                
                        context.SaveChanges();

                        Response.Write("Tarefa editada com sucesso.");
                    }
                    else
                    {
                        Response.Write("Tarefa não encontrada ou usuário não autorizado.");
                    }
                }
            }
        }
    }
}