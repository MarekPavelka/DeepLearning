using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Events
    {
        void Main(string[] args)
        {
            //Usage
            var senjin = new Minion();
            senjin.OnDying += MyReaction;

            var elvenArcher = new Minion();
            elvenArcher.OnDying += MyReaction;

            //senjin.OnDying += MyReaction;

            // 1. window.OnMinimized();

            //    { MyReaction, MyReaction2 }
            // 2. window.OnDamageReceived = MyReaction;


            //Action x = MyReaction;
            //// { MyReaction }
            //x += MyReaction2;
            //x -= MyReaction2;

        }

        void MyReaction(object sender, EventArgs eventArgs)
        {

        }

        void MyReaction2()
        {
        }
    }

    class Minion
    {
        public event EventHandler OnDying; // null
        public int Health { get; private set; }

        public void ReceiveDamage(int amount)
        {
            Health = Health - amount;



        }

        public void ReceiveKillEffect()
        {

            OnDying(this, new EventArgs());
        }

        private void RaiseOnDying()
        {
            OnDying?.Invoke(this, new EventArgs());
        }
    }
}
