using System;
using System.Collections.Generic;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Croupier croupier = new Croupier();

            croupier.Play();
        }
    }

    class Croupier
    {
        private Player _player = new Player();
        private Deck _cardDeck = new Deck();

        public void Play()
        {
            bool isActive = true;

            int userInput = 0;

            while (isActive)
            {
                Console.Clear();

                Console.WriteLine("Карты в колоде:");

                _cardDeck.ShowCards();

                Console.WriteLine("\n\nКарты у игрока:");

                _player.ShowCards();

                Console.WriteLine("\nСколько вытянуть карт?");

                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    if (_cardDeck.HasEnougth(userInput))
                    {
                        for (int i = 0; i < userInput; i++)
                        {
                            Card card = _cardDeck.GiveCard();
                            _player.TakeCard(card);
                        }
                    }
                    else
                    {
                        Console.WriteLine("В колоде меньше карт.");
                        Console.ReadKey();
                    }

                    if (_cardDeck.IsEmpty())
                    {
                        isActive = false;

                        Console.Clear();
                        Console.WriteLine("В колоде закончились карты");
                        Console.ReadKey();
                    }
                }
            }
        }            
    }

    class Player
    {
        private List<Card> _takenCards = new List<Card>();

        public void TakeCard(Card card)
        {
            _takenCards.Add(card);
        }

        public void ShowCards()
        {
            int lineLength = 0;
            int lineSize = 3;

            foreach (var cardItem in _takenCards)
            {
                Console.Write($"[{cardItem.Suit} {cardItem.Rank}]\t\t");

                if (lineLength == lineSize)
                {
                    lineLength = 0;
                    Console.WriteLine();
                }
                else
                {
                    lineLength++;
                }
            }
        }
    }

    class Deck
    {
        private Stack<Card> _cards = new Stack<Card>();

        public Deck()
        {
            Create();
        }

        public bool IsEmpty()
        {
            return _cards.Count == 0;
        }

        public bool HasEnougth(int nededCards)
        {
            return _cards.Count >= nededCards;
        }

        public Card GiveCard()
        {
            return _cards.Pop();
        }

        public void ShowCards()
        {
            int lineLength = 0;
            int lineSize = 3;

            foreach (var cardItem in _cards)
            {
                Console.Write($"[{cardItem.Suit} {cardItem.Rank}]\t\t");

                if (lineLength == lineSize)
                {
                    lineLength = 0;
                    Console.WriteLine();
                }
                else
                {
                    lineLength++;
                }
            }
        }

        private void Create()
        {
            List<Card> allCards = new List<Card>();

            GenerateCards(allCards);

            Shuffle(allCards);

            Add(allCards);
        }

        private void GenerateCards(List<Card> allCards)
        {
            string[] suits = { "♠", "♣", "♦", "♥" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Королева", "Король", "Туз" };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    allCards.Add(new Card(suits[i], ranks[j]));
                }
            }
        }

        private void Shuffle(List<Card> allCards)
        {
            Random random = new Random();
            Card tempCard;

            int tempPosition = 0;
            int count = allCards.Count;

            for (int i = 0; i < count; i++)
            {
                tempPosition = random.Next(0, count);
                tempCard = allCards[tempPosition];
                allCards[tempPosition] = allCards[i];
                allCards[i] = tempCard;
            }
        }

        private void Add(List<Card> allCards)
        {
            foreach (var card in allCards)
            {
                _cards.Push(card);
            }
        }
    }

    class Card
    {
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public string Suit { get; private set; }
        public string Rank { get; private set; }
    }
}
