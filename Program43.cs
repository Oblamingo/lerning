using System;
using System.Collections.Generic;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();

            market.GenerateItems();
            market.ShowMarket();
        }
    }

    class Market
    {
        private Buyer _buyer = new Buyer();
        private Seller _seller = new Seller();

        private void ShowErrorMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public void ShowMarket()
        {
            bool isActive = true;

            int userInput = 0;

            while (isActive)
            {
                Console.Clear();

                _seller.Show();
                _buyer.Show();

                Console.WriteLine("\nКакой предмет купить?");

                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    userInput--;

                    Item item = _seller.GiveItem(userInput);

                    if (_buyer.IsEnoughMoney(item))
                    {
                        _buyer.BuyItem(item);

                        if (_seller.IsEmpty())
                        {
                            isActive = false;

                            ShowErrorMessage("У продавца кончились товары");
                        }
                    }
                    else
                    {
                        isActive = false;

                        ShowErrorMessage("У покупателя кончились деньги");
                    }
                }
                else
                {
                    ShowErrorMessage("Не верный ввод");
                }
            }
        }

        public void GenerateItems()
        {
            _seller.TakeItems(new Item("Видеокарта", "MSI GeForce 210", 2899));
            _seller.TakeItems(new Item("Видеокарта", "INNO3D GeForce GT 710 Silent LP", 3499));
            _seller.TakeItems(new Item("Видеокарта", "GIGABYTE GeForce GT 730", 4999));
            _seller.TakeItems(new Item("Материнская плата", "MSI PRO H610M-E DDR4", 6999));
            _seller.TakeItems(new Item("Материнская плата", "MSI MPG B550 GAMING PLUS", 14999));
            _seller.TakeItems(new Item("Материнская плата", "GIGABYTE B550 AORUS ELITE V2", 15999));
            _seller.TakeItems(new Item("Блок питания", "DEEPCOOL DQ750", 10799));
            _seller.TakeItems(new Item("Блок питания", "DEEPCOOL PF600", 5099));
            _seller.TakeItems(new Item("Блок питания", "AeroCool VX PLUS 500W", 2899));
            _seller.TakeItems(new Item("Мышка", "ARDOR GAMING Fury", 1699));
            _seller.TakeItems(new Item("Мышка", "LAMZU Atlantis", 5999));
            _seller.TakeItems(new Item("Мышка", "Logitech G PRO X SUPERLIGHT", 14299));
        }
    }

    class Person
    {
        public List<Item> _items;

        public int _money = 0;

        public string _name = string.Empty;

        public void TakeItems(Item item)
        {
            _items.Add(item);
        }

        public void Show()
        {
            ShowMoney();
            ShowItems();            
        }

        private void ShowItems()
        {
            int counter = 0;

            Console.WriteLine($"{_name} вещи:");

            foreach (Item item in _items)
            {
                counter++;

                Console.Write($"#[{counter}]\t[{item.Title} {item.Description} {item.Price}р ]\n");
            }

            Console.WriteLine();
        }

        private void ShowMoney()
        {
            Console.WriteLine($"{_name} деньги:{_money}р");
        }
    }

    class Buyer : Person
    {
        public Buyer()
        {
            _items = new List<Item>();
            _money = 15000;
            _name = "Покупатель";
        }

        public bool IsEnoughMoney(Item item)
        {
            int selled = _money - item.Price;

            return selled > 0;
        }

        public void BuyItem(Item item)
        {
            _money -= item.Price;

            TakeItems(item);
        }

    }

    class Seller : Person
    {
        public Seller()
        {
            _items = new List<Item>();
            _name = "Продавец";
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }

        public Item GiveItem(int itemNumber)
        {
            Item tempItem = _items[itemNumber];

            _items.RemoveAt(itemNumber);

            return tempItem;
        }
    }

    class Item
    {
        public Item(string title, string description, int price)
        {
            Title = title;
            Description = description;
            Price = price;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Price { get; private set; }
    }
}
