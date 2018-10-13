using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = string.Format("ASB={0},{1}", "abc", "中国");//.ToLower();
            Console.WriteLine(str);
            int i = string.Compare("aBc", "abc");
            if (i == 0)
            {
                Console.WriteLine("==");
            }
            else
            {
                Console.WriteLine("!=");
            }
            string str1 = "hello";
            string str2 = "world";
            string str3 = "c#";
            string s = string.Concat(str1, str2, str3);
            Console.WriteLine(s);
            //contain
            bool a = s.Contains(str);
            if (a == true)
            {
                Console.WriteLine("have");
            }
            else
            {
                Console.WriteLine("!have");
            }
            //copy
            string str4 = string.Copy(s);
            Console.WriteLine(str4);
            //foreach
            foreach(char c in "abcde")
            {
                Console.WriteLine(c);
                
            }
            Console.WriteLine("-------------------");
            //
            string s1 = "1.2.3.4.5.67";
            string[] sArr = s1.Split('.');
            int num = 0;
            foreach (string c1 in sArr)
            {
                
                num = num + Convert.ToInt32(c1);
                Console.WriteLine(c1);
            }
            Console.WriteLine("{0}={1}", s1, num);
            //
            string s2 = "1.2.h3dd.4.5.67";  //用正则表达式取出数字
            string pattern = "[A-Z a-z]";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            //正则表达式，将S2中的所有字母直接去掉
            string result = rgx.Replace(s2, replacement);
            string[] strArr = result.Split('.');
            int nu = 0;
            foreach(string st2 in strArr)
            {
                nu = nu + Convert.ToInt32(st2);
            }
            Console.WriteLine("{0}={1}",s2,nu);
            Console.ReadKey();
        }
    }
}
