using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1._2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var iPhone12 = new Good("IPhone 12");
            var iPhone11 = new Good("IPhone 11");
            var iPhone7 = new Good("IPhone 7");

            var shop = new Shop(new Warehouse());

            var warehouse = new Warehouse();

            warehouse.AddGoods(iPhone12, 10);
            warehouse.AddGoods(iPhone11, 1);
            warehouse.AddGoods(iPhone7, 7);

            warehouse.ShowGoods();
        }
    }

    internal class Good
    {
        public Good(string name)
        {
            if (name.Length == 0)
                throw new ArgumentException("Invalid name");

            Name = name;
        }

        public string Name { get; }
    }

    internal class Shop
    {
        private Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse ?? throw new NullReferenceException(nameof(warehouse));
        }
    }

    internal class Warehouse
    {
        private readonly List<Good> _goods;
        private readonly List<string> _goodsName;

        public Warehouse()
        {
            _goods = new List<Good>();
            _goodsName = new List<string>();
        }

        public void AddGoods(Good good, int count)
        {
            if (good == null)
                throw new NullReferenceException(nameof(good));

            if (count < 0)
                throw new ArgumentException();

            if (_goodsName.Contains(good.Name) == false)
                _goodsName.Add(good.Name);

            for (var i = 0; i < count; i++) _goods.Add(good);
        }

        public void ShowGoods()
        {
            if (_goodsName.Count == 0)
                throw new ArgumentException();

            if (_goods.Count == 0)
                throw new ArgumentException();

            for (var i = 0; i < _goodsName.Count; i++)
                Console.WriteLine($"{_goodsName[i]} Left: {_goods.Count(good => good.Name == _goodsName[i])}");
        }
    }
}