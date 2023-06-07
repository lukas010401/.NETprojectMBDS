using mail_management_frontoffice_mvcadonet.Utilities;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Data.SqlClient;

namespace mail_management_frontoffice_mvcadonet.Models
{
    public class MailDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Mail> GetAllMail()
        {
            List<Mail> lstMail = new List<Mail>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllMail", con);
                cmd.CommandTimeout = 60;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Mail mail = new Mail();
                    mail.ID = rdr.GetInt32(0);
                    mail.Ref = rdr.GetString(1);
                    mail.Sender = rdr.GetString(2);
                    mail.Messenger = rdr.GetString(3);
                    mail.MailObject = rdr.GetString(4);
                    mail.Flag = (mail_management_backoffice.Enums.MailFlag)rdr.GetInt32(5);
                    mail.CreatedDate = rdr.GetDateTime(6);
                    mail.UpdatedDate = !rdr.IsDBNull(7) ? rdr.GetDateTime(7) : null;
                    mail.Status = (mail_management_backoffice.Enums.MailStatus)rdr.GetInt32(8);
                    mail.Comment = !rdr.IsDBNull(9) ? rdr.GetString(9) : "";
                    mail.CreateUserId = !rdr.IsDBNull(10) ? rdr.GetString(10) : "";
                    mail.CreateUser = GetCreateUserById(mail.CreateUserId);


                    lstMail.Add(mail);
                }
                con.Close();
            }
            return lstMail;
        }

        private IdentityUser GetCreateUserById(string createUserId)
        {
            // Perform a query to fetch the user with the given createUserId
            // Implement your own database query logic here to fetch the user from the appropriate table
            // Return the fetched user object

            // Example:
            // Assuming you have a table named 'Users' with a column 'Id' for UserId and a column 'UserName' for the username
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM AspNetUsers WHERE Id = @CreateUserId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CreateUserId", createUserId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    IdentityUser user = new IdentityUser();
                    user.Id = rdr.GetString(0);
                    user.UserName = rdr.GetString(1);
                    user.NormalizedUserName = rdr.GetString(2);

                    con.Close();
                    return user;
                }

                con.Close();
                return null;
            }
        }

        public Mail GetMailData(int? id)
        {
            Mail mail = new Mail();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Mail WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    mail.ID = Convert.ToInt32(rdr["Id"]);
                    mail.Ref = rdr["Ref"].ToString();
                    mail.Sender = rdr["Sender"].ToString();
                    mail.Messenger = rdr["Messenger"].ToString();
                    mail.Recipient = rdr["Recipient"].ToString();
                    mail.MailObject = rdr["MailObject"].ToString();
                    mail.Flag = (mail_management_backoffice.Enums.MailFlag)rdr["Flag"];
                    mail.CreatedDate = (DateTime)rdr["CreatedDate"];
                    mail.UpdatedDate = (DateTime?)rdr["UpdatedDate"];
                    mail.Status = (mail_management_backoffice.Enums.MailStatus)rdr["Status"];
                    mail.Comment = rdr["Comment"].ToString();
                    mail.CreateUserId = rdr["CreateUserId"].ToString();
                }
            }
            return mail;
        }
    }
}
