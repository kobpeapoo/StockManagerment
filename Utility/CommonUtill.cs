using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.Utility {
    public class CommonUtill {
        public CommonUtill() { }
        public string convertIntToDate(string dateIn) {
            string dateOutput = "";
            string year = dateIn.Substring(0,4);
            string month = dateIn.Substring(4,2);
            string date = dateIn.Substring(6,2);
            dateOutput = date + "/" + month + "/" + year;
            return dateOutput;
        }
        public string convertIntToShortDate(string dateIn) {
            string dateOutput = "";
            string year = dateIn.Substring(2, 2);
            string month = dateIn.Substring(4, 2);
            string date = dateIn.Substring(6, 2);
            dateOutput = date + "/" + month + "/" + year;
            return dateOutput;
        }
        public string convertDateToInt(string dateIn) {
            string dateOutput = "";

            return dateOutput;
        }
        public string convertShowNumber2Point(string number) {
            string result = "";
            if (number!=null&&number!="") {
                result = Convert.ToDouble(number).ToString("#,##0.00");
            }
            return result;
        }
        public string dayThaiOfWeek(int day) {
            string[] dayThai = {"อาทิตย์","จันทร์","อังคาร","พุธ","พฤหัสบดี","ศุกร์","เสาร์"};
            return dayThai[day];
        }
    }
}
