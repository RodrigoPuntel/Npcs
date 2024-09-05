using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Npcs
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                // Recebe os parâmetros enviados pelo aplicativo mobile
                string categoryName = Request.Form["categoryName"];
                string categoryDescription = Request.Form["categoryDescription"];                

                using (var context = new AppDbContext())
                {
                    // Cria uma nova categoria
                    var category = new Category
                    {
                        CategoryName = categoryName,
                        CategoryDescription = categoryDescription
                    };

                    // Adiciona a categoria ao banco de dados
                    context.Categories.Add(category);
                    context.SaveChanges();

                    // Retorna uma resposta de sucesso
                    Response.Write("Categoria adicionada com sucesso.");
                }
            }
        }
    }
}