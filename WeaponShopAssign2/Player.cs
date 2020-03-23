using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class Player
    {
        public string name;
        public int numItems;
        public double money;
        public Backpack bp;

        public Player(string n, double m)
        {
            name = n;
            money = m;
            numItems = 0;
            bp = new Backpack();
        }

        public void buy(Weapon w)
        {
            Console.WriteLine(w.weaponName+" bought...");
            bp.addWeapon(w);
            //backpack[numItems] = w;
            numItems++;
            Console.Write(numItems);
        }
        public void withdraw(double amt)
        {
            money = money - amt;
        }

        public bool inventoryFull()
        {
            bool full = false;
            if (numItems == 10) full = true;
            return full;
        }


        public void printCharacter()
        {
            Console.WriteLine(" Name:"+name+"\n Money:"+money);
            printBackpack();
        }

        public void printBackpack()
        {
            /*Console.WriteLine(" "+name+", you own "+numItems+" Weapons:");
            for (int x = 0; x < numItems; x++)
            {
                Console.WriteLine(" "+backpack[x].weaponName);
            }
            Console.WriteLine();*/
            bp.printBackpack();
        }
    }
}
