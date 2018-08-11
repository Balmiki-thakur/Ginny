
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Reliance.SqlDll
{
    public class MainDatabaseEntity
    {
        public static Entity Companyid(string CompanyId)
        {
            using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                var entity = new Entity();
                string sql = "select * from  Master_Entity where CompanyName='" + CompanyId +"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    entity.Companyid = Convert.ToInt32(rdr["TId"]);
                    entity.CompanyName = rdr["CompanyName"].ToString();
                    entity.CompanyDecs = rdr["CompanyDecs"].ToString();
                }
                return entity;    
            }  
        }
    }
}
