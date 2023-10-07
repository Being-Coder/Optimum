using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entities.Customer
{
    public class Customers
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string Initials { get; set; }
        public string Firstname { get; set; }
        public string Firstname_ascii { get; set; }
        public string Gender { get; set; }
        public string Firstname_Country_Rank { get; set; }
        public string Firstname_Country_Frequency { get; set; }
        public string Lastname { get; set; }
        public string Lastname_ascii { get; set; }
        public string Lastname_Country_Rank { get; set; }
        public string Lastname_Country_Frequency { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country_Code { get; set; }
        public string Country_Code_Alpha { get; set; }
        public string Country_Name { get; set; }
        public string Primary_Language_Code { get; set; }
        public string Primary_Language { get; set; }
        public int Balance { get; set; }
        public string Phone_Number { get; set; }
        public string Currency { get; set; }

        public Customers(int id, string salutation, string initials, string firstname, string firstname_ascii, string gender, string firstname_Country_Rank, string firstname_Country_Frequency, string lastname, string lastname_ascii, string lastname_Country_Rank, string lastname_Country_Frequency, string email, string password, string country_Code, string country_Code_Alpha, string country_Name, string primary_Language_Code, string primary_Language, int balance, string phone_Number, string currency)
        {
            Id = id;
            Salutation = salutation;
            Initials = initials;
            Firstname = firstname;
            Firstname_ascii = firstname_ascii;
            Gender = gender;
            Firstname_Country_Rank = firstname_Country_Rank;
            Firstname_Country_Frequency = firstname_Country_Frequency;
            Lastname = lastname;
            Lastname_ascii = lastname_ascii;
            Lastname_Country_Rank = lastname_Country_Rank;
            Lastname_Country_Frequency = lastname_Country_Frequency;
            Email = email;
            Password = password;
            Country_Code = country_Code;
            Country_Code_Alpha = country_Code_Alpha;
            Country_Name = country_Name;
            Primary_Language_Code = primary_Language_Code;
            Primary_Language = primary_Language;
            Balance = balance;
            Phone_Number = phone_Number;
            Currency = currency;
        }

        public Customers() { }

    }
}
