using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Checkpoint4.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int clientID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage="Please enter a first name")]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter a last name")]
        public string lastName { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Please enter an address")]
        public string address { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Please enter a city")]
        public string city { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "Please enter a state")]
        public string state { get; set; }

        [DisplayName("Zipcode")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Zip code must have 5 digits")]
        [Required(ErrorMessage = "Please enter a zip code")]
        public string zip { get; set; }

        [DisplayName("Email")]
        [RegularExpression(".{0,}@.{0,}", ErrorMessage = "Email must contain the following character: @")]
        [Required(ErrorMessage = "Please enter an email address")]
        public string email { get; set; }

        [DisplayName("Phone Number")]
        [RegularExpression(@"[0-9]?-?\([0-9]{3}\)-? ?[0-9]{3}-[0-9]{4}", ErrorMessage = "Phone must be in this format: (xxx) xxx-xxxx")]
        [Required(ErrorMessage = "Please enter a phone number")]
        public string phone { get; set; }
    }
}