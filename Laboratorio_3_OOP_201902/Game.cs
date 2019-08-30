using Laboratorio_3_OOP_201902.Cards;
using Laboratorio_3_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laboratorio_3_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private Board boardGame;
        private bool endGame;
        private List<Card> captains;
        //Constructor
        public Game()
        {
            List<Deck> decks = new List<Deck>();
            this.decks = decks;
            Deck deck1 = new Deck();
            Deck deck2 = new Deck();
            decks.Add(deck1);
            decks.Add(deck2);
            List<Card> captains = new List<Card>();
            this.captains = captains;


        }

        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }
        public bool EndGame
        {
            get
            {
                return this.endGame;
            }
            set
            {
                endGame = value;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Play()
        {
            throw new NotImplementedException();
        }

        public void DeckReader()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files\Decks.txt";
            StreamReader File = new StreamReader(path);
            List<Card> cards1 = new List<Card>();
            List<Card> cards2 = new List<Card>();
            int i = 0;
            while (!File.EndOfStream)
            { 
                string line = File.ReadLine();
                string[] items = line.Split(",");
                if (i == 0)
                {
                    switch (items[0])
                    {

                        case "CombatCard":
                            cards1.Add(new CombatCard(items[1], (EnumType)Enum.Parse(typeof(EnumType), items[2]),
                                (EnumType)Enum.Parse(typeof(EnumType), items[3]), 
                                Convert.ToInt32(items[4]), 
                                Convert.ToBoolean(items[5])));
                            break;
                        case "SpecialCard":
                            cards1.Add(new SpecialCard(items[1],
                                (EnumType)Enum.Parse(typeof(EnumType), items[2])
                                , (EnumType)Enum.Parse(typeof(EnumType), items[3])));
                            break;
                        case "END":
                            Console.WriteLine("Debug", i);
                            decks[i].Cards = cards1;
                            i++;
                            break;
                    }
                }
                if (i == 1)
                {
                    switch (items[0])
                    {

                        case "CombatCard":
                            cards2.Add(new CombatCard(items[1], (EnumType)Enum.Parse(typeof(EnumType), items[2]),
                                (EnumType)Enum.Parse(typeof(EnumType), items[3]),
                                Convert.ToInt32(items[4]),
                                Convert.ToBoolean(items[5])));
                            break;
                        case "SpecialCard":
                            cards2.Add(new SpecialCard(items[1],
                                (EnumType)Enum.Parse(typeof(EnumType), items[2])
                                , (EnumType)Enum.Parse(typeof(EnumType), items[3])));
                            break;
                        case "END":
                            decks[i].Cards = cards2;
                            break;
                    }
                }
            }
            File.Close();
        }

        public void CaptainsReader()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files\Captains.txt";
            StreamReader File = new StreamReader(path);
            while (!File.EndOfStream)
            {
                string line = File.ReadLine();
                string[] items = line.Split(",");
                switch (items[0])
                {
                    case "SpecialCard":
                        captains.Add(new SpecialCard(items[1],
                                (EnumType)Enum.Parse(typeof(EnumType), items[2])
                                , (EnumType)Enum.Parse(typeof(EnumType), items[3]))); 
                        break;
                }
            }
            File.Close();

        }
    }
}
