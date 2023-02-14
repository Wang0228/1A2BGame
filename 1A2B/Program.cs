using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1A2B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～\n------");

            Random random= new Random();
            string game = "y",user="";
            int A = 0,B = 0,count=0;
            bool number=true;
            int[] auto= new int[4];

            do
            {
                for (int i = 0; i < 4; i++)
                {
                    auto[i] = random.Next(1, 10);
                }
                Console.Write("電腦答案:");
                auto[0] = 1; auto[1] = 1; auto[2] = 1; auto[3] = 1;
                foreach (int i in auto) Console.Write(i);
                do
                {
                    do
                    {
                        Console.WriteLine("\n請輸入 4 個數字：");
                        user = Console.ReadLine();
                        if(string.IsNullOrWhiteSpace(user)||int.Parse(user)>9999 || int.Parse(user) < 1000)//預防不是四位數
                        {
                            number = true;
                            Console.WriteLine("格式錯誤!請輸入四位數\n");
                        }
                        else
                        {
                            number = false;
                        }
                    } while (number);
                    
                    int[] player = user.Select(x => int.Parse(x.ToString())).ToArray();
                    A = 0; B=0;
                    for (int i = 0; i < 4; i++)//相同數字相同位置
                    {
                        if (auto[i] == player[i])
                        {
                            A++;
                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {   
                        count = 0;
                        for (int l = 0; l < 4; l++)
                        {
                            
                            if (auto[i] == player[l] &&count!=1)//count 防止電腦產生重複數字b會多算
                            {//相同數字不同位置
                                B++;
                                count++;
                            }
                        }
                    }

                    Console.WriteLine($"判定結果是 {A}A{B - A}B");
                    Console.WriteLine("------");
                } while (A != 4);
                A = 0; B = 0;
                do
                {
                    Console.Write("你要繼續玩嗎？(y/n):");
                    game = Console.ReadLine();
                    if(game != "y" && game != "n")//防止y或n以外的字
                    {
                        Console.WriteLine("格式錯誤! 請輸入(y/n)!\n");
                    }
                }while (game != "y" && game!="n");
            }while(game== "y");
            Console.WriteLine("遊戲結束，下次再來玩喔～ ");

        }
    }
}