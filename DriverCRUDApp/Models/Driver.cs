using System.ComponentModel.DataAnnotations;
using shortid;
using shortid.Configuration;


namespace DriverCRUDApp.Models;

public class Driver
{
    
    public string Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    public string PhoneNumber { get; set; }


    public Driver()
    {
        Id = ShortId.Generate(new GenerationOptions(length: 8));
    }

    public Driver(string firstName, string lastName, string email, string phoneNumber)
    {
        Id = ShortId.Generate(new GenerationOptions(length: 8));
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public Driver(string[] entries)
    {
        Id = entries[0];
        FirstName = entries[1];
        LastName = entries[2];
        Email = entries[3];
        PhoneNumber = entries[4];
    }
}

