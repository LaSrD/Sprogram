using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 进制转换
{
    class base_Conversion
    {

        public static string base_binaryToother(string num,byte _base)
        {
            Int32 _num = 0;
            string ans = num;
            try
            {
                _num = Convert.ToInt32(num, 2);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("输入不合法\r\n" + ex.ToString());
                return "输入不合法\r\n";
            }
            switch (_base) {
                case 8:
                    ans = Convert.ToString(_num, 8);
                    break;
                case 10:
                    ans = _num.ToString();
                    break;
                case 16:
                    ans = Convert.ToString(_num, 16);
                    break;
            }
            return ans;
        }
        public static string base_OctToOther(string num, byte _base)
        {
            Int32 _num = 0;
            string ans = "";
            try
            {
                _num = Convert.ToInt32(num, 8);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("输入不合法\r\n" + ex.ToString());
                return "输入不合法\r\n";
            }
            switch (_base)
            {
                case 2:
                    ans = Convert.ToString(_num, 2);
                    break;
                case 10:
                    ans = Convert.ToInt32(num, 8).ToString();
                    break;
                case 16:
                    ans = Convert.ToString(_num, 16);
                    break;
            }
            return ans;
        }
        public static string base_DecToOther(string num,byte _base)
        {
            Int32 _num = 0;
            if (!Int32.TryParse(num, out _num))
                return "输入不合法";
            string ans = "";
            switch (_base)
            {
                case 2:
                    ans = Convert.ToString(_num, 2);
                    break;
                case 8:
                    ans = Convert.ToString(_num, 8);
                    break;
                case 16:
                    ans = Convert.ToString(_num, 16);
                    break;
            }
            return ans.ToString();
        }
        public static string base_HexToOther(string num, byte _base)
        {
            string ans = "";
            Int32 _num = 0;
            try
            {
                _num = Convert.ToInt32(num, 16);
            }
            catch(Exception ex)
            {
                //MessageBox.Show("输入不合法\r\n" + ex.ToString());
                return "输入不合法\r\n";
            }
            switch (_base)
            {
                case 2:
                    ans = Convert.ToString(Convert.ToInt32(num, 16), 2);
                    break;
                case 8:
                    ans = Convert.ToString(Convert.ToInt32(num, 16), 8);
                    break;
                case 10:
                    ans = Convert.ToInt32(num, 16).ToString();
                    break;
            }
            return ans.ToString();
        }

        public static string doublebinaryToOther(string num, byte bits)
        {
            string ans = "";
            switch (bits)
            {
                case 2:
                    ans = num;
                    break;
                case 8:
                    ans = binaryToOct(num);
                    break;
                case 10:
                    ans = binaryToDec(num);
                    break;
                case 16:
                    ans = binaryToHex(num);
                    break;
            }
            return ans;
        }
        public static string doubleDecToOther(string num, byte bits)
        {
            string ans = "";
            switch (bits)
            {
                case 2:
                    ans = DecTobinary(num);
                    break;
                case 8:
                    ans = binaryToOct(DecTobinary(num));
                    break;
                case 10:
                    ans = num;
                    break;
                case 16:
                    ans = binaryToHex(DecTobinary(num));
                    break;
            }
            return ans;
        }
        public static string doubleOctToOther(string num, byte bits)
        {
            string ans = "";
            switch (bits)
            {
                case 2:
                    ans = OctTobinary(num);
                    break;
                case 8:
                    ans = num;
                    break;
                case 10:
                    ans = binaryToDec(OctTobinary(num));
                    break;
                case 16:
                    ans = binaryToHex(OctTobinary(num));
                    break;
            }
            return ans;
        }
        public static string doubleHexToOther(string num, byte bits)
        {
            string ans = "";
            switch (bits)
            {
                case 2:
                    ans = HexTobinary(num);
                    break;
                case 8:
                    ans = binaryToOct(HexTobinary(num));
                    break;
                case 10:
                    ans = binaryToDec(HexTobinary(num));
                    break;
                case 16:
                    ans = num;
                    break;
            }
            return ans;
        }
        #region 私有
        private static string binaryToOct(string num)
        {
            int length = num.Length;
            int index = 0;
            for (; index < length && num[index] != '.'; ++index) ;
            //整数部分
            string ans = base_binaryToother(num.Substring(0, index),8) + ".";
            //小数部补零
            for (int i = 0; i < 3 -((length - index - 1) % 3); ++i)
                num += '0';
            for(int i = index + 1; i < num.Length; i += 3)
            {
                ans += base_binaryToother(num.Substring(i, 3), 8); 
            }
            return ans;
        }
        private static string OctTobinary(string num)
        {
            int length = num.Length;
            int index = 0;
            for (; index < length && num[index] != '.'; ++index) ;
            //整数部分
            string ans = base_OctToOther(num.Substring(0, index), 2) + ".";
            // 小数部分
            for(int i = index + 1; i < length; ++i)
            {
                string temp = base_OctToOther(num.Substring(i, 1), 2);
                for (int j = 0; j < 3 - temp.Length; ++j)
                    ans += '0';
                ans += temp;
            }
            return ans;
        }
        private static string binaryToDec(string num)
        {
            int length = num.Length;
            int index = 0;
            for (; index < length && num[index] != '.'; ++index) ;
            //整数部分
            string ans = base_binaryToother(num.Substring(0, index), 10) + ".";
            //小数部
            double temp = 0.0;
            for (int i = index + 1; i < length; ++i)
            {
                if (num[i] == '1')
                    temp += (1.0 / Math.Pow(2, i - index));
            }
            ans += temp.ToString("f6").Substring(2, temp.ToString("f6").Length - 2);
            return ans;
        }
        private static string DecTobinary(string num)
        {
            int length = num.Length;
            int index = 0;
            for (; index < length && num[index] != '.'; ++index) ;
            //整数部分
            string ans = base_DecToOther(num.Substring(0, index), 2) + ".";
            // 小数部分
            double  temp = index >= length ? 0.0: double.Parse(("0." + num.Substring(index + 1, length - index - 1)));
            string str = "";
            int count = 0;
            while(temp != 0.0 && count < 32)
            {
                count++;
                str += temp * 2.0 >= 1 ? '1' : '0';
                temp = temp * 2.0 - (temp * 2.0 >= 1 ? 1 : 0);
            }
            return ans + str;
        }
        private static string binaryToHex(string num)
        {
            int length = num.Length;
            int index = 0;
            for (; index < length && num[index] != '.'; ++index) ;
            //整数部分
            string ans = base_binaryToother(num.Substring(0, index), 16) + ".";
            //小数部补零
            for (int i = 0; i < 4 - ((length - index - 1) % 4); ++i)
                num += '0';
            for (int i = index + 1; i < num.Length; i += 4)
            {
                ans += base_binaryToother(num.Substring(i, 4), 16);
            }
            return ans;
        }
        private static string HexTobinary(string num)
        {
            int length = num.Length;
            int index = 0;
            for (; index < length && num[index] != '.'; ++index) ;
            //整数部分
            string ans = base_HexToOther(num.Substring(0, index), 2) + ".";
            // 小数部分
            for (int i = index + 1; i < length; ++i)
            {
                string temp = base_HexToOther(num.Substring(i, 1), 2);
                for (int j = 0; j < 4 - temp.Length; ++j)
                    ans += '0';
                ans += temp;
            }
            return ans;
        }
        #endregion 
    }
}

