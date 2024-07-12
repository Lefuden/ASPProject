﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPProjectFrontend.Models;

public class Address
{
    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Country must be between 1 and 50 characters")]
    public string Country { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Street address must be between 1 and 50 characters")]
    [DisplayName("Street Address")]
    public string StreetAddress { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "City must be between 1 and 50 characters")]
    [DisplayName("City")]
    public string City { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 1, ErrorMessage = "Zip code must be between 1 and 10 characters")]
    [DisplayName("Zip Code")]
    public string ZipCode { get; set; }
}