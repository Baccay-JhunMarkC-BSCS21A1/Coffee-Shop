using System;
public class CoffeeShopBaccay
{
    static string[,] MenuItem = new string[20,2];
    static string[,] CartItem = new string[20,2];
    static int itemCount = 0;
    static int cartCount = 0;
    static double totalAmount = 0;
    static void P(string message)
    {
        Console.WriteLine(message);
    }
    public static void Main()
    {
        P("Welcome to the Coffee Shop!");
        bool loop = true;
        while (loop == true)
        {
            try
            {
                P("1. Add Menu Item\r\n2. View Menu\r\n3. Place Order\r\n4. View Order\r\n5. Checkout\r\n6. Exit\r\nSelect an option: ");
                int userIn = Convert.ToInt32(Console.ReadLine());
                switch (userIn)
                {
                    case 1:
                        Menu();
                        break;
                    case 2:
                        ViewMenu();
                        break;
                    case 3:
                        PlaceOrder();
                        break;
                    case 4:
                        ViewCart();
                        break;
                    case 5:
                        Checkout();
                        break;
                    case 6:
                        Exit();
                        break;
                }
            }
            catch
            {
                P("Invalid Input!");
            }
        }
    }
    static void Menu()
    {
        P("------------Add Item------------");
        bool MLoop = true;
        while (MLoop == true)
        {
            P("Enter Item/Product Name: ");
            string AItem = Console.ReadLine();
            P("Enter Price: ");
            try
            {
                double APrice = Convert.ToDouble(Console.ReadLine());
                if (APrice > 0)
                {
                    P($"Is the information correct?\nItem/Product Name: {AItem}\nPrice: {APrice}\ny/n");
                    string userIn = Console.ReadLine();
                    if (userIn.ToUpper() == "Y")
                    {
                        if (itemCount < MenuItem.GetLength(0))
                        {
                            MenuItem[itemCount, 0] = AItem;
                            MenuItem[itemCount, 1] = APrice.ToString();
                            itemCount++;
                            P("Item added successfully.");
                            MLoop = false;
                        }
                        else
                        {
                            P("Menu is full. Cannot add more items.");
                            MLoop = false;
                        }

                    }
                    else if (userIn.ToUpper() == "N") { }
                   
                }
                else
                {
                    P("Invalid Pricing.");
                }
            }
            catch
            {
                P("Please enter correct information.");
            }
        }
        
    }
    static void ViewMenu()
    {
        int e = 1;
        if (itemCount > 0)
        {
            for (int i = 0; i < itemCount; i++)
            {
                
                P(e + ". " + MenuItem[i, 0] + ": ₱ " + MenuItem[i, 1]);
                e++;
            }
        }
        else if (itemCount == 0)
        {
            P("No items to display.");
        }

        
    }
    static void PlaceOrder()
    {

        bool e = true;
        while (e == true)
        {
            int f = 1;
            if (itemCount > 0)
            {

                for (int i = 0; i < itemCount; i++)
                {
                    P(f + ". " + MenuItem[i, 0] + ": ₱ " + MenuItem[i, 1]);
                    f++;
                }
                try
                {
                    P("Select Item Number: ");
                    int iUser = Convert.ToInt32(Console.ReadLine());
                    iUser = iUser-1;
                    P("Selected item is:" + MenuItem[iUser,0]+": " + MenuItem[iUser,1]+"\nConfirm Order?\ny/n");
                    string userIn = Console.ReadLine();
                    if (userIn.ToUpper() == "Y")
                    {
                        CartItem[cartCount, 0] = MenuItem[iUser, 0];
                        CartItem[cartCount, 1] = MenuItem[iUser, 1];
                        double addAmount = Convert.ToDouble(MenuItem[iUser, 1]);
                        totalAmount = totalAmount + addAmount;  
                        cartCount =cartCount+1;
                        P("Item Added to Cart");
                        P("Do you want to add more items?\ny/n");
                        userIn = Console.ReadLine();
                        if (userIn.ToUpper() == "N")
                        {
                            e = false;
                        }
                    }
                }
                catch
                {
                    P("Invalid Input");
                }
            }


            else if (itemCount == 0)
            {
                P("No item to display.");
                e = false;
            }
        }
    }
    static void ViewCart()
    {
    int e = 1;
        if (cartCount > 0)
        {
            P($"The total amout is: {totalAmount}");
            for (int i = 0; i < cartCount; i++)
            {

                P(e + ". " + CartItem[i, 0] + ": ₱ " + CartItem[i, 1]);
                e++;

            }
        }
        else
        {
            P("No items to display.");
        }
    }
    static void Checkout()
    {
        bool loop = true;
        int e = 1;
        if (cartCount > 0)
        {
            P($"The total amout is: {totalAmount}");
            for (int i = 0; i < cartCount; i++)
            {

                P(e + ". " + CartItem[i, 0] + ": ₱ " + CartItem[i, 1]);
                e++;

            }
            P("Do you want to proceed to Checkout?\ny/n");
            string userIn = Console.ReadLine();
            while (loop == true)
            {
                if (userIn.ToUpper() == "Y")
                {
                    P("Enter Amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    if (amount > totalAmount)
                    {
                        double change = totalAmount - amount;
                        P($"Amount Paid: {amount}\nTotal Amount: {totalAmount}\nChange: {change}\nThank you for you patronage at our coffee shop!\nWe hope for you to enjoy our services while you wait for your coffee.");
                        loop = false;
                        Exit();
                    }
                    else if (amount < totalAmount)
                    {
                        P("Insufficient Amount.");
                    }else if (amount == totalAmount)
                    {
                        P($"Amount Paid: {amount}\nTotal Amount: {totalAmount}\nThank you for you patronage at our coffee shop!\nWe hope for you to enjoy our services while you wait for your coffee.");
                        loop = false;
                        Exit();
                    }
                }
            }
        }
        else
        {
            P("No items to display.");
        }
    }
    static void Exit()
    {
        Environment.Exit(0);
    }
}
