using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class BST
    {
        BSTnode root;

        public BST()
        {
            root = null;
        }

        public void insert(Weapon w)
        {
            root = insertWorker(root, w);
        }

        private BSTnode insertWorker(BSTnode current, Weapon w)
        {
            if(current == null)
            {
                return new BSTnode(w);
            }
            if (w.weaponName.CompareTo(current.w.weaponName) < 0)
            {
                current.left = insertWorker(current.left, w);
            }
            if (w.weaponName.CompareTo(current.w.weaponName) > 0)
            {
                current.right = insertWorker(current.right, w);
            }
            return current;
        }

        public void inOrder()
        {
            inOrderWorker(root);
            Console.WriteLine();
        }

        private void inOrderWorker(BSTnode current)
        {
            if (current == null) return;
            inOrderWorker(current.left);
            Console.WriteLine("Name: "+current.w.weaponName+"    Damage: "+current.w.damage+ "    Weight: "+current.w.weight+"    Cost: " +current.w.cost);
            inOrderWorker(current.right);
        }

        public BSTnode search(string key)
        {
            return searchWorker(root, key);
        }

        private BSTnode searchWorker(BSTnode current, string key)
        {
            if (current == null) return null;
            if (current.w.weaponName == key) return current;
            if(current.w.weaponName.CompareTo(key)>0) return searchWorker(current.left, key);
            return searchWorker(current.right, key);
        }

        public void delete(string key)
        {
            root = deleteWorker(root, key);
        }

        public BSTnode deleteWorker(BSTnode current, string key)
        {
            if (current == null) return current;
            else if (key.CompareTo(current.w.weaponName) < 0) current.left = deleteWorker(current.left, key);
            else if (key.CompareTo(current.w.weaponName) >  0) current.right = deleteWorker(current.right, key);

            if (current.w.weaponName == key)
            {
                if (current.left == null) return current.right;
                if (current.right == null) return current.left;

                BSTnode successor = current.right;
                while (successor.left != null)
                    successor = successor.left;
                current.w = successor.w;
                current.right = deleteWorker(current.right, current.w.weaponName);
            }
            return current;
        }
    }
}
