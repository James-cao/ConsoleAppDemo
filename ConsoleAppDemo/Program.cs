using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var cards = new int[] { 2, 7, 4, 1, 6 };

            var lst = new List<int>();

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] < 10)  //小于10,不包括：10，J，Q，K
                {
                    lst.Add(cards[i]);
                }
            }

            if (lst.Count == 0) //所有牌都为大于或等于10
            {
                System.Console.WriteLine("五花");
            }

            if (lst.Count == 5 || lst.Count == 4) 
            {
                var findPoint = 0;
                for (int i = 0; i < lst.Count; i++)   //两张牌相加，再找点数（三张牌和为10）
                {
                    for (int k = i + 1; k < lst.Count; k++)
                    {
                        var sum = lst[i] + lst[k];
                        var overplus = 0;
                        if (sum > 10)
                        {
                            overplus = 10 - sum % 10;
                        }
                        else
                        {
                            overplus = 10 - sum;
                        }

                        var newLst = new List<int>();
                        for (int j = lst.Count - 1; j >= 0; j--) //排除前两张牌，在剩下的集合中找点了
                        {
                            if (lst[j] == lst[i] || lst[j] == lst[k])
                            {

                            }
                            else
                            {
                                newLst.Add(lst[j]);
                            }
                        }

                        findPoint = newLst.Find(p => p == overplus);
                        if (findPoint > 0)
                        {
                            System.Console.WriteLine("牛{0}", cards.Max(x => x));
                            break;

                        }
                    }
                    if (findPoint > 0)
                    {
                        break;
                    }
                }
                if (findPoint == 0)
                {
                    System.Console.WriteLine("无牛,{0}点大", cards.Max(x => x));
                }

            }

            if (lst.Count == 3) //说明有两张为十的位数
            {
                int sum = 0;
                for (int i = 0; i < lst.Count; i++)
                {
                    sum += lst[i];
                }

                if (sum % 10 == 0)  //只要剩下三张牌为10的倍数及为牛牛
                {
                    System.Console.WriteLine(string.Format("{0}牛牛", cards.Max(p => p)));
                }
                else
                {
                    System.Console.WriteLine("无牛");
                }

            }

            if (lst.Count == 2) //如果前三张都是10的倍数，剩下两张之和除10得到余数，就是点数。
            {
                var sum = 0;
                for (int i = 0; i < lst.Count; i++)
                {
                    sum += lst[i];
                }

                var cardPoint = sum % 10;

                System.Console.WriteLine(string.Format("牛：{0}", cardPoint == 0 ? sum : cardPoint));
            }

            if (lst.Count == 1) //前四张都是10的倍数，剩余一张就是点数
            {
                System.Console.WriteLine(string.Format("牛：{0}", lst[0]));
            }
        }
    }
}
