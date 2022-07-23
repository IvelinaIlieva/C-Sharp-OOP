namespace P03._Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Card
    {
        private readonly string face;
        private readonly string suit;

        public Card(string face, string suit)
        {
            this.face = face;
            this.suit = suit;
        }

        public override string ToString()
        {
            return $"[{this.face}{this.suit}]";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cardsInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<Card> cards = new List<Card>();

            foreach (var cardArgs in cardsInfo)
            {
                string face = cardArgs.Split()[0];
                string suit = cardArgs.Split()[1];
                
                try
                {
                    Card card = CreateCard(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(' ', cards));
        }

        private static Card CreateCard(string face, string suit)
        {
            HashSet<string> faces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            Dictionary<string, string> suits = new Dictionary<string, string>
            {
                {"S", "\u2660"},
                {"H", "\u2665"},
                {"D", "\u2666"},
                {"C", "\u2663"},
            };

            if (faces.All(f => f != face) || suits.All(s => s.Key != suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            Card card = new Card(face, suits[suit]);

            return card;
        }
    }
}

