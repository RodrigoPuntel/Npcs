using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace Npcs
{
    public partial class ApiStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                string jsonString;
                using (var reader = new StreamReader(Request.InputStream))
                {
                    jsonString = reader.ReadToEnd();
                }

                // Desserializa o JSON
                var jsonSerializer = new JavaScriptSerializer();
                var data = jsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

                // Captura os valores
                if (!data.TryGetValue("Id", out object IdObj) ||
                    !data.TryGetValue("userId", out object userIdObj))
                {
                    Response.StatusCode = 400;
                    Response.ContentType = "application/json"; // Define o Content-Type
                    Response.Write("{\"message\":\"ID da tarefa ou ID do usuário não podem estar vazios\"}");
                    Response.End();
                    return;
                }

                // Validação e conversão de tipos
                if (int.TryParse(IdObj.ToString(), out int taskId) &&
                    int.TryParse(userIdObj.ToString(), out int userId))
                {
                    using (var context = new AppDbContext())
                    {
                        var task = context.Tasks.FirstOrDefault(t => t.Id == taskId && t.UserId == userId);
                        if (task != null)
                        {
                            // Verifica se a tarefa já está concluída
                            if (task.Status == TaskStatus.Completo)
                            {
                                Response.StatusCode = 400;
                                Response.ContentType = "application/json";
                                Response.Write("{\"message\":\"A tarefa já está completa\"}");
                                Response.End();
                            }
                            else
                            {
                                // Altera o status para completo e salva
                                task.Status = TaskStatus.Completo;
                                task.ConclusionDate = DateTime.Now; // Define a data de conclusão
                                context.SaveChanges();

                                Response.StatusCode = 200;
                                Response.ContentType = "application/json";
                                Response.Write("{\"message\":\"Status da tarefa alterado para completo com sucesso\"}");
                                Response.End();
                            }
                        }
                        else
                        {
                            Response.StatusCode = 404;
                            Response.ContentType = "application/json";
                            Response.Write("{\"message\":\"Tarefa não encontrada ou você não tem permissão para alterá-la\"}");
                            Response.End();
                        }
                    }
                }
                else
                {
                    Response.StatusCode = 400;
                    Response.ContentType = "application/json";
                    Response.Write("{\"message\":\"IDs inválidos\"}");
                    Response.End();
                }
            }
        }
    }
}
