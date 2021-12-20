using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechCraft;

namespace TechCraft.model
{
    public class Player : MovableEntity, IPlayer
    {
        private int _hunger, _maxHunger = 100;
        private int _health, _maxHealth = 100;
        private int _thirst, _maxThirst = 100;
        private bool _alive = true;

        protected int myTicks = 0;
        protected const int TICK_PERIOD = 10;

        public IInventory Backpack { get; protected set; }

        public Player(string name)
        {
            Name = name;
            Health = MaxHealth;
            Hunger = MaxHunger;
            Thirst = MaxThirst;
            Backpack = new Inventory(100);
        }

        public void Interact(IItem item, InteractionType type)
        {
            IItem[] retItems = item.Interact(type);
            Backpack.Remove(item);
            foreach (Item it in retItems)
                Backpack.StoreItem(it);
        }
        public override void Update(int ticks)
        {
            myTicks += ticks;
            if (myTicks >= TICK_PERIOD)
            {
                // is player still alive?
                if (Health == 0)
                {

                }
                else
                {
                    // update hunger and thirst; if none left, reduce health
                    if (Hunger > 0) Hunger -= 1;
                    else Health -= 1;
                    if (Thirst > 0) Thirst -= 1;
                    else Health -= 1;
                    // more health, if full hunger
                    if (Hunger == MaxHunger * 0.9 && Health < MaxHealth)
                    {
                        Health += 1;
                    }
                }
                myTicks -= TICK_PERIOD - 1;
            }
        }

        public override string ToString()
        {
            string retString = Name + " - Health: " + Health;
            retString += "\nHunger: " + Hunger;
            retString += "\nThirst: " + Thirst;
            retString += "\nInventory: " + Backpack;

            return retString;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        // Properties
        public int Hunger
        {
            get { return _hunger; }
            protected set
            {
                _hunger = value;
                RaisePropertyChanged("Hunger");
            }
        }
        public int MaxHunger
        {
            get { return _maxHunger; }
            protected set
            {
                _maxHunger = value;
                RaisePropertyChanged("MaxHunger");
            }
        }
        public int Health
        {
            get { return _health; }
            protected set
            {
                _health = value;
                RaisePropertyChanged("Health");
            }
        }
        public int MaxHealth
        {
            get { return _maxHealth; }
            protected set
            {
                _maxHealth = value;
                RaisePropertyChanged("MaxHealth");
            }
        }
        public int Thirst
        {
            get { return _thirst; }
            protected set
            {
                _thirst = value;
                RaisePropertyChanged("Thirst");
            }
        }
        public int MaxThirst
        {
            get { return _maxThirst; }
            protected set
            {
                _maxThirst = value;
                RaisePropertyChanged("MaxThirst");
            }
        }
        public bool Alive
        {
            get { return _alive; }
            protected set
            {
                _alive = value;
                RaisePropertyChanged("Alive");
            }
        }
    }
}
