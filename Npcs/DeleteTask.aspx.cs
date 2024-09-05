using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Npcs
{
    public partial class DeleteTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                // A ver
                int taskId = Convert.ToInt32(Request.Form["taskId"]);
                int userId = Convert.ToInt32(Request.Form["userId"]);

                using (var context = new AppDbContext())
                {
                    
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskId && t.UserId == userId);

                    if (task != null)
                    {                        
                        context.Tasks.Remove(task);
                        context.SaveChanges();

                        Response.Write("Tarefa excluída com sucesso.");
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