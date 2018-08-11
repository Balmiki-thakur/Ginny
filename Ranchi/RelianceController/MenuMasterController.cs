using Reliance.Modals;
using Reliance.SqlDll;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Web;
namespace RelianceController
{
    public  class MenuMasterController
    {

        #region Private Variable

        static int MenuIdIndex = 0;
        static int EidIndex = 0;
        static int MenuNameIndex = 0;
        static int PMenuIndex = 0;
        static int PageLinkIndex = 0;
        static int DordIndex = 0;
        static int ImageIndex = 0;
        static int MenuTypeIndex = 0;
        static int RoleIndex = 0;
        static int CreatedOnIndex = 0;
        static int MenuDescriptonIndex = 0;
        static int ContollerIndex = 0;
        static int ActionIndex = 0;
        static bool isInisilization = false;

        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    MenuIdIndex = reader.GetOrdinal("MenuId");
                    MenuNameIndex = reader.GetOrdinal("MenuName");        
                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static bool AllInisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {

                    MenuIdIndex = reader.GetOrdinal("MenuId");
                    EidIndex = reader.GetOrdinal("Eid");
                    MenuNameIndex = reader.GetOrdinal("MenuName");
                    PMenuIndex = reader.GetOrdinal("PMenu");
                    PageLinkIndex = reader.GetOrdinal("PageLink");
                    DordIndex = reader.GetOrdinal("Dord");
                    ImageIndex = reader.GetOrdinal("Image");
                    RoleIndex = reader.GetOrdinal("Role");
                    MenuTypeIndex = reader.GetOrdinal("MenuType");
                    CreatedOnIndex = reader.GetOrdinal("CreatedOn");
                    MenuDescriptonIndex = reader.GetOrdinal("MenuDescripton");
                    ContollerIndex = reader.GetOrdinal("Controller");
                    ActionIndex = reader.GetOrdinal("ActionName");
                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static MenuMasterDo AllReadData(SqlDataReader reader)
        {
            MenuMasterDo menu = new MenuMasterDo();
            if (AllInisilizationIndex(reader))
            {
                menu.MenunId = reader.GetInt64(MenuIdIndex);
                if (!reader.IsDBNull(EidIndex))
                {
                menu.Eid = reader.GetInt32(EidIndex);
                }
                if (!reader.IsDBNull(MenuNameIndex))
                {
                    menu.Menuname = reader.GetString(MenuNameIndex);
                }
                if (!reader.IsDBNull(PMenuIndex))
                {
                    menu.PMenu = reader.GetInt64(PMenuIndex);
                }
                if (!reader.IsDBNull(PageLinkIndex))
                {
                    menu.MenuLink = reader.GetString(PageLinkIndex);
                }
                if (!reader.IsDBNull(DordIndex))
                {
                    menu.MenuOrder = reader.GetInt32(DordIndex);
                }
                if (!reader.IsDBNull(ImageIndex))
                {
                    menu.Image = reader.GetString(ImageIndex);
                }
                if (!reader.IsDBNull(RoleIndex))
                {
                    menu.Role = reader.GetString(RoleIndex);
                }
                if (!reader.IsDBNull(MenuTypeIndex))
                {
                    menu.Menutype = reader.GetString(MenuTypeIndex);
                }
                if (!reader.IsDBNull(CreatedOnIndex))
                {
                    menu.CreateOn = reader.GetDateTime(CreatedOnIndex);
                }
                if (!reader.IsDBNull(MenuDescriptonIndex))
                {
                    menu.MenuDescription = reader.GetString(MenuDescriptonIndex);
                }
                if (!reader.IsDBNull(ContollerIndex))
                {
                    menu.Controller = reader.GetString(ContollerIndex);
                }
                if (!reader.IsDBNull(ActionIndex))
                {
                    menu.Action = reader.GetString(ActionIndex);
                }
            }
            return menu;
        }
        private static MenuMasterDo ReadData(SqlDataReader reader)
        {
            MenuMasterDo menu = new MenuMasterDo();
            if (InisilizationIndex(reader))
            {
                menu.MenunId = reader.GetInt64(MenuIdIndex);          
                menu.Menuname = reader.GetString(MenuNameIndex);
            }
            return menu;
        }
        #endregion
        public  void AddMenuItems(MenuMasterDo menu)
        {
            // MenuDTO menudto = new MenuDTO();
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@menuName", menu.Menuname);
            para[1] = new SqlParameter("@menudescription", menu.MenuDescription);
            para[2] = new SqlParameter("@pmenu", menu.PMenu);
            para[3] = new SqlParameter("@menuOrder", menu.MenuOrder);
            para[4] = new SqlParameter("@Menuimage", menu.Image);
            para[5] = new SqlParameter("@Eid", menu.Eid);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddMenu, para);
        }
        public  void AddSubMenuItems(MenuMasterDo menu)
        {
            // MenuDTO menudto = new MenuDTO();
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@pmenu", menu.PMenu);
            para[1] = new SqlParameter("@menuType", menu.Menutype);
            para[2] = new SqlParameter("@pageLink", menu.MenuLink);
            para[3] = new SqlParameter("@submenuName", menu.Menuname);
            para[4] = new SqlParameter("@menuOrder", menu.MenuOrder);
            para[5] = new SqlParameter("@Menuimage", menu.Image);
            para[6] = new SqlParameter("@Eid", menu.Eid);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.SubMenuMaster, para);
        }
        //public static void UpdateSubMenuItems(MenuMasterDo menu)
        //{
        //    // MenuDTO menudto = new MenuDTO();
        //    SqlParameter[] para = new SqlParameter[6];
        //    para[0] = new SqlParameter("@pmenu", menu.PMenu);
        //    para[1] = new SqlParameter("@menuType", menu.Menutype);
        //    para[2] = new SqlParameter("@pageLink", menu.MenuLink);
        //    para[3] = new SqlParameter("@submenuName", menu.Menuname);
        //    para[4] = new SqlParameter("@menuOrder", menu.MenuOrder);
        //    para[5] = new SqlParameter("@Menuimage", menu.Image);
        //    para[6] = new SqlParameter("@Menuimage", menu.MenunId);
        //    SqlDb.ExecuteNonQuerySP(StoreProcesureName.Update_SubMenuMaster, para);
        //}
        public  MenuMasterDo MenuByMenuId(int MenuId)
        {
            // MenuDTOList menuDTOList = new MenuDTOList();
            MenuMasterDo menu = new MenuMasterDo();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@menuId", MenuId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.MenubyMenuId, para))
            {

                try
                {
                    if (InisilizationIndex(reader))
                        if (reader.Read())
                        {
                            menu = ReadData(reader);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                      HttpContext.Current.Response.Redirect("~/Account/LogOn");     
                }

            }

            return menu;
        }
        public  MenuMasterList MenuNameAndMenuId()
        {
            MenuMasterList menuDTOList = new MenuMasterList();
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllMenus))
            {
                
                MenuMasterDo menuDTO = new MenuMasterDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            menuDTO = ReadData(reader);
                            menuDTOList.Add(menuDTO);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return menuDTOList;
            }

        }
        public MenuMasterList AllMenu(string UserName, int Companyid)
        {

            MenuMasterList menuDTOList = new MenuMasterList();

            SqlParameter[] para = new SqlParameter[2];

            para[0] = new SqlParameter("@UserName", UserName);
            para[1] = new SqlParameter("@Eid", Companyid);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllMenuData, para))
            {
                MenuMasterDo menuDTO = new MenuMasterDo();
                try
                {
                    if (AllInisilizationIndex(reader))
                        while (reader.Read())
                        {
                            menuDTO = AllReadData(reader);
                            menuDTOList.Add(menuDTO);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Redirect(" ~/Account/LogOn ");


                }

                return menuDTOList;

            }

        }
        public  MenuMasterList AllMenus()
        {
            MenuMasterList menuDTOList = new MenuMasterList();
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllMenuDatas))
            {

                MenuMasterDo menuDTO = new MenuMasterDo();
                try
                {
                    if (AllInisilizationIndex(reader))
                        while (reader.Read())
                        {
                            menuDTO = AllReadData(reader);
                            menuDTOList.Add(menuDTO);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return menuDTOList;
            }

        }
        public  MenuMasterList AllRootMenu()
        {
            MenuMasterList menuDTOList = new MenuMasterList();
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.RootMenu))
            {

                MenuMasterDo menuDTO = new MenuMasterDo();
                try
                {
                    if (AllInisilizationIndex(reader))
                        while (reader.Read())
                        {
                            menuDTO = AllReadData(reader);
                            menuDTOList.Add(menuDTO);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return menuDTOList;
            }

        }
        public  MenuMasterList AllRootSubMenu(long menuId)
        {
            MenuMasterList menuDTOList = new MenuMasterList();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@menuId", menuId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllSubMenu, para))
            {

                MenuMasterDo menuDTO = new MenuMasterDo();
                try
                {
                    if (AllInisilizationIndex(reader))
                        while (reader.Read())
                        {
                            menuDTO = AllReadData(reader);
                            menuDTOList.Add(menuDTO);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return menuDTOList;
            }

        }

        public  void InsertRole(MenuRoleDoList roles)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MenuRoleDoList));
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, roles);
            var value = textWriter.ToString();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@xml", value);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.SaveMenuRole, para))
            {             
            }
            //return roles;
        }


        public   MenuMasterDo EditMenuByMenuId(string MenuId)
        {
            // MenuDTOList menuDTOList = new MenuDTOList();
            MenuMasterDo menu = new MenuMasterDo();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@menuId", Convert.ToInt32(MenuId));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.EditMenuId, para))
            {

                try
                {
                    if (InisilizationIndex(reader))
                        if (reader.Read())
                        {
                            menu = ReadData(reader);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Redirect("~/Account/LogOn");
                }

            }

            return menu;
        }
    }
}
