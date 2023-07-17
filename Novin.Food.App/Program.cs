using Novin.Food.App.Managers;
using Novin.Food.UI;
// default username is babak & password is 12345678

var security = new Admins();
Console.Write("Enter your Username: ");
var username = Console.ReadLine();
Console.Write("Enter your password: ");
var password = Console.ReadLine();
var result = security.Check(username, password);
if (result == "Ok")
{
    var mainMenu = new Menu();
    mainMenu.Items.Add("1-Customers"); //done
    mainMenu.Items.Add("2-Restaurants"); //done
    mainMenu.Items.Add("3-Foods");  //done
    mainMenu.Items.Add("4-Drinks"); //done
    mainMenu.Items.Add("5-Orders"); //done
    mainMenu.Items.Add("0-Exit"); //done
    while (true)
    {
        var select = mainMenu.Show();
        if (select == 0)
        {
            break;
        }
        else if (select == 1)
        {
            Customers.Show();
        }
        else if (select == 2)
        {
            Restaurants.Show();
        }
        else if (select == 3)
        {
            Foods.Show();
        }
        else if (select == 4)
        {
            Drinks.Show();
        }
        else if (select == 5)
        {
            Orders.Show();
        }
    }
}
else if (result == "wrong")
{
    Console.WriteLine("wrong username or password");
}