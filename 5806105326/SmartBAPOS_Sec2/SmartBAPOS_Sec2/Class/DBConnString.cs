using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartBAPOS_Sec2.Class
{
    public sealed class DBConnString
    {
        //ต่อกับ Database Server
        public static string strConn = "Data Source=.;Initial Catalog=dbSmartBAPOS_Sec2;User ID=saBAPOS2;Password=12345699;Integrated Security=NO";

        //Title MessageBox
        public static string xMessage = "ระบบขายปลีกหน้าร้าน Smart BAPOS [โดย นายณัฐิวุฒิ ดีปินไซร์]";

        public static string pUsID = "";
        public static string pUsFullName = "";
        public static string pUsLevel = "";

        //ตัวแปรสำหรับ frmOrder
        public static string pFindCp="";
        public static string pCpID = "";
        public static string pCpName = "";
        public static string pCpAddress = "";
        public static string pCpContact = "";

        //ตัวแปรสำหรับ frmReceive
        public static string pOrdID = "";
        public static DateTime pOrdDate;

        public static decimal pTotal = 0;
        public static decimal pDisc = 0;
        public static decimal pNet = 0;

        //ตัวแปรสำหรับ tblProduct;
        public static string pProID = "";
    }
}
