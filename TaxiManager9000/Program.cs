using TaxiManager9000;
using TaxiManager9000.Models;
using TaxiManager9000.Models.Enums;
using TaxiManager9000.Service;

while (true)
{
    Console.Write("Username: ");
    string username = Console.ReadLine();

    Console.Write("Password: ");
    string password = Console.ReadLine();

    bool login = AuthService.Login(username, password);

    if (!login)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Login unsuccessful. Please try again");
        Console.ResetColor();
        Thread.Sleep(2000);
        Console.Clear();
        continue;
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Successful Login! Welcome {username}");
    Console.ResetColor();
    Thread.Sleep(2000);
    Console.Clear();

    while (true)
    {
        var user = StaticDb.users.Where(u => u.Username == username).FirstOrDefault();
        string option = String.Empty;
        if (user != null)
        {

            if (user.Role == Role.Administrator)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1: Create a new user for the app");
                Console.WriteLine("2: Terminate User");
                Console.WriteLine("3: Change password");
                Console.WriteLine("4: Exit application");

                option = Console.ReadLine();
                if (option != "1" && option != "2" && option != "3" && option != "4" && option != "5" && option != "6")
                {
                    Console.WriteLine("Please enter valid option");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

                if (option == "1")
                {
                    //Console.Write("Back to Main Menu Y/N ");
                    //option = Console.ReadLine().ToLower();

                    //if (option == "y")
                    //{
                    //    Thread.Sleep(1000);
                    //    Console.Clear();
                    //    continue;
                    //}

                    Console.Write("Username: ");
                    
                    string RegisterUsername = Console.ReadLine();

                    Console.Write("Password: ");
                    string RegisterPasswrod = Console.ReadLine();

                    Console.WriteLine("Role: ");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. Maintenance");
                    Console.WriteLine("3. Manager");

                    string role = Console.ReadLine();
                    while (role != "1" && role != "2" && role != "3")
                    {
                        Console.WriteLine("Please enter valid role");
                        role = Console.ReadLine();
                    }
                    bool res = AuthService.Register(RegisterUsername, RegisterPasswrod, role);
                    if (!res)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Register unsuccessful. Please try again");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Register successful.");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else if (option == "2")
                {
                    foreach (var item in StaticDb.users)
                    {
                        Console.WriteLine($"{item.Id} : {item.Username}");
                    }

                    Console.WriteLine("Choose User");
                    string input = Console.ReadLine();
                    int userId;
                    bool success = int.TryParse(input, out userId);
                    if (success)
                    {
                        StaticDb.users.RemoveAt(--userId);
                    }
                    Console.WriteLine("User sucessfully deleted");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (option == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Change Password");
                    Console.Write("Old password: ");
                    string oldPassword = Console.ReadLine();

                    bool changePass = AuthService.changePassword(username, oldPassword);
                    if (changePass)
                    {
                        Console.WriteLine("Password sucessfully changed");

                    }
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

            }

            if (user.Role == Role.Maintenance)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. List all vehicles ");
                Console.WriteLine("2. License Plate Status ");
                Console.WriteLine("3 Change password");
                Console.WriteLine("4: Exit application");



                option = Console.ReadLine();
                if (option != "1" && option != "2" && option != "3")
                {
                    Console.WriteLine("Please enter valid option");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

                if (option == "1")
                {
                    foreach (var item in StaticDb.cars)
                    {

                        var Shifts = StaticDb.drivers.Where(d => d.CarId == item.Id).Count();
                        int percentComplete = (int)Math.Round((double)(100 * Shifts) / 3);
                        Console.WriteLine($"{item.Id} {item.Id} with License Plate {item.Id} and utilized {percentComplete} %");
                    }
                }
                else if (option == "2")
                {
                    foreach (var car in StaticDb.cars)
                    {
                        int months = (DateTime.Now.Year - car.LicensePlateExpieryDate.Year) * 12 + DateTime.Now.Month - car.LicensePlateExpieryDate.Month;

                        if (DateTime.Now > car.LicensePlateExpieryDate)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{car.Id} {car.LicensePlate} expired on {car.LicensePlateExpieryDate.ToLongDateString()}");

                        }
                        else if (months >= -3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{car.Id} {car.LicensePlate} expiering on {car.LicensePlateExpieryDate.ToLongDateString()}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{car.Id} {car.LicensePlate} expiering on {car.LicensePlateExpieryDate.ToLongDateString()}");

                        }
                    }
                    Console.ResetColor();
                    Console.WriteLine("Press Enter to return to Main Menu");

                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    while (keyInfo.Key != ConsoleKey.Enter)
                    {
                        keyInfo = Console.ReadKey();

                    }
                    Console.Clear();

                    continue;
                }
                else if (option == "3")
                {
                    Console.WriteLine("Change Password");
                    bool changePass = AuthService.changePassword(username, password);
                    if (changePass)
                    {
                        Console.WriteLine("Password sucessfully changed");
                    }
                    continue;
                }
            }

            if (user.Role == Role.Manager)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. List all drivers");
                Console.WriteLine("2. Taxi License Status");
                Console.WriteLine("3. Assign Unassigned Drivers");
                Console.WriteLine("4 Change password");

                Console.WriteLine("5: Exit application");


                option = Console.ReadLine();
                if (option != "1" && option != "2" && option != "3" && option != "4")
                {
                    Console.WriteLine("Please enter valid option");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }
                Console.Clear();

                if (option == "1")
                {
                    foreach (var item in StaticDb.drivers)
                    {
                        var car = StaticDb.cars.Where(x => x.Id == item.CarId).FirstOrDefault();
                        if (car == null)
                        {
                            Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName}");

                        }
                        if (item.Shift != null && item.CarId != null)
                        {
                            Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} in the shift {item.Shift} with a car model {car.Model} car");
                        }
                    }
                }

                if (option == "2")
                {
                    foreach (var driver in StaticDb.drivers)
                    {

                        int months = (DateTime.Now.Year - driver.LicenseExpieryDate.Year) * 12 + DateTime.Now.Month - driver.LicenseExpieryDate.Month;

                        if (DateTime.Now > driver.LicenseExpieryDate)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{driver.Id} {driver.FirstName} {driver.LastName} with license {driver.License} expired on {driver.LicenseExpieryDate.ToLongDateString()}");

                        }
                        else if (months >= -3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{driver.Id} {driver.FirstName} {driver.LastName} with license {driver.License}  expiering on {driver.LicenseExpieryDate.ToLongDateString()}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{driver.Id} {driver.FirstName} {driver.LastName} with license {driver.License}  expiering on {driver.LicenseExpieryDate.ToLongDateString()}");

                        }

                    }
                }

                if (option == "3")
                {
                    var AvailableDrivers = StaticDb.drivers.Where(x => x.Shift == Shift.NoShift && DateTime.Now < x.LicenseExpieryDate).ToList();
                    int counter = 0;
                    foreach (var driver in AvailableDrivers)
                    {
                        Console.WriteLine($"{driver.Id} {driver.FirstName} {driver.LastName}");
                    }

                    Console.WriteLine("Select a user ");
                    string inputUserId = Console.ReadLine();
                    int userId = 0;
                    bool success = int.TryParse(inputUserId, out userId);
                    bool cuss = AvailableDrivers.Any(x => x.Id == userId);

                    while ((cuss == false) || (success && false))
                    //while (!int.TryParse(inputUserId, out userId))
                    {
                        Console.WriteLine("Please Select user from the list");
                        inputUserId = Console.ReadLine();

                        success = int.TryParse(inputUserId, out userId);
                        cuss = AvailableDrivers.Any(x => x.Id == userId);
                    }
                    var AvailableDriver = AvailableDrivers.Where(x => x.Id == userId).FirstOrDefault();

                    while (true)
                    {
                        Console.WriteLine("Pick a shift");
                        Console.WriteLine("1: Morning");
                        Console.WriteLine("2 Afternoon");
                        Console.WriteLine("3 Evening");
                        string shift = Console.ReadLine();

                        if (shift != "1" && shift != "2" && shift != "3")
                        {
                            Console.WriteLine("Please enter valid shift");
                            continue;
                        }
                        bool IsShiftConvertionSucess = int.TryParse(inputUserId, out int shiftNum);

                        if (AvailableDriver != null)
                        {
                            AvailableDriver.Shift = (Shift)shiftNum;
                        }


                        var availableCars = StaticDb.cars.Where(x => (DateTime.Now < x.LicensePlateExpieryDate)).ToList();

                        foreach (var driver in StaticDb.drivers)
                        {
                            if(availableCars.Count != 0)
                            {
                                foreach (var car in availableCars.ToList())
                                {
                                    if (car.Id == driver.CarId && driver.Shift == AvailableDriver.Shift)
                                    {
                                        availableCars.Remove(car);
                                    }
                                }
                            }
                        }

                        Console.WriteLine("Available cars");
                        foreach (var car in availableCars)
                        {
                            Console.WriteLine($"{car.Id} {car.Model}");
                        }
                        break;

                    }

                }

                //if(option == "4")
                //{
                //    Console.WriteLine("Change Password");
                //    bool changePass = AuthService.changePassword(username, passwrod);
                //    if (changePass)
                //    {
                //        Console.WriteLine("Password sucessfully changed");
                //    }
                //    continue;
                //}

                //if(option == "5")
                //{
                //    option = "4";
                //}
                //}
                Console.Clear();


            }


        }
        if (option == "4")
        {
            break;
        }
    }
    break;
}

void MainMenu(string username, string password)
{
    var user = StaticDb.users.Where(u => u.Username == username).FirstOrDefault();
    if (user.Role == Role.Administrator)
    {
        Console.WriteLine("1. New User");
        string input = Console.ReadLine();
        int menu;
        bool success = int.TryParse(input, out menu);
        if (success)
        {
            switch (menu)
            {
                case 1:

                    break;
            }
        }

    }
}
