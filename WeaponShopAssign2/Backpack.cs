using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{   // This class implements a backpack as a linked list
    // The backpack can hold any number of weapons as long as maxWeight is not crossed.
    // If an attempt to add a weapon to backpack is rejected due to weight
    class Backpack
    {
        public double maxWeight;
        public double presentWeight;
        public BPnode head;

        public Backpack()
        {
            maxWeight = 30;
            presentWeight = 0;
            head = null;
        }

        public bool addWeapon(Weapon w)
        {
            if (maxWeight < (presentWeight + w.weight))
            {
                return false;
            }

            BPnode nn = new BPnode(w);
            presentWeight += nn.w.weight;

            if (head == null)
            {
                head = nn;

                return true;
            }

            BPnode current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = nn;
            return true;
        }

        public void printBackpack()
        {
            Console.Write("Backpack: ");
            BPnode current = head;
            while (current != null)
            {
                Console.Write("{0}, ", current.w.weaponName);
                current = current.next;
            }
            Console.WriteLine();
        }

    }
}
