using System;

namespace WeaponShopAssign2
{
    class Program
    {

        public static void showMainMenu()
        {
            Console.Clear();
            Console.WriteLine("==============Main Menu=============");
            Console.WriteLine("1: Add Items to the shop");
            Console.WriteLine("2: Delete Items from the shop");
            Console.WriteLine("3: Buy from the shop");
            Console.WriteLine("4: View backpack");
            Console.WriteLine("5: View Player");
            Console.WriteLine("6: Exit");
        }

        public static int getValidChoice()
        {
            int choice;
            showMainMenu();
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 6))
            {
                showMainMenu();
                Console.WriteLine("Please enter a valid choice:");
            }
            return choice;
        }

        public static void addWeapons(BST shop)
        {
            Console.Clear();
            Console.WriteLine("***********WELCOME TO THE WEAPON ADDING MENU*********");

            string weaponName; int weaponRange; int weaponDamage; double weaponWeight; double weaponCost;
            Console.WriteLine("Please enter the NAME of the Weapon ('end' to quit):");
            weaponName=Console.ReadLine();
            while (weaponName.CompareTo("end") != 0)
            {
                Console.WriteLine("Please enter the Range of the Weapon (0-10):");
                weaponRange= Convert.ToInt32(Console.ReadLine()); 
                Console.WriteLine("Please enter the Damage of the Weapon:");
                weaponDamage=Convert.ToInt32(Console.ReadLine()); 
                Console.WriteLine("Please enter the Weight of the Weapon (in pounds):");
                weaponWeight= Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter the Cost of the Weapon:");
                weaponCost=Convert.ToDouble(Console.ReadLine());
                Weapon w = new Weapon(weaponName, weaponRange, weaponDamage, weaponWeight, weaponCost);
                shop.insert(w);
                Console.WriteLine("Please enter the NAME of another Weapon ('end' to quit):");
                weaponName = Console.ReadLine();
            }
        }

        public static void showRoom(BST shop, Player p)
        {
            Console.Clear();
            string choice;
            Console.WriteLine("WELCOME TO THE SHOWROOM!!!!");
            shop.inOrder();
            Console.WriteLine(" You have "+p.money+" money.");
            Console.WriteLine("Please select a weapon to buy('end' to quit):");
            choice=Console.ReadLine();
            while (choice.CompareTo("end") != 0)
            {
                if (!p.inventoryFull())
                {
                    if (shop.search(choice) != null)
                    {
                        Weapon w = shop.search(choice).w;
                            if (w.cost > p.money)
                            {
                                Console.WriteLine("Insufficient funds to buy " + w.weaponName);
                            }
                            else if (p.bp.maxWeight < (p.bp.presentWeight + w.weight))
                            {
                                Console.WriteLine("Buying this items causes the backpack to exceed max weight! Item not bought.\nPress any key to continue.");
                                Console.ReadKey();
                            }
                            else
                            {
                                p.buy(w);
                                p.withdraw(w.cost);
                            }
                        /*else
                        {
                            Console.WriteLine(" ** " + choice + " not found!! **");
                        }
                        Console.WriteLine("Please select another weapon to buy('end' to quit):");
                        choice = Console.ReadLine();
                    }
                    /*Weapon w = shop.search(choice).w;
                    if (w != null)
                    {
                        if (w.cost > p.money)
                        {
                            Console.WriteLine("Insufficient funds to buy " + w.weaponName);
                        }
                        else if(p.bp.maxWeight < (p.bp.presentWeight + w.weight))
                        {
                            Console.WriteLine("Buying this items causes the backpack to exceed max weight! Item not bought.\nPress any key to continue.");
                            Console.ReadKey();
                        }
                        else
                        {
                            p.buy(w);
                            p.withdraw(w.cost);
                        }*/
                    }
                    else
                    {
                        Console.WriteLine(" ** " + choice + " not found!! **");
                    }
                    Console.WriteLine("Please select another weapon to buy('end' to quit):");
                    choice = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Inventory is full!\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                }
               /* Weapon w = shop.search(choice).w;
                if (w != null)
                {
                    if (w.cost > p.money)
                    {
                        Console.WriteLine("Insufficient funds to buy "+w.weaponName );
                    }
                    else
                    {
                        p.buy(w);
                        p.withdraw(w.cost);
                    }
                }
                else
                {
                    Console.WriteLine(" ** "+choice+" not found!! **" );
                }
                Console.WriteLine("Please select another weapon to buy('end' to quit):");
                choice = Console.ReadLine();*/
            }
        }

        public static void viewBackpack(Player p)
        {
            Console.Clear();
            Console.WriteLine("=====Player Backpack=====");
            p.bp.printBackpack();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void viewPlayer(Player p)
        {
            Console.Clear();
            Console.WriteLine("=====Player Information=====");
            p.printCharacter();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void deleteWeapon(BST shop)
        {
            Console.Clear();
            Console.WriteLine("=====Delete weapon from shop=====");
            shop.inOrder();
            Console.WriteLine("Enter the weapon you wish to delete");
            string choice = Console.ReadLine();
            if (shop.search(choice) != null)
            {
                shop.delete(choice);
                Console.WriteLine(choice + " deleted, Press any key to continue");
            }
            else
            {
                Console.WriteLine(" ** " + choice + " not found!! Press any key to continue**");
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            string pname;
            Console.WriteLine("Please enter Player name:");
            pname=Console.ReadLine();
            Player pl= new Player(pname,45);
            BST shop = new BST();
            int choice = getValidChoice();
            while (choice != 6)
            {
                showMainMenu();
                if (choice == 1) { addWeapons(shop); }
                if (choice == 2) { deleteWeapon(shop); }
                if (choice == 3) { showRoom(shop,pl); }
                if (choice == 4) { viewBackpack(pl); }
                if (choice == 5) { viewPlayer(pl); }
                choice = getValidChoice();
            }

           /* addWeapons(shop);
            showRoom(shop, pl);
            //HashTable ht= new HashTable(101);
            // addWeapons(ht);
            //showRoom(ht, pl);
            Weapon x = new Weapon("sword", 3, 5, 40, 10.5);
            pl.buy(x);
            pl.printCharacter();
            Console.ReadKey();
            BST bst = new BST();
            Weapon x = new Weapon("sword", 3, 5, 40, 10);
            Weapon y = new Weapon("bow", 3, 7, 5, 10.15);
            Weapon z = new Weapon("spear", 3, 2, 15, 5);
            Weapon zz = new Weapon("zspear", 3,27, 15, 35);
            bst.insert(zz);
            bst.insert(x);
            bst.insert(y);
            bst.insert(z);
            bst.inOrder();
            Console.WriteLine(bst.search("7spear"));*/


        }
    }
}
