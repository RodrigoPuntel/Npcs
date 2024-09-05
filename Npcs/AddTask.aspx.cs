using System;
using System.Web;
using System.Web.UI;

namespace Npcs
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                // Captura taskname e taskdescription usando Request.Params
                string taskname = Request.Form["taskname"];
                string taskdescription = Request.Form["taskdescription"];

                // Validação: Verifica se taskname e taskdescription não estão vazios
                if (string.IsNullOrEmpty(taskname) || string.IsNullOrEmpty(taskdescription))
                {
                    Response.StatusCode = 400;
                    Response.Write("Nome ou descrição da tarefa não podem estar vazios");
                    Response.End();
                    return;
                }

                // TryParse
                if (int.TryParse(Request.Params["userId"], out int userId))
                {
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
                                                
                        Response.StatusCode = 200;
                        Response.Write("Tarefa adicionada com sucesso");
                        Response.End();
                    }
                }
                else
                {                    
                    Response.StatusCode = 400;
                    Response.Write("ID de usuário inválido");
                    Response.End();
                }
            }
        }
    }
}
