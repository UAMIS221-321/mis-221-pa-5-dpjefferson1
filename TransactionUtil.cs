namespace mis_221_pa_5_dpjefferson1{

    public class TransactionUtility{
        private Trainer [] trainers;
        private Session[] sessions;
        private Transaction[] transactions;
        

        public TransactionUtility(Trainer[] trainers, Session[] sessions, Transaction[] transactions){
            this.trainers = trainers;
            this.sessions = sessions;
            this.transactions = transactions;
        }

        public Transaction[] GetTransInfo(){
            //open
            StreamReader inFile = new StreamReader("transaction.txt");

            //process
            Transaction.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split("#");
                transactions[Transaction.GetCount()] = new Transaction(int.Parse(temp[0]), int.Parse(temp[1]), temp[2], temp[3], temp[4], int.Parse(temp[5]), temp[6], temp[7]);
                Transaction.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
            return transactions;
        }

        public void AddTrans(){
            bool inTheLoop = true;
            while(inTheLoop){
                Report report = new Report(trainers, sessions, transactions);
                Session book = new Session();
                Transaction theTrans = new Transaction();

                Console.WriteLine("Enter your name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter a date for session availability. Must be in (mm/dd/yyyy) format: ");
                DateTime specificDate = DateTime.Parse(Console.ReadLine());
                string date = specificDate.ToShortDateString();
                Console.WriteLine($"\n Here is the session availability for {date}");
                for (int i = 0; i < Session.GetCount(); i++){
                    if(sessions[i].GetDate() == date && sessions[i].GetAvailability() == "Open"){
                        Console.WriteLine(sessions[i].ToString());
                    }
                }

                Console.WriteLine("\n\n Enter the Session ID: ");
                int sessionID = int.Parse(Console.ReadLine());
                for(int i = 0; i < Session.GetCount(); i++){
                    if(sessions[i].GetSessionID() == sessionID){
                        Console.WriteLine(sessions[i].ToString());
                        theTrans.SetTrainName(sessions[i].GetTrainName());
                        sessions[i].SetAvailability("Closed");
                    }
                }

                report.DisplayTrainers();
                Console.WriteLine("\nEnter the trainers ID to complete booking: ");
                int trainerID = int.Parse(Console.ReadLine());

                Console.WriteLine("Is this the correct session? Type 'Yes' if so: ");
                string confirm = Console.ReadLine();
                if(confirm.ToUpper() != "YES"){
                    Console.WriteLine("Exit and try again");
                }
                else{
                    theTrans.SetSessionID(sessionID);
                    theTrans.SetCustName(name);
                    theTrans.SetEmail(email);
                    theTrans.SetDate(date);
                    theTrans.SetActiveStatus("Booked");
                    theTrans.SetTrainerID(trainerID);
                    theTrans.SetBookingID(Transaction.GetCount() + 1);
                    transactions[Transaction.GetCount()] = theTrans;
                    Transaction.IncCount();

                    Save();
                    inTheLoop = false;
                }
            }
        }

        public void Save(){
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for(int i = 0; i < transactions.Length; i++)
            {
                outFile.WriteLine(transactions[i].ToFile());
            }
            outFile.Close();
        }

        public void Find(){
            Console.Write("Enter ID ");
            int searchValue = int.Parse(Console.ReadLine());
            int searchID = BinarySearch(searchValue);

            if (searchID == -1){
                Console.WriteLine("\n Sorry . This is not a valid session!\n ");
            }
            else{
                UpdateSess(searchID);
                Save();
            }
        }

        public int BinarySearch(int searchValue){
            int min = 0;
            int max = Session.GetCount() - 1;

            while(min <= max){
                int mid = (max + min)/2;
                
                if(searchValue == sessions[mid].GetSessionID()){
                    return mid;
                }
                if(searchValue < sessions[mid].GetSessionID()){
                    max = mid - 1;
                }
                else {
                    min = mid + 1;
                }
            }
            return -1;
        }

        public void UpdateSess(int searchID){
            Console.Clear();
            Report report = new Report(trainers, sessions, transactions);
            Console.WriteLine(sessions[searchID].ToString());
            string option = "";

            while(option != "3"){
                Console.WriteLine("\n 1) Pay for session\n 2.) Cancel Session\n 3.) Exit");
                option = Console.ReadLine();

                if(option == "1"){
                    Console.Write("\nEnter amount to pay to complete session : $");
                    double amount = double.Parse(Console.ReadLine());
                    double cost = sessions[searchID].GetCost();

                    while(amount != cost){
                        if(amount > cost){
                            double change = amount - cost;
                            Console.WriteLine($"Amount due is ${change.ToString("#.##")}");
                            amount = cost;
                        }
                        else{
                            Console.WriteLine(sessions[searchID].ToString());
                            Console.WriteLine("\n Error. Insufficient funds. Please enter more funds: $");
                            amount = double.Parse(Console.ReadLine());
                        }
                    }

                    report.DisplayTransactions();
                    Console.WriteLine("\n Enter booking ID number to complete tranaction!");
                    int setID = int.Parse(Console.ReadLine());
                    int bookID = setID - 1;
                    transactions[bookID].SetActiveStatus("Completed");
                    option = "3";   
                }
                else if(option == "2"){
                    report.DisplayTransactions();
                    Console.Write("\n Enter booking ID number to complete cancellation!");
                    int setID = int.Parse(Console.ReadLine());
                    int bookID = setID -1;
                    transactions[bookID].SetActiveStatus("Cancelled");
                    option = "3";
                }
                else if(option == "3"){
                    //Exit
                }
                else{
                    Console.WriteLine("Input cannot be accpeted. Try Again");
                }
            }
        }

        public void Sort(){
            for(int i = 0; i < Transaction.GetCount() - 1; i++){
                int min = 1;
                for(int j = i + 1; j < Transaction.GetCount(); j++){
                    if(transactions[j].GetBookingID().CompareTo(transactions[min].GetBookingID()) < 0){
                        min = j;
                    }
                }
                if(min != i){
                    Swap(min, i);
                }
            }
        }

        public void Swap(int x, int y){
            Transaction temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;
        }
        
    }
}