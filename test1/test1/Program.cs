using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    //LCS
    public class LCS<T>
    {
        //lcs 长度和指向的存储
        private int[,] lcs_length = new int[7, 5];  //定义二维数组，存储每项比较后的LCS数
        private string[,] lcs_dir = new string[7, 5];  //定义二维数组，存储回溯的走向
        //求出LCS的大小
        public int lcs_num(T[] list1, T[] list2)  //使用泛型接收两个用于比较的数组
        {
            //得到两个数组的长度
            int l1_length = list1.Length;
            int l2_length = list2.Length;
            //使用循环得到lcs_length和lcs_dir
            for (int i = 0; i < l1_length; i++)
            {
                for (int j = 0; j < l2_length; j++)
                {
                    if (i == 0 || j == 0)   //在二维数组中第一行和第一列的时候
                    {
                        if (list1[i].Equals(list2[j]))  //如果其中的有元素相同
                        {
                            lcs_length[i, j] = 1;       //在LCS长度数组的i行j列中存储长度为1
                            lcs_dir[i, j] = "lup";      //在LCS方向存储(方向阵)中i行j列存储为“lup”,相当于指向左上方，用于回溯
                        }
                        else    //如果ij的元素不同
                        {
                            if (i > 0)   //在二维组中的第一列
                            {
                                lcs_length[i, j] = lcs_length[i - 1, j];  //LCS阵i行j列长度存为上一行的长度
                                lcs_dir[i, j] = "up";    //方向阵中i行j列存储为“up”，相当于指向上方，用于回溯
                            }
                            if (j > 0)  //在二维组中的第一行
                            {
                                lcs_length[i, j] = lcs_length[i, j - 1];   //LCS阵i行j列长度存为上一列的长度
                                lcs_dir[i, j] = "l";     //方向阵中i行j列存储为“l”，相当于指向左方，用于回溯
                            }
                        }
                    }
                    //在非第一行，非第一列的其他位置
                    //如果i行j列的元素相同
                    else if (list1[i].Equals(list2[j]))
                    {
                        //就是矩阵中i-1行j-1列的LCS长度+1
                        lcs_length[i, j] = lcs_length[i - 1, j - 1] + 1;
                        lcs_dir[i, j] = "lup";   //将方向阵的i行j列记为“lup”
                    }
                    //如果i行j列的元素不同
                    //长度阵的i行j列的存储长度为上一行或者上一列中的最大值
                    else if (lcs_length[i - 1, j] > lcs_length[i, j - 1])
                    {
                        //上一行的长度值大于上一列就将上一行的值存储进ij
                        lcs_length[i, j] = lcs_length[i - 1, j];
                        lcs_dir[i, j] = "up";  //方向记为“up”
                    }
                    else
                    {
                        //上一列的长度值大于上一行就将上一列值的存储进ij
                        lcs_length[i, j] = lcs_length[i, j - 1];
                        lcs_dir[i, j] = "l";  //方向记为“l”
                    }
                }
            }
            //调用打印，打印出最后结果
            printlcs(lcs_dir, list1, list2, list1.Length - 1, list2.Length - 1);
            //返回最终的LCS长度，其最终值存放于二维数组右下角
            return lcs_length[list1.Length - 1, list2.Length - 1];

        }
        //打印函数，传入方向阵用于回溯，传入两个字符串，以及长度阵和方向阵的行数与列数
        //递归打印
        public void printlcs(string[,] lcs_dir, T[] list1, T[] list2, int row, int col)
        {
            //若是空就直接返回
            if (list1 == null || list2 == null)
                return;
            if (list1.Length == 0 || list2.Length == 0 || !(row < list1.Length && col < list2.Length))
                return;
            //在都非空的状态下
            //从右下角开始进行回溯
            if (lcs_dir[row, col].Equals("lup"))
            {
                //在行数和列数都大于0的情况下
                if (row > 0 && col > 0)
                    //如果方向阵中的这个位置是“lup”,就将list1中下标等于row的字符打印出来
                    //然后行标与列表减一，继续打印
                    printlcs(lcs_dir, list1, list2, row - 1, col - 1);
                Console.WriteLine(list1[row]);
            }
            //方向阵中的这个位置是“l”,说明list1中没有list2的这个字符，将其+打印出来，并减去一个单位列坐标继续打印
            else if (lcs_dir[row, col].Equals("l"))
            {
                if (col > 0)
                    printlcs(lcs_dir, list1, list2, row, col - 1);
                Console.WriteLine("+{0}", list2[col]);
            }
            //方向阵中的这个位置是“up”，说明list2中没有这个字符，将其-打印出来出来，并减去一个行坐标继续打印
            else if (lcs_dir[row, col].Equals("up"))
            {
                if (row > 0)
                    printlcs(lcs_dir, list1, list2, row - 1, col);
                Console.WriteLine("-{0}", list1[row]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] list1 = { 34, 72, 13, 44, 25, 30, 10 };
            int[] list2 = { 34, 13, 44, 7, 25 };

            string[] str1 = { "abc", "def", "gh", "zwd" };
            string[] str2 = { "abc", "2", "def", "gh", "zwd" };
            string[] str3 = { "abc", "33" };

            LCS<int> lcs = new LCS<int>();  //泛型为int型
            int n = lcs.lcs_num(list1, list2);  //代入进行整型的LCS运算
            Console.WriteLine("int lcs number is：");
            Console.WriteLine(n);
            Console.WriteLine("----------------------");
            LCS<string> lcs_s = new LCS<string>();  //为字符串型
            int n2 = lcs_s.lcs_num(str1, str2);   //代入进行LCS运算
            Console.WriteLine("string lcs number is：");
            Console.WriteLine(n2);
            Console.WriteLine("----------------------");
            string[] str4 = new string[5];
            string[] str5 = new string[5];
            Console.WriteLine("输入1：");
            for (int i = 0; i < 5; i++)
            {
                str4[i] = Console.ReadLine();
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("输入2：");
            for (int i = 0; i < 5; i++)
            {
                str5[i] = Console.ReadLine();
            }
            Console.WriteLine("----------------------");
            int n3 = lcs_s.lcs_num(str4, str5);
            Console.WriteLine("string lcs number is：");
            Console.WriteLine(n3);
            Console.ReadKey();
        }
    }
}
