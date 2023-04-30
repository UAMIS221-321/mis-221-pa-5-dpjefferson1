using System.IO;
using mis_221_pa_5_dpjefferson1;

// MAIN
Trainer[] trainers = new Trainer[100];
TrainerUtility trainerUtility = new TrainerUtility(trainers);
Session[] sessions = new Session[100];
SessionUtility sessionUtility = new SessionUtility(sessions);
Transaction[] transactions = new Transaction[100];
TransactionUtility transactionUtility = new TransactionUtility(trainers, sessions, transactions);
Report report = new Report(trainers, sessions,transactions);
DisplayMenu(trainers, trainerUtility, sessions, sessionUtility, transactions, transactionUtility, report);
trainerUtility.GetTrainInfo();
sessionUtility.GetSessionInfo();
transactionUtility.GetTransInfo();
    // END MAIN

static void DisplayMenu(Trainer[] trainers, TrainerUtility trainerUtility, Session[] sessions, SessionUtility sessionUtility, Transaction[] transactions, TransactionUtility transactionUtility,Report report){
    string menu = "";
    while(menu != "5"){
        Console.WriteLine("1.) Trainer Data Manager\n 2.) Listing Data Manager\n 3.) Customer Booking Data Manager\n 4.) Reports\n 5.) Exit");
        menu = Console.ReadLine();

        if(menu == "1"){
            TrainData(trainers, trainerUtility, report);
        }
        else if(menu == "2"){
            SessData(sessions, sessionUtility, report);
        }
        else if(menu == "3"){
            TransData(transactions, transactionUtility,sessionUtility, report);
        }
        else if(menu == "4"){
             ReportsData(trainerUtility,sessionUtility,transactionUtility,report);
        }
        else if (menu == "5"){
            //Exit
        }
        else{
            Console.WriteLine("This input is Invalid! Try Again. ");
        }
    }
}

static void TrainData(Trainer[] trainers, TrainerUtility trainerUtility, Report report){
    Console.Clear();
    string option = "";
    while(option != "4"){
    Console.WriteLine("1.) Add a Trainer\n 2.) Edit a Trainer\n 3.) Display Trainer\n 4.) Exit");
        option = Console.ReadLine();

        if (option == "1"){
            trainerUtility.AddATrainer();
            report.DisplayTrainers();
        }
        else if (option == "2"){
            report.DisplayTrainers();
            trainerUtility.Find();
            report.DisplayTrainers();
        }
        else if (option == "3"){
            trainerUtility.Sort();
            report.DisplayTrainers();
        }
        else if (option == "4"){

        }
        else{
            Console.WriteLine("Sorry!! This input is not accepted!");
        }
    }
}

static void TransData(Transaction[] transactions, TransactionUtility transactionUtility,SessionUtility sessionUtility, Report report){
    string option = "";
    while (option != "4"){
        Console.WriteLine("1.)Add a session\n 2.) Edit a Session\n 3.) Display a Session\n 4.) Exit");
        option = Console.ReadLine();

        if (option == "1"){
            transactionUtility.AddTrans();
            sessionUtility.Save();
            report.DisplayTransactions();
        }
        else if (option == "2"){
            report.DisplaySessions();
            transactionUtility.Find();
            report.DisplaySessions();
        }
        else if(option == "3"){
            report.DisplaySessions();
        }
        else if(option == "4"){
            //exit
        }
        else{
            Console.WriteLine("Sorry!! This input is not accepted! Try Again");
        }
    }
}

static void SessData(Session[] sessions, SessionUtility sessionUtility, Report report){
    string option = "";
    while (option != "4"){
        Console.WriteLine("1.) Add a session\n 2.) Edit a session\n 3.) Display a session\n 4.) Exit");
        option = Console.ReadLine();
    }
        
    if(option == "1"){
        sessionUtility.AddSession();
        report.DisplaySessions();
    }
    else if (option == "2"){
        report.DisplaySessions();
        sessionUtility.Find();
        report.DisplaySessions();
    }
    else if (option == "3"){
        report.DisplaySessions();
    }
    else if (option == "4"){
        //exit
    }
    else{
        Console.WriteLine("Sorry!! This input is not accepted! Try Again. ");
    }
}

static void ReportsData(TrainerUtility trainerUtility, SessionUtility sessionUtility, TransactionUtility transactionUtility, Report report){
    Console.Clear();
    
    string option = "";
    while(option != "4"){
        Console.WriteLine($"\n1.) Individual Customer Sessions\n 2.) Historical Cutomer Sessions\n 3.) Historical Revenue Report\n 4.) Exit");
        option = Console.ReadLine();

        if(option == "1"){
            report.Personal();
        }
    
    else if(option == "2"){
        string choice = "";
            while(choice != "4"){
                Console.WriteLine($"\n 1) Sorted by Date\n 2) Sorted by Customer \n 3)Total sessions by customer \n 4) Exit");
                choice = Console.ReadLine();
            
                if (choice == "1"){
                report.SortDateTime();
                }
                else if(choice == "2"){
                    report.SortNameDate();
                }
                else if (choice == "3"){
                 Console.Write("Total Sessions");
                }
                else if( choice == "4"){

                }
                else{
                    Console.WriteLine("This input cannot be accepted! Please try again.");
                }
            }
        }
        else if( option == "3"){
            Console.WriteLine("Historical Revenue Report");
        }
        else if (option == "4"){
            // Exit
        }
        else{
            Console.WriteLine("This input cannot be accepted! Please try again.");
        }
    }
}