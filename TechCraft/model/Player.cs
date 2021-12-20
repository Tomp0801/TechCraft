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
        private float _hunger;
        private int _maxHunger = 100;
        private float _thirst;
        private int _maxThirst = 100;
        private float _health;
        private int _maxHealth = 100;
        private bool _alive = true;

        protected const float HEAL_MIN_HUNGER = 0.9f;

        protected float hungerRate = 0.05f;
        protected float thirstRate = 0.75f;
        protected float healthRate = 0.05f;

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
            // is player still alive?
            if (Alive)
            {
                // update hunger and thirst
                updateHunger(ticks * hungerRate * -1);
                updateThirst(ticks * thirstRate * -1);
                // if no hunger or thirst left, reduce health
                if (Hunger == 0) updateHealth(healthRate * -1);
                if (Thirst == 0) updateHealth(healthRate * -1);
                // more health, if full hunger
                if (_hunger > MaxHunger * HEAL_MIN_HUNGER) updateHealth(healthRate);

                // check if still alive
                if (Health == 0) Alive = false;
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

        protected void updateHunger(float change)
        {
            if (_hunger > 0)
            {
                _hunger += change;
                if (_hunger < 0) _hunger = 0;
                if (_hunger > MaxHunger) _hunger = MaxHunger;
                RaisePropertyChanged("Hunger");
            }
        }
        protected void updateThirst(float change)
        {
            if (_thirst > 0)
            {
                _thirst += change;
                if (_thirst < 0) _thirst = 0;
                if (_thirst > MaxThirst) _thirst = MaxThirst;
                RaisePropertyChanged("Thirst");
            }
        }
        protected void updateHealth(float change)
        {
            if (_health > 0)
            {
                _health += change;
                if (_health < 0) _health = 0;
                if (_health > MaxHealth) _health = MaxHealth;
                RaisePropertyChanged("Health");
            }
        }

        // Properties
        public int Hunger
        {
            get { return (int)Math.Round(_hunger); }
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
            get { return (int)Math.Round(_health); }
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
            get { return (int)Math.Round(_thirst); }
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
