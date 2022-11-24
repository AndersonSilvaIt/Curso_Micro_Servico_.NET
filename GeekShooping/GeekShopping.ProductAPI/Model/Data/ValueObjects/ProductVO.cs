﻿namespace GeekShopping.ProductAPI.Model.Data.ValueObjects
{
    public class ProductVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}