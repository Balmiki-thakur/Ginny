using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class GpsData
    {

                  public int   id	{get;set;}
                  public  string IMIENO	    {get;set;}
                  public decimal lattitude	{get;set;}
                  public decimal longitude  {get;set;}
                  public int altitude	{get;set;}
                  public decimal speed{get;set;}
                  public decimal angle	{get;set;}
                  public DateTime cTime	{get;set;}
                  public DateTime rTime	{get;set;}
                  public int noofSat	{get;set;}
        public decimal distance	{get;set;}

        //public int IsGPS	{get;set;}
        //public int IsGPRS	{get;set;}
        //public int TripOn{get;set;}
        //public string ibuttonID	{get;set;}
        //public int igStatus	{get;set;}
        //public int mSensor	{get;set;}
        //public int  ExtVolt	{get;set;}
        //public int DType { get; set; }
        //public int Diffrencetime { get; set; }
        //public string Vehicle_Name { get; set; }

    }
    public class ListGpsData : List<GpsData>
    {
        public ListGpsData()
        { }
    }




  public  class MilageGPSDataReport
    {
       public string IMIENO {get; set;}
       public string TotalKm { get; set; }
       public string Speed { get; set; }
       public string Date {get; set;}
     
      
    }
  public class ListMilageGPSDataReport : List<MilageGPSDataReport> 
  {
      public ListMilageGPSDataReport() 
      { }
  }
}
