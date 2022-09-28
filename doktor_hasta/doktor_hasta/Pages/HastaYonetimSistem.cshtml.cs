using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace doktor_hasta.Pages
{
    public class HastaYonetimSistemModel : PageModel
    {
        public List<HastaYonetimInfo> listHastaYonetimInfo = new List<HastaYonetimInfo >();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=HastaYonetimSistemi;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string sql = "SELECT * From Doktor";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HastaYonetimInfo Doktor = new HastaYonetimInfo();
                                Doktor.DoktorID = reader.GetInt32(0);
                                Doktor.DoktorName = reader.GetString(1);
                                Doktor.DoktorSurname = reader.GetString(2);
                                Doktor.DoktorBranch = reader.GetString(3);

                                listHastaYonetimInfo.Add(Doktor);

                            }
                        }
                    }

                }
            }




            catch (Exception ex)
            {

                
            }

        }
    }

    public class HastaYonetimInfo
    {
        public int DoktorID;
        public string DoktorName;
        public string DoktorSurname;
        public string DoktorBranch;


    }
}
