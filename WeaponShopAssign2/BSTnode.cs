using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class BSTnode
    {
        public Weapon w;
        public BSTnode left;
        public BSTnode right;

        public BSTnode(Weapon weap)
        {
            w = weap;
            left = null;
            right = null;
        }
    }
}
