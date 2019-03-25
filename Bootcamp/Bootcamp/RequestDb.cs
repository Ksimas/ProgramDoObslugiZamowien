using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp
{
    public class RequestDb
    {
        public string Client_Id { get; set; }
        public long Request_Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public RequestDb(string client_Id, long request_Id, string name, int quantity, double price)
        {
            Client_Id = client_Id;
            Request_Id = request_Id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }
}
