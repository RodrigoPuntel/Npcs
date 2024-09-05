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
                // Recebe os parâmetros enviados pelo aplicativo mobile
                int taskId = Convert.ToInt32(Request.Form["taskId"]);
                string newTaskName = Request.Form["taskname"];
                string newTaskDescription = Request.Form["taskdescription"];
                int userId = Convert.ToInt32(Request.Form["userId"]);

                using (var context = new AppDbContext())
                {
                    // Busca a tarefa no banco de dados com o TaskId e UserId fornecidos
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskId && t.UserId == userId);

                    if (task != null)
                    {
                        // Atualiza o nome e a descrição da tarefa
                        task.TaskName = newTaskName;
                        task.TaskDescription = newTaskDescription;

                        // Salva as alterações no banco de dados
                        context.SaveChanges();

                        Response.Write("Tarefa editada com sucesso.");
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