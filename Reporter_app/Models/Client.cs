using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporter_app.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string nameClient { get; set; }

        public string lastNameClient { get; set; }

        public int accountNumberClient { get; set; }

        public int accountTypeClient { get; set; }

    }
}