using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BetterGuestBook.Models;
using GloboWeb.Console;

namespace BetterGuestBook
{
    public class GuestBook
    {
        private readonly List<Guest> _guests = [];
        private readonly string _pwd = "Abc@123";
        
        public bool Sign()
        {
            string firstName = Prompt.GetString("Please Enter Your First Name:  ");
            string lastName = Prompt.GetString("Please Enter Your Last Name:  ");
            string messageToHost = Prompt.GetString("Message to Host (optoinal):  ");

            return Add(new Guest(firstName, lastName, messageToHost));
        }
        public bool Add(Guest guest)
        {
            if (guest == null) return false;

            _guests.Add(guest);

            return true;
        }

        public void ViewGuests(bool asAdmin = false,string? pwd = null)
        {
            if (_guests == null) return;

            bool isAdmin = (pwd == null) ? false : pwd.Equals(_pwd);

            if (pwd != null && !isAdmin)
            {
                Message.Write("You are not authorized to view the book in Admin mode.");
            }
            else
            {
                foreach (var guest in _guests)
                {
                    Message.Write($"{guest.Id}. {guest.FirstName} {guest.LastName}", false, false);
                    if (asAdmin && isAdmin && !string.IsNullOrWhiteSpace(guest.MessageToHost)) Message.Write($" ({guest.MessageToHost})");
                    else Message.BlankLine();
                } 
            }

            Message.BlankLine();
            Prompt.Pause();
        }

        public bool CloseBook(string pwd)
        {
            if (pwd == null || pwd != _pwd)
            {
                Message.Write("You are not authorized to close the book.");
                Message.BlankLine();
                Prompt.Pause();
                return false;
            }

            Message.Write("Thank you for using the Better Guestbook.");
            Message.BlankLine();
            ViewGuests(true,pwd);

            return true;
        }
    }
}
