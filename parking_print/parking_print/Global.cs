using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPrint
{
    class Global
    {
        public static string AppPath = "";
        public static string IniPath = "";
        public static string DB_Name = "";
        public static string DB_Location = "";
        public static string DB_ConStr = "";
        public static string DC_Name = "";
        public static string DC_Mode = "";
        public static string CompanyCode = "";
        public static string CompanyName2 = "";
        public static string CompanyName = "";
        public static string CompanyName3 = "";
        public static string CompanyName4 = "";
        public static string CompanyName5 = "";
        public static string time = "";
        public static string yy = "20";
        public static string MM = "";
        public static string dd = "";
        public static string BarcodePrint = "COM6";
        public static bool PrintOK = false;
        public static string sikcode = "0";
        public static string Delay = "";
        public static string code = "";
        public static string half_code = "001";
        public static string golf_code = "101";
        public static string weekend_code = "102";
        public static string guard_code = "103";
        public static string value = "";
        public static string Half = "030";
        public static string OneHour = "060";
        public static string TwoHours = "120";
        public static string ThreeHours = "180";
        public static string FourHours = "240";
        public static string FiveHours = "300";
        public static string SixHours = "360";
        public static string OneDay = "88888";
        public static string AllFree = "000";
        public const string fmt1 = "00000";
        public const string fmt2 = "000";
        public const string formatString1 = "{0,4:00000}";
        public const string formatString2 = "{0,2:000}";
    }
}
