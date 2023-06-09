﻿using System.ComponentModel.DataAnnotations;

public class Contact
{
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"{ID}|{LastName}|{FirstName}|{MiddleName}|{Address}|{PhoneNumber}|{Description}";
    }
}
