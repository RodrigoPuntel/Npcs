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
                // Recebe o TaskId do aplicativo mobile via Request
                int taskId = Convert.ToInt32(Request.Form["taskId"]);
                int userId = Convert.ToInt32(Request.Form["userId"]);

                using (var context = new AppDbContext())
                {
                    // Busca a tarefa no banco de dados com o TaskId e UserId fornecidos
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskId && t.UserId == userId);

                    if (task != null)
                    {
                        // Remove a tarefa
                        context.Tasks.Remove(task);
                        context.SaveChanges();

                        Response.Write("Tarefa excluída com sucesso.");
                    }
                    else
                    {
                        // Tarefa não encontrada ou não pertence ao usuário
                        Response.Write("Tarefa não encontrada ou usuário não autorizado.");
                    }
                }
            }
        }
    }
}