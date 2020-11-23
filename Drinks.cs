using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4
{


    class Drink
    {
        public int volume = 0;//объем
        public static Random rnd = new Random();

        public virtual String GetInfo()
        {
            var str = String.Format($"\nОбъем(литр): {this.volume}");
            return str;
        }
        public virtual String GetName()
        {
            return "\tЭто последний элемент";
        }
    }
    //сок
    public enum FruitType { lemon, watermelon, melon };
    public enum fruitPieces { есть, нету};
    class Juice : Drink
    {
        public FruitType fruit = FruitType.lemon ;//фрукт
        public fruitPieces fruitPieces;//мякоть

        public override String GetInfo()
        {
            var str = "Сок";
            str += base.GetInfo();
            str += String.Format($"\nС фруктом: {this.fruit}");
            str += String.Format($"\nНаличие мякоти: {this.fruitPieces}");
            return str;
        }
        public override String GetName()
        {
            return "\tСок";
        }
        public static Juice Generate()
        {
            return new Juice
            {
                volume = rnd.Next(1, 5),
                fruit = (FruitType)rnd.Next(3),
                fruitPieces = (fruitPieces)rnd.Next(2) 
            };
        }
    }
    //газировка
    public enum SodaType { pepsi, sprite, mirinda};
    class Soda : Drink
    {
        
        public SodaType soda = SodaType.pepsi;
        public int numBubbles = 0; // кол-во пузырьков

        public override String GetInfo()
        {
            var str = "Газировка";
            str += base.GetInfo();
            str += String.Format($"\nТип: {this.soda}");
            str += String.Format($"\nКол-во пузырьков: {this.numBubbles}");
            return str;
        }
        public override String GetName()
        {
            return "\tГазировка";
        }
        public static Soda Generate()
        {
            return new Soda
            {
                volume = rnd.Next(1, 5),
                soda = (SodaType)rnd.Next(3),
                numBubbles = rnd.Next() % 101
            };
        }
    }
    //алкоголь
    public enum AlcoholType { vodka, beer, cognac };
    class Alcohol : Drink
    {
        public AlcoholType alcohol = AlcoholType.vodka;
        public int strength = 0; //крепость

        public override String GetInfo()
        {
            var str = "Алкоголь";
            str += base.GetInfo();
            str += String.Format($"\nТип: {this.alcohol}");
            str += String.Format($"\nКрепость: {this.strength}");
            return str;
        }
        public override String GetName()
        {
            return "\tАлкоголь";
        }
        public static Alcohol Generate()
        {
            var test = new Alcohol {
                volume = rnd.Next(1, 5),
                alcohol = (AlcoholType)rnd.Next(3),
                strength = 5
            };
            if (test.alcohol == AlcoholType.vodka)
            {
                test.strength = rnd.Next(37, 41);
            }
            else if (test.alcohol == AlcoholType.beer)
            {
                test.strength = rnd.Next(3, 8);
            }
            else
            {
                test.strength = rnd.Next(43, 50);
            }
            return test;
        }
        
    }



}
