using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGuestBook.Models;

public class Guest : Person
{ 
    public string MessageToHost { get; set; }

    public Guest(string firstName, string lastname, string messageToHost = "")
        : base(firstName, lastname)
    {
        MessageToHost = messageToHost;
    }
}
