using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngin
{

    public enum CONNECTION_MODULE
    {
        REGULAR = 1
    }

    public class sqlDBDll
    {
        // public static string connStringServer = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public static string connStringServer = "";
        //= System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        private static SqlConnection GetConnection(CONNECTION_MODULE module)
        {
            if (module == CONNECTION_MODULE.REGULAR)
            {
                return new SqlConnection(connStringServer);
            }
            return new SqlConnection(connStringServer);
        }

        // Get Data Table



        private static DataTable GetDataTable(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn, int Querytimeout)
        {
            DataTable dt = new DataTable();
            using (SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn))
            {
                sqlCmd.CommandTimeout = Querytimeout;
                sqlCmd.CommandType = comandType;
                if (param != null)
                {
                    sqlCmd.Parameters.AddRange(param);
                }
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
                sqlDA.Fill(dt);
                sqlCmd.Parameters.Clear();
            }
            return dt;
        }

        private static DataSet GetDataSet(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn, int Querytimeout)
        {
            DataSet ds = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn))
            {
                sqlCmd.CommandType = comandType;
                if (param != null)
                {
                    sqlCmd.Parameters.AddRange(param);
                }
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
                sqlDA.Fill(ds);
                sqlCmd.Parameters.Clear();
            }
            return ds;
        }

        public static DataSet GetDataSetSP(string sqlSP, SqlParameter[] param, int Querytimeout = 120)
        {
            return GetDataSet(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static DataSet GetDataSetQuery(string sqlQuery, SqlParameter[] param, int Querytimeout = 120)
        {
            return GetDataSet(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static DataSet GetDataSetSP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return GetDataSet(sqlSP, param, CommandType.StoredProcedure, GetConnection(module), Querytimeout);
        }
        public static DataSet GetDataSetQueryText(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return GetDataSet(sqlQuery, param, CommandType.Text, GetConnection(module), Querytimeout);
        }
        public static DataSet GetDataSetQuerywithoutParm(string sqlQuery, int Querytimeout = 120)
        {
            return GetDataSet(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }

        public static DataTable GetDataTableSP(string sqlSP, SqlParameter[] param, int Querytimeout = 120)
        {
            return GetDataTable(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static DataTable GetDataTableQuery(string sqlQuery, SqlParameter[] param, int Querytimeout = 120)
        {
            return GetDataTable(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static DataTable GetDataTableSP(string sqlSP, int Querytimeout = 120)
        {
            return GetDataTable(sqlSP, null, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static DataTable GetDataTableQuery(string sqlQuery, int Querytimeout = 120)
        {
            return GetDataTable(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }

        public static DataTable GetDataTableSP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return GetDataTable(sqlSP, param, CommandType.StoredProcedure, GetConnection(module), Querytimeout);
        }
        public static DataTable GetDataTableQuery(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return GetDataTable(sqlQuery, param, CommandType.Text, GetConnection(module), Querytimeout);
        }
        public static DataTable GetDataTableSP(string sqlSP, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return GetDataTable(sqlSP, null, CommandType.StoredProcedure, GetConnection(module), Querytimeout);
        }
        public static DataTable GetDataTableQuerywithoutparm(string sqlQuery, int Querytimeout = 120)
        {
            return GetDataTable(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }

        // Execute Reader


        private static SqlDataReader GetDataReader(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn, int Querytimeout)
        {
            SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn);
            sqlCmd.CommandType = comandType;
            if (param != null)
            {
                sqlCmd.Parameters.AddRange(param);
            }
            sqlCmd.CommandTimeout = Querytimeout;
            // sqlCmd.CommandTimeout = sqlConn.ConnectionTimeout;
            if (sqlConn.State != ConnectionState.Open)
            {
                sqlCmd.Connection.Open();
            }
            //++
            SqlDataReader dataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            sqlCmd.Parameters.Clear();
            //  sqlCmd.Connection.Close();//--
            return dataReader;
        }

        public static SqlDataReader GetDataReaderSP(string sqlSP, SqlParameter[] param, int Querytimeout = 120)
        {
            return GetDataReader(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static SqlDataReader GetDataReaderQuery(string sqlQuery, SqlParameter[] param, int Querytimeout = 120)
        {
            return GetDataReader(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static SqlDataReader GetDataReaderSP(string sqlSP, int Querytimeout = 120)
        {
            return GetDataReader(sqlSP, null, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static SqlDataReader GetDataReaderQuery(string sqlQuery, int Querytimeout = 120)
        {
            return GetDataReader(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }


        public static SqlDataReader GetDataReaderSP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return GetDataReader(sqlSP, param, CommandType.StoredProcedure, GetConnection(module), Querytimeout);
        }
        public static SqlDataReader GetDataReaderQuery(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return GetDataReader(sqlQuery, param, CommandType.Text, GetConnection(module), Querytimeout);
        }
        public static SqlDataReader GetDataReaderSP(string sqlSP, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return GetDataReader(sqlSP, null, CommandType.StoredProcedure, GetConnection(module), Querytimeout);
        }
        public static SqlDataReader GetDataReaderQuery(string sqlQuery, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return GetDataReader(sqlQuery, null, CommandType.Text, GetConnection(module), Querytimeout);
        }


        // Execute Non Query


        private static int ExecuteNonQuery(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn, int Querytimeout = 120)
        {
            int rowAffected = 0;

            try
            {
                using (SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn))
                {
                    sqlCmd.CommandType = comandType;
                    if (param != null)
                    {
                        sqlCmd.Parameters.AddRange(param);
                    }
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlCmd.Connection.Open();
                    }
                    rowAffected = sqlCmd.ExecuteNonQuery();
                    sqlCmd.CommandTimeout = Querytimeout;
                    //  sqlCmd.CommandTimeout = sqlConn.ConnectionTimeout;

                    sqlCmd.Connection.Close();
                    sqlCmd.Parameters.Clear();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowAffected;
        }

        public static int ExecuteNonQuerySP(string sqlSP, SqlParameter[] param, int Querytimeout = 120)
        {
            return ExecuteNonQuery(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }

        public static int ExecuteNonQueryQuery(string sqlQuery, SqlParameter[] param, int Querytimeout = 120)
        {
            return ExecuteNonQuery(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static int ExecuteNonQueryQuery(string sqlQuery, int Querytimeout = 120)
        {
            return ExecuteNonQuery(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }

        public static int ExecuteNonQuerySP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return ExecuteNonQuery(sqlSP, param, CommandType.StoredProcedure, GetConnection(module), Querytimeout);
        }

        public static int ExecuteNonQueryQuery(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return ExecuteNonQuery(sqlQuery, param, CommandType.Text, GetConnection(module), Querytimeout);
        }

        // Execute Non Query


        private static object ExecuteScalar(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn, int Querytimeout)
        {
            object data = new object();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn))
                {
                    sqlCmd.CommandType = comandType;
                    if (param != null)
                    {
                        sqlCmd.Parameters.AddRange(param);
                        if (sqlConn.State != ConnectionState.Open)
                        {
                            sqlCmd.Connection.Open();
                        }
                        sqlCmd.CommandTimeout = Querytimeout;

                        //sqlCmd.CommandTimeout =sqlConn.ConnectionTimeout ;  

                        data = sqlCmd.ExecuteScalar();
                        sqlCmd.Connection.Close();
                        sqlCmd.Parameters.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public static object ExecuteScalarSP(string sqlSP, int Querytimeout = 120)
        {
            return ExecuteScalar(sqlSP, null, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static object ExecuteScalarSP(string sqlSP, SqlParameter[] param, int Querytimeout = 120)
        {
            return ExecuteScalar(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static object ExecuteScalarQuery(string sqlQuery, SqlParameter[] param, int Querytimeout = 120)
        {
            return ExecuteScalar(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
        public static object ExecuteScalarSP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return ExecuteScalar(sqlSP, param, CommandType.StoredProcedure, GetConnection(module), Querytimeout);
        }
        public static object ExecuteScalarQuery(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
        {
            return ExecuteScalar(sqlQuery, param, CommandType.Text, GetConnection(module), Querytimeout);
        }
        public static object ExecuteScalarQuerywithoutpram(string sqlQuery, int Querytimeout = 120)
        {
            return ExecuteScalar(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR), Querytimeout);
        }
      
    }

}



















//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Configuration.Internal;

//using System.Web;

//namespace Reliance.SqlDll
//{
//    public enum CONNECTION_MODULE
//    {
//        REGULAR = 1,
//    }
//    public class SqlDb
//    {
//       // public static string connStringServer = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
//        public  string connStringServer =Convert.ToString(HttpContext.Current.Session["LOGGED_Connectiondb"]); 
//        //= System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

    
//    private  SqlConnection GetConnection(CONNECTION_MODULE module,string con)
//      {
         
//          if (con != "")
//          {
//              SqlDb sqlDb = new SqlDb();
//              sqlDb.connStringServer = con;
//              return new SqlConnection(con);
//          }
//           else if (module == CONNECTION_MODULE.REGULAR)
//            {
//              return new SqlConnection(connStringServer);
//            }
//            return new SqlConnection(connStringServer);
//        }
//        /* Get Data Table*/


//        private  DataTable GetDataTable(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn,int Querytimeout)
//        {
//            DataTable dt = new DataTable();
//            using (SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn))
//            {
//                sqlCmd.CommandTimeout = Querytimeout;
//                sqlCmd.CommandType = comandType;
//                if (param != null)
//                    sqlCmd.Parameters.AddRange(param);
//                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
//                sqlDA.Fill(dt);
//                sqlCmd.Parameters.Clear();
//            }
//            return dt;
//        }

//        private  DataSet GetDataSet(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn,int Querytimeout)
//        {
//            DataSet ds = new DataSet();
//            using (SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn))
//            {
//                sqlCmd.CommandType = comandType;
//                if (param != null)
//                    sqlCmd.Parameters.AddRange(param);
//                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
//                sqlDA.Fill(ds);
//                sqlCmd.Parameters.Clear();
//            }
//            return ds;
//        }

//        public  DataSet GetDataSetSP(string sqlSP, SqlParameter[] param, int Querytimeout=120)
//        {
//            return GetDataSet(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR,""), Querytimeout);
//        }
//        public  DataSet GetDataSetQuery(string sqlQuery, SqlParameter[] param, int Querytimeout = 120)
//        {
//            return GetDataSet(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""), Querytimeout);
//        }
//        public  DataSet GetDataSetSP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout=120)
//        {
//            return GetDataSet(sqlSP, param, CommandType.StoredProcedure, GetConnection(module,""),Querytimeout);
//        }
//        public  DataSet GetDataSetQueryText(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
//        {
//            return GetDataSet(sqlQuery, param, CommandType.Text, GetConnection(module,""),Querytimeout);
//        }
//        public  DataSet GetDataSetQuerywithoutParm(string sqlQuery, SqlParameter[] param, int Querytimeout = 120)
//        {
//            return GetDataSet(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""), Querytimeout);
//        }

//        public  DataTable GetDataTableSP(string sqlSP, SqlParameter[] param, int Querytimeout = 120)
//        {
//            return GetDataTable(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout);
//        }
//        public  DataTable GetDataTableQuery(string sqlQuery, SqlParameter[] param,int Querytimeout=120)
//        {
//            return GetDataTable(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout);
//        }
//        public  DataTable GetDataTableSP(string sqlSP, int Querytimeout = 120)
//        {
//            return GetDataTable(sqlSP, null, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout);
//        }
//        public  DataTable GetDataTableQuery(string sqlQuery, int Querytimeout = 120)
//        {
//            return GetDataTable(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout);
//        }

//        public  DataTable GetDataTableSP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
//        {
//            return GetDataTable(sqlSP, param, CommandType.StoredProcedure, GetConnection(module,""),Querytimeout);
//        }
//        public  DataTable GetDataTableQuery(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
//        {
//            return GetDataTable(sqlQuery, param, CommandType.Text, GetConnection(module,""),Querytimeout);
//        }
//        public  DataTable GetDataTableSP(string sqlSP, CONNECTION_MODULE module, int Querytimeout = 120)
//        {
//            return GetDataTable(sqlSP, null, CommandType.StoredProcedure, GetConnection(module,""),Querytimeout);
//        }
//        public  DataTable GetDataTableQuerywithoutparm(string sqlQuery, int Querytimeout = 120)
//        {
//            return GetDataTable(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""), Querytimeout);
//        }

//        /* Execute Reader*/

//        private  SqlDataReader GetDataReader(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn ,int Querytimeout)
//        {
//            SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn);
//            sqlCmd.CommandType = comandType;
//            if (param != null)
//            sqlCmd.Parameters.AddRange(param);
//            sqlCmd.CommandTimeout = Querytimeout;
//           // sqlCmd.CommandTimeout = sqlConn.ConnectionTimeout;
//            if (sqlConn.State != ConnectionState.Open)
//            {
//                sqlCmd.Connection.Open();
//            }//var data=0;              
         
//           // MessageBox.Show(data);
//            SqlDataReader dataReader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
//            sqlCmd.Parameters.Clear();
//          //  sqlCmd.Connection.Close();//
          
//            return dataReader;
//        }

//        public  SqlDataReader GetDataReaderSP(string sqlSP, SqlParameter[] param, int Querytimeout=120)
//        {
//            return GetDataReader(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout);
//        }
//        public  SqlDataReader GetDataReaderSPcONNECTOION(string sqlSP, SqlParameter[] param, string sqlConn, int Querytimeout = 120)
//        {
//            return GetDataReader(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR, sqlConn), Querytimeout);
//        }
//        public  SqlDataReader GetDataReaderQuery(string sqlQuery, SqlParameter[] param, int Querytimeout=120)
//        {
//            return GetDataReader(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout);
//        }
//        public  SqlDataReader GetDataReaderSP(string sqlSP, int Querytimeout=120)
//        {
//            SqlDb sqlDb = new SqlDb();

//            return sqlDb.GetDataReader(sqlSP, null, CommandType.StoredProcedure,sqlDb.GetConnection(CONNECTION_MODULE.REGULAR, ""), Querytimeout = 120);
//        }
//        public  SqlDataReader GetDataReaderQuery(string sqlQuery, int Querytimeout=120)
//        {
//            return GetDataReader(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout);
//        }

//        public  SqlDataReader GetDataReaderSP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
//        {
//            SqlDb sqlDb = new SqlDb();
//            return sqlDb.GetDataReader(sqlSP, param, CommandType.StoredProcedure, sqlDb.GetConnection(module, ""), Querytimeout);
//        }
//        public  SqlDataReader GetDataReaderQuery(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout = 120)
//        {
//            return GetDataReader(sqlQuery, param, CommandType.Text, GetConnection(module,""),Querytimeout);
//        }
//        public  SqlDataReader GetDataReaderSP(string sqlSP, CONNECTION_MODULE module, int Querytimeout = 120)
//        {
//            return GetDataReader(sqlSP, null, CommandType.StoredProcedure, GetConnection(module,""), Querytimeout);
//        }
//        public  SqlDataReader GetDataReaderQuery(string sqlQuery, CONNECTION_MODULE module, int Querytimeout = 120)
//        {
//            SqlDb sqlDb = new SqlDb();
//            return sqlDb.GetDataReader(sqlQuery, null, CommandType.Text, sqlDb.GetConnection(module, ""), Querytimeout);
//        }
//        /* Execute Non Query*/
//        private  int ExecuteNonQuery(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn, int Querytimeout = 120)
//        {
//            int rowAffected = 0;
//            try
//            {

//                using (SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn))
//                {
//                    sqlCmd.CommandType = comandType;
//                    if (param != null)
//                        sqlCmd.Parameters.AddRange(param);
//                    if (sqlConn.State != ConnectionState.Open)
//                    {
//                        sqlCmd.Connection.Open();
//                    }              
//                    rowAffected = sqlCmd.ExecuteNonQuery();
//                     sqlCmd.CommandTimeout = Querytimeout;
//                      //  sqlCmd.CommandTimeout = sqlConn.ConnectionTimeout;
                   
//                    sqlCmd.Connection.Close();
//                    sqlCmd.Parameters.Clear();
//                }

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//            return rowAffected;
//        }

//        public  int ExecuteNonQuerySP(string sqlSP, SqlParameter[] param, int Querytimeout=120)
//        {
//            return ExecuteNonQuery(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout);
//        }
//        public  int ExecuteNonQueryQuery(string sqlQuery, SqlParameter[] param, int Querytimeout=120)
//        {
//            return ExecuteNonQuery(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""), Querytimeout);
//        }
//        public  int ExecuteNonQueryQuery(string sqlQuery, int Querytimeout=120)
//        {
//            return ExecuteNonQuery(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout=120);
//        }
//        public  int ExecuteNonQuerySP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout=120)
//        {
//            return ExecuteNonQuery(sqlSP, param, CommandType.StoredProcedure, GetConnection(module,""), Querytimeout);
//        }
//        public  int ExecuteNonQueryQuery(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout=120)
//        {
//            return ExecuteNonQuery(sqlQuery, param, CommandType.Text, GetConnection(module,""), Querytimeout);
//        }
       
//        /* Execute Non Query*/

//        private  object ExecuteScalar(string queryOrSP, SqlParameter[] param, CommandType comandType, SqlConnection sqlConn,int Querytimeout)
//        {
//            object data = new object();
//            try
//            {
//                using (SqlCommand sqlCmd = new SqlCommand(queryOrSP, sqlConn))
//                {
//                    sqlCmd.CommandType = comandType;
//                    if (param != null)
//                    {
//                        sqlCmd.Parameters.AddRange(param);
//                        if (sqlConn.State != ConnectionState.Open)
//                        {
//                            sqlCmd.Connection.Open();
//                        }
//                            sqlCmd.CommandTimeout = Querytimeout;
                      
//                         //sqlCmd.CommandTimeout =sqlConn.ConnectionTimeout ;  
                       
//                        data = sqlCmd.ExecuteScalar();
//                        sqlCmd.Connection.Close();
//                        sqlCmd.Parameters.Clear();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return data;
//        }

//        public  object ExecuteScalarSP(string sqlSP, int Querytimeout=120)
//        {
//            return ExecuteScalar(sqlSP, null, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR,""), Querytimeout);
//        }
//        public  object ExecuteScalarSP(string sqlSP, SqlParameter[] param, int Querytimeout=120)
//        {
//            return ExecuteScalar(sqlSP, param, CommandType.StoredProcedure, GetConnection(CONNECTION_MODULE.REGULAR,""),Querytimeout);
//        }
//        public  object ExecuteScalarQuery(string sqlQuery, SqlParameter[] param, int Querytimeout=120)
//        {
//            return ExecuteScalar(sqlQuery, param, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""), Querytimeout);
//        }
//        public  object ExecuteScalarSP(string sqlSP, SqlParameter[] param, CONNECTION_MODULE module,int Querytimeout=120)
//        {
//            return ExecuteScalar(sqlSP, param, CommandType.StoredProcedure, GetConnection(module,""), Querytimeout);
//        }
//        public  object ExecuteScalarQuery(string sqlQuery, SqlParameter[] param, CONNECTION_MODULE module, int Querytimeout=120)
//        {
//            return ExecuteScalar(sqlQuery, param, CommandType.Text, GetConnection(module,""), Querytimeout);
//        }
//        public  object ExecuteScalarQuerywithoutpram(string sqlQuery, int Querytimeout = 120)
//        {
//            return ExecuteScalar(sqlQuery, null, CommandType.Text, GetConnection(CONNECTION_MODULE.REGULAR,""), Querytimeout);
//        }
//    }
//}
