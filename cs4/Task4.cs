using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs4
{
    struct Article
    {
        public Article(uint _code, string _name, double _price)
        {
            code = _code;
            name = _name;
            price = _price;
        }
        //-- код товару;
        public uint code;
        //-- назва товару;
        public string name;
        //-- ціна товару.
        public double price;
    }
    class Client
    {
        public Client(string _fullName)
        {
            clientCode = clientCounter++;
            fullName = _fullName;
        }
        static uint clientCounter;
        static Client() { clientCounter = 1; }
        public override string ToString()
        {
            return $"Cliet Code: {clientCode}\t Name: {fullName}\t " +
                $"Orders: {ordersQuantity}\t Sum: {ordersTotalSum,5}\t " +
                $"Address: {address}\t Phone: {phoneNumber}";
        }
        //-- код клієнта;
        uint clientCode;
        //-- ПІБ;
        string fullName;
        public string Name { get => fullName; }
        //-- адреса;
        string address = "None";
        //-- телефон;
        string phoneNumber = "None";
        //-- кількість замовлень, поданих клієнтом;
        public uint ordersQuantity = 0;
        //-- загальна сума замовлень клієнта.
        public double ordersTotalSum = 0;
    }
    struct RequestItem
    {
        public RequestItem(Article _item, uint _quantity)
        {
            item = _item;
            quantity = _quantity;
        }
        //-- товар(структура Article);
        public Article item;
        //-- кількість одиниць товару.
        public uint quantity;
    }
    struct Request
    {
        public Request(ref Client _client)
        {
            order = orderCounter++;
            client = _client;
            dt = DateTime.Now;
            orderList = new List<RequestItem>();
        }
        static uint orderCounter;
        static Request() { orderCounter = 1; }
        public override string ToString()
        {
            return $"Request #{order}\t Sum: {orderSum, 5}\t Client: {client.Name}\t Date/Time: {dt}";
        }
        //-- код замовлення;
        uint order;
        //-- клієнт(посилання на об'єкт класу Client);
        public Client client;
        //-- дата замовлення (структура DateTime);
        DateTime dt;
        //-- перелік замовлених товарів(масив чи список структур RequestItem );
        List<RequestItem> orderList;
        //-- сума замовлення(реалізувати read-only властивістю, значення якої обчислюється в get-ері).
        double orderSum { get => orderList.Sum(x => x.item.price * x.quantity); }
        public void Add(RequestItem reqItem)
        {
            orderList.Add(reqItem);
            client.ordersQuantity += reqItem.quantity;
            client.ordersTotalSum += (reqItem.quantity * reqItem.item.price);
        }
        public void Remove(int index)
        {
            if (index >= 0 && index < orderList.Count)
            {
                client.ordersQuantity -= orderList[index].quantity;
                client.ordersTotalSum -= orderList[index].item.price * orderList[index].quantity;
                orderList.RemoveAt(index);
            }
            else
                throw new IndexOutOfRangeException();
        }

    }
}
