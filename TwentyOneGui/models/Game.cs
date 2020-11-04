using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGui.model
{
    public class Game
    {
        private List<Player> players;
        private Deck deck;
        private int turn;//player number who is currently the active player
        public Game ()
        {
            throw new NotImplementedException();
        }
        public void AddPlayer (string name)
        {
            // remove this
            throw new NotImplementedException();
        }
        public bool Finished ()
        {
            // checks if there is no players left who are interested in taking a card
            throw new NotImplementedException();
        }
        public void NextPlayer ()
        {
            if (Finished())
                throw new Exception("Nobody left to play");
           
           //Move on to the next player by choosing the next turn
            players[turn].SetTurn();
        }
        public Deck GetDeck() => deck;
        public Player GetPlayer (int id)
        {
            // return the player at id place
            throw new NotImplementedException();
        }
        public int CountPlayers() => players.Count;
        public int  GetCurrentPlayer ()
        {
            // get the number of the current player (the player who can take a card)
            throw new NotImplementedException();
        }
        public static int GetPoints (Player p)
        {
            // notice it is a static method!!
           // method gets player and returns by the games rules how many points the player has
            throw new NotImplementedException();
        }
        public void StartGame ()
        {
            foreach (Player p in players)
                p.StartNewGame();
            this.deck = new Deck();
            turn = new Random().Next(2);
        }


    }
}
