using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class BPnode
    {
        public Weapon w;
        public BPnode next;

        public BPnode(Weapon weap)
        {
            w = weap;
            next = null;
        }
    }
}
