using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGuestBook;

public class Person
{
    private static int _lastId;
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string firstName, string lastName)
    {
        Id = ++_lastId;
        FirstName = firstName;
        LastName = lastName;
    }
}
