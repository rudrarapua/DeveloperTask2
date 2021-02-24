using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developertask2
{
    class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("Enter Amount");
            int total = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Coins");
            int[] coins = new int[3];
            for(int i = 0;i < coins.Length; i++)
            {
                coins[i] = Convert.ToInt16(Console.ReadLine());
            }
            CoinChangingMinimumCoin cc = new CoinChangingMinimumCoin();
            Dictionary<int, int> map = new Dictionary<int, int>();
            Console.WriteLine("Total Amount "+total);
            for(int i=0; i < coins.Length; i++)
            {
                Console.WriteLine("Coins : "+ coins[i]);
            }
            cc.coins(total, coins);
            Console.ReadKey();
        }
        public class CoinChangingMinimumCoin
        {
            public void coins(int total, int[] coins)
            {
                int[] T = new int[total + 1];
                int[] R = new int[total + 1];
                T[0] = 0;
                for (int i = 1; i <= total; i++)
                {
                    T[i] = int.MaxValue - 1;
                    R[i] = -1;
                }
                for (int j = 0; j < coins.Length; j++)
                {
                    for (int i = 1; i <= total; i++)
                    {
                        if (i >= coins[j])
                        {
                            if (T[i - coins[j]] + 1 < T[i])
                            {
                                T[i] = 1 + T[i - coins[j]];
                                R[i] = j;
                            }
                        }
                    }
                }
                showCoinsPAC(R, coins);
            }

            private void showCoinsPAC(int[] R, int[] coins)
            {
                //Console.WriteLine("R"+R[0]);
                //Console.WriteLine("coins"+coins[0]);
                if (R[R.Length - 1] == -1)
                {
                    Console.WriteLine("No combination is possilbe");
                    return;
                }
                int start = R.Length - 1;
                //Console.WriteLine("start "+ start);
                Console.WriteLine("Coins used to form total ");
                //Console.Read();
                while (start != 0)
                {
                    //Console.WriteLine("inner start " + start);
                    int j = R[start];
                    Console.WriteLine(coins[j] + " ");
                    start = start - coins[j];
                    //Console.Read();
                }
                Console.WriteLine("\n");
                Console.Read();
            }
        }
    }
}
