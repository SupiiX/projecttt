using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ObservableObject = Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject;

namespace Frontend.Models
{
    public class Trooper : ObservableObject
    {
        private string type;
        private int power;
        private int vitality;
        private int cost;

        public Trooper GetCopy() {
            return new Trooper()
            {
                Type = this.Type,
                Power = this.Power,
                Vitality = this.Vitality,
                Cost = this.Cost
            };
        }

        public string Type { 
            get { return type; }
            set { SetProperty(ref type, value); }
        }
        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }
        public int Vitality
        {
            get { return vitality; }
            set { SetProperty(ref vitality, value); }
        }

        public int Cost { 
            get { return cost; }
            set { SetProperty(ref cost, value); }
        }
        //public int Cost { get { return vitality * power; } }
    }
}
