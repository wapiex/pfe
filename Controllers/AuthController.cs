using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testloggg.models;
using testloggg.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace WebApplication5.Controllers
{
    public class AuthController : Controller{


        [Route("api/auth"), HttpPost]
        public async Task<IActionResult> AuthenticateAsync([FromBody] Login login)
        {
        string Connexion = @"Data Source =DESKTOP-E36VL9V\SQLEXPRESS;Initial Catalog =log; Integrated Security=true;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

        String constr = Connexion;
        SqlConnection connection = new SqlConnection(constr);

        using (connection)
        {



            var sql = @"select * from login where login='" + login.Username + "' and mdp='" + login.Password + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                return Ok(new { Message = "L'utilisateur existe dans la base de données." });
                    connection.Close();
                }

            else
            {
                return NotFound(new { Message = "L'utilisateur n'existe pas dans la base de données." });
                    connection.Close();
                }
        }

        
            
        
                    



                 


                    




        
       
        }
    }
}
