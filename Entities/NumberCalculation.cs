using LotteryConsole.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LotteryConsole.Entities
{
    class NumberCalculation
    {
        public int MinValue { get; protected set; }
        public int MaxValue { get; protected set; }
        public int NumBettingCards { get; protected set; }
        public int NumbersPerBettingCard { get; protected set; }

        public NumberCalculation(int minValue, int maxValue, int numBettingCards, int numbersPerBettingCard)
        {
            if (minValue > maxValue)
            {
                throw new LotteryExceptions("O valor minimo deve ser menor que o valor maximo.");
            }
            if (numBettingCards <= 0)
            {
                throw new LotteryExceptions("O numero de cartoes deve ser maior que zero.");
            }
            if (numbersPerBettingCard <= 0)
            {
                throw new LotteryExceptions("A quantidade de numero de apostas por cartao deve ser maior que zero.");
            }
            MinValue = minValue;
            MaxValue = maxValue;
            NumBettingCards = numBettingCards;
            NumbersPerBettingCard = numbersPerBettingCard;
        }

        public List<BettingCard> GenerateBettingCards()
        {
            List<BettingCard> bettingCards = new List<BettingCard>();

            for (int i = 0; i < NumBettingCards; i++)
            {
                BettingCard bettingCard = new BettingCard(NumbersPerBettingCard);

                while (bettingCard.Numbers.Contains(0))
                {
                    for (int num = 0; num < NumbersPerBettingCard; num++)
                    {
                        Random random = new Random(DateTime.UtcNow.Millisecond);
                        int number = 0;
                        number = random.Next(MinValue, MaxValue);
                        if (!bettingCard.Numbers.Contains(number))
                        {
                            if (bettingCards.Count(x => x.Numbers.Contains(number)) < 4)
                            {
                                bettingCard.Numbers[num] = number;
                            }

                        }
                    }

                }

                bettingCards.Add(bettingCard);
            }

            if (bettingCards.Count == 0 || bettingCards.Count < NumBettingCards)
            {
                throw new LotteryExceptions("Erro ao criar lista de cartoes de apostas");
            }

            return bettingCards;
        }
    }
}
