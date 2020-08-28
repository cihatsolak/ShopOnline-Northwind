﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Northwind.Entities.Concrete
{
    public class ShippingDetails
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(15, 75)]
        public int Age { get; set; }
    }
}
