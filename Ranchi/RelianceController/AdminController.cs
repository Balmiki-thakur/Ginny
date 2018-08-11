using Reliance.Modals;
using Reliance.SqlDll;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceController
{

    public class Admin
    {
        #region Private Variable

        static int userIdIndex = 0;
        static int userNameIndex = 0;
        static int userPasswordIndex = 0;
        static int usermailIdIndex = 0;
        static bool isInisilization = false;

        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {

                    userIdIndex = reader.GetOrdinal("UserId");
                    userNameIndex = reader.GetOrdinal("UserName");
                    userPasswordIndex = reader.GetOrdinal("Pasword");
                    usermailIdIndex = reader.GetOrdinal("EmailId");
                    isInisilization = true;

                }
                return true;
            }
            return false;
        }

        private static AdminLogin ReadData(SqlDataReader reader)
        {
            AdminLogin logindo = new AdminLogin();
            if (InisilizationIndex(reader))
            {
                logindo.Username = reader.GetString(userNameIndex);
                logindo.Password = reader.GetString(userPasswordIndex);
            }
            return logindo;
        }
        #endregion
        public  AdminLoginList Allmember()
        {
            AdminLoginList admindolist = new AdminLoginList();
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AdminLogin))
            {

                AdminLogin admin = new AdminLogin();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            admin = ReadData(reader);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                admindolist.Add(admin);

            }
            return admindolist;
        }
        public  AdminLogin UserIdbyPassword(AdminLogin login)
        {
            AdminLogin admindo = new AdminLogin();
            //  AdminLoginList admindolist = new AdminLoginList();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@userName", login.Username);
            para[1] = new SqlParameter("@password", login.Password);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.UserIdbyPassword, para))
            {
                try
                {
                    if (InisilizationIndex(reader))
                    {
                        if (reader.Read())
                        {
                            admindo = ReadData(reader);
                        }
                        isInisilization = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return admindo;
        }
        public  AdminLoginList UsernamebyPassword(AdminLogin login)
        {
            AdminLoginList admindolist = new AdminLoginList();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@userName", login.Username);
            para[1] = new SqlParameter("@password", login.Password);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AdminLoginUseId, para))
            {
                AdminLogin admindo = new AdminLogin();
                try
                {
                    if (InisilizationIndex(reader))
                        if (reader.Read())
                        {
                            admindo = ReadData(reader);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                admindolist.Add(admindo);
            }
            return admindolist;
        }

        public  AdminLogin RolebyUserName(AdminLogin login)
        {
            AdminLogin admindo = new AdminLogin();
            //  AdminLoginList admindolist = new AdminLoginList();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@userName", login.Username);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.RoleByRoleId, para))
            {
                try
                {
                    if (InisilizationIndex(reader))
                        if (reader.Read())
                        {
                            login = ReadData(reader);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return login;
        }
    }
}
