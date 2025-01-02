//using System.Linq.Expressions;
//using ConsoleTables;
//using App.Domain.Services.AppService;
//using App.Domain.Core.Entities;
//using App.EndPoints.ConsoleApp;
//using App.Domain.Services.Service;

//void MainMenu()
//{
//    UserAppService _userAppService = new UserAppService();
//    while (true)
//    {
//        Console.Clear();
//        Console.ForegroundColor = ConsoleColor.Blue;
//        Console.WriteLine("=====================================");
//        Console.WriteLine("|              Welcome               |");
//        Console.WriteLine("=====================================");
//        Console.ResetColor();
//        Console.ForegroundColor = ConsoleColor.Cyan;

//        Console.WriteLine("Enter UserName: ");
//        string username = Console.ReadLine();
//        Console.WriteLine("Enter Password: ");
//        string password = Console.ReadLine();
//        var result = _userAppService.Login(username, password);
//        if (result.IsSucced)
//        {
//            Console.WriteLine(result.Message);
//            var currentUser = result.Currentuser;
//            Console.WriteLine("Press Any Key To Redirect To Card Menu");
//            Console.ReadKey();
//            userPanel(currentUser);
//        }
//        else
//        {
//            Console.WriteLine(result.Message);
//            Console.WriteLine("Press Any Key To Try Again");
//        }
//    }
//}



//void userPanel(User currentUser)
//{
//    Console.Clear();
//    Console.ForegroundColor = ConsoleColor.Green;
//    Console.WriteLine("=====================================");
//    Console.WriteLine("|              Welcome               |");
//    Console.WriteLine("=====================================");
//    Console.ResetColor();
//    Console.ForegroundColor = ConsoleColor.Cyan;

//    TransactionService bankService = new TransactionService();
//    DisplayHelper displayHelper = new DisplayHelper();

//    while (true)
//    {
//        Console.WriteLine("1-Make A Transaction");
//        Console.WriteLine("2-View Balance");
//        Console.WriteLine("3-View History");
//        Console.WriteLine("4-Exit");
//        Console.Write("Choose: ");
//        string option = Console.ReadLine();


//        switch (option)
//        {
//            case "1":
//                // transaction
//                Console.WriteLine("Enter The Destination Card Number: ");
//                string destinationCardNumebr = Console.ReadLine();
//                Console.WriteLine("Enter The Amount: ");
//                decimal amount = decimal.Parse(Console.ReadLine());
//                var result1 = bankService.Transfer(currentUser, destinationCardNumebr, amount);
//                Console.WriteLine(result1);
//                break;
//            case "2":
//                // display balance
//                var card = bankService.ViewAccount(currentUser.Id);
//                Console.WriteLine($"Balance : {card.Balance:c}");
//                break;
//            case "3":
//                // display all transactions
//                var result3 = bankService.GetTransactionReport(currentUser.Id);
//                displayHelper.DisplayTransactionHistory(result3);
//                break;
//            case "4":
//                MainMenu();
//                break;
//            default:
//                Console.WriteLine("Invalid Choice. Try Again");
//                break;
//        }
//    }

//}


//MainMenu();

Console.WriteLine("Entry Point");