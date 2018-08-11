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
   public class RoleMasterController
    {

        #region Private Variable

        static int RoleIdIndex = 0;
        static int CompanyIdIndex = 0;
        static int RoleNameIndex = 0;
        static int CreatedOnIndex = 0;
        static int RoleDescriptonIndex = 0;
        static bool isInisilization = false;

        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    RoleIdIndex = reader.GetOrdinal("RoleId");
                    CompanyIdIndex = reader.GetOrdinal("Eid");
                    RoleNameIndex = reader.GetOrdinal("RoleName");
                    CreatedOnIndex = reader.GetOrdinal("CreatedOn");
                    RoleDescriptonIndex = reader.GetOrdinal("RoleDescription");

                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static RoleMasterDo ReadData(SqlDataReader reader)
        {
            RoleMasterDo role = new RoleMasterDo();
            if (InisilizationIndex(reader))
            {
                role.RoleId = reader.GetInt32(RoleIdIndex);

                if (!reader.IsDBNull(CompanyIdIndex))
                {
                    role.CompanyId = reader.GetInt32(CompanyIdIndex);
                }
                if (!reader.IsDBNull(RoleNameIndex))
                {
                    role.RoleName = reader.GetString(RoleNameIndex);
                }
              
                if (!reader.IsDBNull(CreatedOnIndex))
                {
                    role.CreateOn = reader.GetDateTime(CreatedOnIndex);
                }
                if (!reader.IsDBNull(RoleDescriptonIndex))
                {
                    role.RoleDescription = reader.GetString(RoleDescriptonIndex);
                }
            }
            return role;
        }
        #endregion
        public  void AddRoleItems(RoleMasterDo role)
        {
            // MenuDTO menudto = new MenuDTO();
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@roleName", role.RoleName);
            para[1] = new SqlParameter("@roledescription", role.RoleDescription);
            para[2] = new SqlParameter("@CompanyId", role.CompanyId);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddRole, para);
        }

        public  RoleMasterDo RolebyRoleId(string Id)
        {
            RoleMasterDo roleMasterDoList = new RoleMasterDo();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@roleId", Convert.ToInt32(Id));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.RoleByRoleId, para))
            {
                RoleMasterDo roleDTO = new RoleMasterDo();
                try
                {
                    if (InisilizationIndex(reader))
                        if (reader.Read())
                        {
                            roleDTO = ReadData(reader);
                            
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return roleDTO;
            }

        }

        public  RoleMasterDoList AllRole(int CompanyId)
        {
            RoleMasterDoList roleMasterDoList = new RoleMasterDoList();
            SqlParameter[] pram =new SqlParameter[1];
            pram[0] = new SqlParameter("@Eid", CompanyId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllRoleData, pram))
            {
                RoleMasterDo roleDTO = new RoleMasterDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                           roleDTO = ReadData(reader);
                           roleMasterDoList.Add(roleDTO);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return roleMasterDoList;
            }

        }
    }
}
