using LotteryConsole.Entities;
using LotteryConsole.Entities.Exceptions;
using System;
using System.Collections.Generic;

namespace LotteryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa para sortear numeros da loteria e contruir apostas");
            Console.WriteLine();
            try
            {
                NumberCalculation numberCalculation = new NumberCalculation(1, 60, 20, 6);

                List<BettingCard> bettingCards = numberCalculation.GenerateBettingCards();

                foreach (BettingCard card in bettingCards)
                {
                    Console.WriteLine(card.ToString());
                }
            }
            catch (LotteryExceptions e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
