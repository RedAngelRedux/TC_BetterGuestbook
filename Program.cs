
// Capture the information about each guest
// Info to capture: first name, last name, message to host
// Once done, loop through each guest and print their info
using BetterGuestBook;
using GloboWeb.Console;

GuestBook guestBook = new();
bool close = false;

do
{
    AppMenu.DisplayMenu();

    switch(AppMenu.GetChoice())
    {
        case "sign":
            guestBook.Sign();
            break;
        case "view":
            guestBook.ViewGuests();
            break;
        case "viewadmin":
            guestBook.ViewGuests(true,Prompt.GetString("Enter your password: ",false));
            break;
        case "closeadmin":
            close = guestBook.CloseBook(Prompt.GetString("Enter your password: ",false));
            break;
        default:
            Message.Write("Invalid Opion");
            break;
    }

} while (!close);