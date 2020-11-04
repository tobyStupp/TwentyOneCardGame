using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyOneGui.gui;

namespace TwentyOneGui.model
{
    public class Player
    {
        private string playerName;
        private List<Card> cards;
        private bool playing;
        private PlayerDisplayC display; //incharge of displaying cards on screen
        private bool lost;  // indicates if player has more than 21 points
        public Player (string name)
        {
            // remember to start a new hand of cards and indicate he wants to play
        }
        public void AddDisplay (PlayerDisplayC d)
        {
            this.display = d;
        }
        public void StartNewGame()
        {
            cards.Clear();
            playing = true;
            display.EraseCards();
        }
        public List<Card> GetCards ()
        {
            List<Card> copyC = new List<Card>();
            foreach (Card c in this.cards)
                copyC.Add(c);
            return copyC;
        }

      
        public void AddCard (Card c)
        {
            //
            if (!playing)
                throw new Exception("Player is no longer playing and cannot take a card");
            // add a card to the players collection
            // the display object will show the new card
            display.ShowNewCard();
           // check if the player went over the limit 
           //PUT IF!!
            {
                this.playing = false;
                display.LostPlayer();
            }
            //else //what happens if not over
                display.UnshowCurrentPlayer();

        }
        public string GetName() => throw new NotImplementedException();
       
        public bool IsPlaying() =>playing;

        public void StopBid()
        {
            // player doesn't want anymore cards
        }
        public int GetPoints ()
        {
            throw new NotImplementedException();
            // method will invoke the GetPoints in Game through the static method
            // if points are over 21, the method should indicate that the player lost and cannot continue
        }
        // returns to as whether the player can still play
        public bool Lost() => throw new NotImplementedException();
        public void UnsetTurn ()
        {
            display.UnshowCurrentPlayer();
        }
        public void SetTurn ()
        {
            display.ShowCurrentPlayer();
        }

    }
}
