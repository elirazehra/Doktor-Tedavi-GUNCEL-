using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace doktor_hasta.Pages.Detay
{
    public class DetaybtnModel : PageModel
    {
        public List<HastaYonetimInfo> listHastaYonetimInfo = new List<HastaYonetimInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=HastaYonetimSistemi;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string sql = "SELECT * From Tedavi";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HastaYonetimInfo Tedavi = new HastaYonetimInfo();
                                
                                Tedavi.TedaviID = reader.GetInt32(0);
                                Tedavi.TedaviName = reader.GetString(1);
                                Tedavi.TedaviPrice = reader.GetString(2);
                                
                               
                                listHastaYonetimInfo.Add(Tedavi);

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
        public int TedaviID;
        public string TedaviName;
        public string TedaviPrice;
        public int DoktorID;
        


    }
}