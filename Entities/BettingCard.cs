using LotteryConsole.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LotteryConsole.Entities
{
    class BettingCard
    {
        public int[] Numbers { get; protected set; }

        public BettingCard(int qtdNumbers)
        {
            if (qtdNumbers <= 0)
            {
                throw new LotteryExceptions("A quantidade de numero de apostas por cartao deve ser maior que zero.");
            }
            Numbers = new int[qtdNumbers];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (i < (Numbers.Length - 1))
                {
                    sb.Append(Numbers[i] + ", ");
                }
                else
                { 
                    sb.Append(Numbers[i]); 
                }
            }

            return sb.ToString();
        }
    }
}
