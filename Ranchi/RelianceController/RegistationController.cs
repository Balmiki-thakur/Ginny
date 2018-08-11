using Reliance.Modals;
using Reliance.SqlDll;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RelianceController
{
  public class RegistationController
  {


     

      #region Private Variable

      static int userIdIndex = 0;
      static int userNameIndex = 0;
      static int emailIndex = 0;
      static int PasswordIndex = 0;
      static int DOBIndex = 0;
      static int mobileIndex = 0;
      static int createOnIndex = 0;
      static int isAuthanticationIndex = 0;
      static int roleIndex = 0;
      static int Eidindex = 0;
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
                  emailIndex = reader.GetOrdinal("Email");
                  PasswordIndex = reader.GetOrdinal("Password");
                  DOBIndex = reader.GetOrdinal("DOB");
                  mobileIndex = reader.GetOrdinal("mobile");
                  createOnIndex = reader.GetOrdinal("CreatedOn");
                  isAuthanticationIndex = reader.GetOrdinal("IsAuthantication");
                  roleIndex = reader.GetOrdinal("Role");
                  Eidindex = reader.GetOrdinal("Eid");
                  isInisilization = true;

              }
              return true;
          }
          return false;
      }
      private static RegistationDo ReadData(SqlDataReader reader)
      {
          RegistationDo userRegistationDto = new RegistationDo();
          if (InisilizationIndex(reader))
          {
              if (!reader.IsDBNull(userIdIndex))
              {
                  userRegistationDto.Userid = reader.GetInt32(userIdIndex);
              }
              if (!reader.IsDBNull(userNameIndex))
              {
                  userRegistationDto.UserName = reader.GetString(userNameIndex);
              }
              if (!reader.IsDBNull(emailIndex))
              {
                  userRegistationDto.Email = reader.GetString(emailIndex);
              }
              if (!reader.IsDBNull(PasswordIndex))
              {
                  userRegistationDto.Password = reader.GetString(PasswordIndex);
              }
              if (!reader.IsDBNull(DOBIndex))
              {
                  userRegistationDto.DOB = reader.GetDateTime(DOBIndex);
              }
              if (!reader.IsDBNull(mobileIndex))
              {
                  userRegistationDto.MobileNo = reader.GetString(mobileIndex);
              }
              if (!reader.IsDBNull(isAuthanticationIndex))
              {
                  userRegistationDto.IsAuthantication = reader.GetBoolean(isAuthanticationIndex);
              }
              if (!reader.IsDBNull(roleIndex))
              {
                  userRegistationDto.Role = reader.GetInt32(roleIndex);
              }
              if (!reader.IsDBNull(Eidindex))
              {
                  userRegistationDto.Company = reader.GetInt32(Eidindex);
              }

          }
          return userRegistationDto;
      }
      
     public bool IsUserExist( string Email)
        {
         // bool flag = false;
          SqlParameter[] para = new SqlParameter[1];
          para[0] = new SqlParameter("@Email", Email);
          SqlDb sqlDb = new SqlDb();
          var flag = sqlDb.ExecuteScalarSP(StoreProcesureName.UserEmailCheck, para); 
            return  Convert.ToBoolean(flag);    
           }
          
  

      #endregion
      public  bool AddUserRedistation(RegistationDo userRegistationDto)
      {        
            bool flag = false;
            if (!IsUserExist(userRegistationDto.Email))
            {

                // MenuDTO menudto = new MenuDTO();
                SqlParameter[] para = new SqlParameter[7];
                para[0] = new SqlParameter("@userName", userRegistationDto.UserName);
                para[1] = new SqlParameter("@email", userRegistationDto.Email);
                para[2] = new SqlParameter("@mobile", userRegistationDto.MobileNo);
                para[3] = new SqlParameter("@dbo", userRegistationDto.DOB);
                para[4] = new SqlParameter("@IsAuthantication", userRegistationDto.IsAuthantication);
                para[5] = new SqlParameter("@createOn", userRegistationDto.CreateOn);
                para[6] = new SqlParameter("@role", userRegistationDto.Role);
                SqlDb sqlDb = new SqlDb();
                sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddRegistation, para);
                return flag=true;
            }
            return flag;
      }

      public void UpdateRegistation(RegistationDo userRegistationDto) 
      {
           SqlParameter [] para= new SqlParameter[8];
          para[0] = new SqlParameter("@userId", userRegistationDto.Userid);
          para[1] = new SqlParameter("@userName", userRegistationDto.UserName);
          para[2] = new SqlParameter("@email", userRegistationDto.Email);
          para[3] = new SqlParameter("@mobile", userRegistationDto.MobileNo);
          para[4] = new SqlParameter("@dbo", userRegistationDto.DOB);
          para[5] = new SqlParameter("@IsAuthantication", userRegistationDto.IsAuthantication);
          para[6] = new SqlParameter("@createOn", userRegistationDto.CreateOn);
          para[7] = new SqlParameter("@role", userRegistationDto.Role);
          SqlDb sqlDb = new SqlDb();
          sqlDb.ExecuteNonQuerySP(StoreProcesureName.Update_UserRegistation, para);
      }
      public  RegistationDo UserbyUserId(int UserId)
      {
          // MenuDTOList menuDTOList = new MenuDTOList();
          RegistationDo menu = new RegistationDo();
          SqlParameter[] para = new SqlParameter[1];
          para[0] = new SqlParameter("@userId", UserId);
          SqlDb sqlDb = new SqlDb();
          using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.RoleLogin, para))
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
                  throw ex;
              }

          }

          return menu;
      }


      public RegistationDoList RolebyUserId(int Roleid)
      {
          RegistationDoList registationDoList = new RegistationDoList();
          // MenuDTOList menuDTOList = new MenuDTOList();
          RegistationDo registationDo = new RegistationDo();
          SqlParameter[] para = new SqlParameter[1];
          para[0] = new SqlParameter("@roleId", Roleid);
          SqlDb sqlDb = new SqlDb();
          using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.RolebyUser, para))
          {

              try
              {
                  if (InisilizationIndex(reader))
                      while (reader.Read())
                      {
                          registationDo = ReadData(reader);
                          registationDoList.Add(registationDo);
                      }
                  isInisilization = false;
              }
              catch (Exception ex)
              {
                  throw ex;
              }

          }

          return registationDoList;
      }
      public  RegistationDoList AllUser()
      {
          RegistationDoList menuDTOList = new RegistationDoList();
          SqlDb sqlDb = new SqlDb();
          using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllUser))
          {

              RegistationDo menuDTO = new RegistationDo();
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
      public  RegistationDo UserIdbyPassword(string UserName,string Password ,string CompanyName)
      { 
          int Companyid=0;
          RegistationDo admindo = new RegistationDo();
          SqlConnection constr = new SqlConnection();
         // var DatabaseName = MainDatabaseEntity.Companyid(CompanyName);        
          string connStringServer = "Data Source=.;Integrated Security=True;database=Ranchi;";
         
         if (CompanyName == "OldBpm")
         {
             Companyid = 1;
         }
         else {
             Companyid = 4;
         }
             // System.Configuration.ConfigurationManager.ConnectionStrings["db1"].ConnectionString;
         // "Data Source=SEQUEL-LAP-125;uid=sa;password=1@password;database="+ DatabaseName.CompanyName +";";
         //SqlDb.connStringServer="Data Source=172.29.0.194;uid=DMSSEQUEL;pwd=BPMPYss8$3[pe; database=MVC_RELIANCE;";      
          SqlParameter[] para = new SqlParameter[3];
          para[0] = new SqlParameter("@userName", UserName);
          para[1] = new SqlParameter("@password", Password);
          para[2] = new SqlParameter("@CompanyId", Convert.ToInt32(Companyid));
          SqlDb sqlDb = new SqlDb();
          using (SqlDataReader reader = sqlDb.GetDataReaderSPcONNECTOION(StoreProcesureName.UserIdbyPassword, para, connStringServer))
          {
              try
              {
                  if (InisilizationIndex(reader))
                  {
                      if (reader.Read())
                      {
                          admindo = ReadData(reader);
                          admindo.Connectiondb = connStringServer;
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
  }
}
