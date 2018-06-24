using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    class Battery
    {
        private string batteryType;
        private double batteryLife;

        public Battery(string batteryType, double batteryLife)
        {
            this.BatteryType = batteryType;
            this.BatteryLife = batteryLife;
        }
        
        public string BatteryType
        {
            get { return this.batteryType; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.batteryType = value;
                }
                else
                {
                    throw new Exception("Invalid battery type");
                }
            }
        }

        public double BatteryLife
        {
            get { return this.batteryLife; }
            set
            {
                if(value > 0)
                {
                    this.batteryLife = value;
                }
                else
                {
                    throw new Exception("Invalid battery life");
                }
            }
        }
    }
}
