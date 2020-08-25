﻿namespace ShopOnline.Northwind.Entities.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductIName { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}