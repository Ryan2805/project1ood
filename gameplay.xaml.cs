using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace project1
{
    public partial class gameplay : Window
    {
         
        public gameplay()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Card
    {
        public string Suit { get; }
        public string Rank { get; }
        public int Value { get; }

        public Card(string suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }
    }

    public class Deck
    {
        private List<Card> cards;
        private Random random;

        public Deck()
        {
            InitializeDeck();
            random = new Random();
        }

        private void InitializeDeck()
        {
            cards = new List<Card>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    int value = GetCardValue(rank);
                    cards.Add(new Card(suit, rank, value));
                }
            }
        }

        private int GetCardValue(string rank)
        {
            if (int.TryParse(rank, out int value))
            {
                return value;
            }
            else if (rank == "Jack" || rank == "Queen" || rank == "King")
            {
                return 10;
            }
            else 
            {
                return 11; 
            }
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(0, i + 1);
                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }

        public Card DealCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty. Cannot deal cards.");
            }

            Card card = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return card;
        }
    }

    public class Hand
    {
        private List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int CalculateTotalValue()
        {
            int totalValue = 0;
            int numberOfAces = 0;

            foreach (Card card in cards)
            {
                totalValue += card.Value;
                if (card.Rank == "Ace")
                {
                    numberOfAces++;
                }
            }

            
            while (totalValue > 21 && numberOfAces > 0)
            {
                totalValue -= 10;
                numberOfAces--;
            }

            return totalValue;
        }
    }

    public class Player
    {
        public Hand Hand { get; }

        public Player()
        {
            Hand = new Hand();
        }

        public void Hit(Card card)
        {
            Hand.AddCard(card);
        }

        public void Stand()
        {
           
        }
    }

    public class BlackjackGame
    {
        private Deck deck;
        private List<Player> players;
        private Player dealer;

        public BlackjackGame()
        {
            deck = new Deck();
            players = new List<Player>();
            dealer = new Player();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void StartGame()
        {
            deck.Shuffle();

            foreach (Player player in players)
            {
                player.Hand.AddCard(deck.DealCard());
                player.Hand.AddCard(deck.DealCard());
            }

            dealer.Hand.AddCard(deck.DealCard());
            dealer.Hand.AddCard(deck.DealCard());
        }

        public void Hit(Player player)
        {
            player.Hit(deck.DealCard());
        }

        public void Stand(Player player)
        {
            
        }

       
    }
}

