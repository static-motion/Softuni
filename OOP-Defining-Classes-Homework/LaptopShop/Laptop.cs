using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private int price;
        public Laptop(string model, string manufacturer, string processor, int ram, string graphicsCard, string hdd, string screen, Battery battery, int price)
        {
            Model = model;
            Manufacturer = manufacturer;
            Processor = processor;
            Ram = ram;
            GraphicsCard = graphicsCard;
            Hdd = hdd;
            Screen = screen;
            BatteryInfo = battery;
            Price = price;         
        }
        public Laptop(string model, int price)
        {
            Model = model;
            Price = price;  
        }
        public Laptop(string model, string processor, string graphicsCard, int ram, int price)
        {
            Model = model;
            Processor = processor;
            GraphicsCard = graphicsCard;
            Ram = ram;
            Price = price;
        }
        public Laptop(string model, string manufacturer, Battery battery, int price)
        {
            Model = model;
            Manufacturer = manufacturer;
            BatteryInfo = battery;
            Price = price;
        }
        public string Model
        {
            get { return this.model; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.model = value;
                }
                else
                {
                    throw new Exception("Invalid model data");
                }
            }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    this.manufacturer = value;
                }
                else
                {
                    throw new Exception("Invalid manufacturer data");
                }
            }
        }
        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.processor = value;
                }
                else
                {
                    throw new Exception("Invalid processor data");
                }
            }
        }
        public int Ram
        {
            get { return this.ram; }
            set
            {
                if(value > 0)
                {
                    this.ram = value;
                }
                else
                {
                    throw new Exception("Invalid RAM data");
                }
            }
        }
        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.graphicsCard = value;
                }
                else
                {
                    throw new Exception("Invalid GPU data");
                }
            }
        }
        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.hdd = value;
                }
                else
                {
                    throw new Exception("Invalid HDD data");
                }
            }
        }
        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.screen = value;
                }
                else
                {
                    throw new Exception("Invalid screen data");
                }
            }
        }
        public Battery BatteryInfo
        {
            get { return this.battery; }
            set { this.battery = value;}
        }
        public int Price
        {
            get { return this.price; }
            set
            {
                if(value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new Exception("Invalid price data");
                }
            }
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(this.model);
            if(!string.IsNullOrEmpty(this.manufacturer))
            {
                output.AppendLine(this.manufacturer);
            }
            if(!string.IsNullOrEmpty(this.processor))
            {
                output.AppendLine(this.processor);
            }
            if(this.ram != 0)
            {
                output.AppendLine(this.ram.ToString());
            }
            if(!string.IsNullOrEmpty(this.graphicsCard))
            {
                output.AppendLine(this.graphicsCard);
            }
            if(!string.IsNullOrEmpty(this.hdd))
            {
                output.AppendLine(this.hdd);
            }
            if(!string.IsNullOrEmpty(this.screen))
            {
                output.AppendLine(this.screen);
            }
            if (BatteryInfo != null) 
            {
                output.AppendLine(battery.BatteryType);
                output.AppendLine(battery.BatteryLife.ToString());
            }
            output.Append(price.ToString());
            return output.ToString();
        }
    }
}
