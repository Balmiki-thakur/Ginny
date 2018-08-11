using Reliance.Modals;
using Reliance.SqlDll;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RelianceController
{
  public  class MenuRoleController
    {


        #region Private Variable

        static int menuIdIndex = 0;
        static int isvalidIndex = 0;
        static int isEditIndex = 0;
        static int isDeleteIndex = 0;
        static int menuroleidIndex = 0;
        static bool isInisilization = false;

        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {

                    menuIdIndex = reader.GetOrdinal("MenuId");
                    isvalidIndex = reader.GetOrdinal("IsValid");
                    isEditIndex = reader.GetOrdinal("IsEdit");
                    isDeleteIndex = reader.GetOrdinal("IsDelete");
                    menuroleidIndex = reader.GetOrdinal("MenuRoleId");
                    isInisilization = true;

                }
                return true;
            }
            return false;
        }


        private static MenuRoleDo ReadData(SqlDataReader reader)
        {
            MenuRoleDo menu = new MenuRoleDo();
            if (InisilizationIndex(reader))
            {
                menu.MenuId = reader.GetInt32(menuIdIndex);
                menu.IsValid = reader.GetBoolean(isvalidIndex);
                menu.IsEdit = reader.GetBoolean(isEditIndex);
                menu.IsDelete = reader.GetBoolean(isDeleteIndex);
                menu.RoleId = reader.GetInt32(menuroleidIndex);
            }
            return menu;
        }
        #endregion
      public  MenuRoleDoList MenuRoleByMenuId(string MenuId)
      {
          MenuRoleDoList menuRoleDoList = new MenuRoleDoList();
          SqlParameter[] para = new SqlParameter[1];
          para[0] = new SqlParameter("@menuId", Convert.ToInt32(MenuId));
          SqlDb sqlDb = new SqlDb();
          using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.MenusRolebyMenuId, para))
          {
              MenuRoleDo menuRoleDo = new MenuRoleDo();
              try
              {
                  if (InisilizationIndex(reader))
                      while (reader.Read())
                      {
                          menuRoleDo = ReadData(reader);
                          menuRoleDoList.Add(menuRoleDo);
                      }
                  isInisilization = false;
              }
              catch (Exception ex)
              {
                  HttpContext.Current.Response.Redirect("~/Account/LogOn");
              }

          }

          return menuRoleDoList;
      }


      public  MenuRoleDoList RenderFormRole(string formid,string role)
      {
          MenuRoleDoList menuRoleDoList = new MenuRoleDoList();
          SqlParameter[] para = new SqlParameter[2];
          para[0] = new SqlParameter("@formId", Convert.ToInt32(formid));
          para[1] = new SqlParameter("@RoleId", Convert.ToInt32(role));
          SqlDb sqlDb = new SqlDb();
          using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.ManuFormRender, para))
          {
              MenuRoleDo menuRoleDo = new MenuRoleDo();
              try
              {
                  if (InisilizationIndex(reader))
                      while (reader.Read())
                      {
                          menuRoleDo = ReadData(reader);
                          menuRoleDoList.Add(menuRoleDo);
                      }
                  isInisilization = false;
              }
              catch (Exception ex)
              {
                  HttpContext.Current.Response.Redirect("~/Account/LogOn");
              }

          }

          return menuRoleDoList;
      }
    }
}
