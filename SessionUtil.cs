namespace mis_221_pa_5_dpjefferson1{

    public class SessionUtility{
        private Session[] sessions;

        //constructor

        public SessionUtility(Session[] sessions){
            this.sessions = sessions;
        }

        public Session[] GetSessionInfo(){
            StreamReader inFile = new StreamReader("Listings.txt");

            Session.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split("#");
                sessions[Session.GetCount()] = new Session(int.Parse(temp[0]), temp[1], temp[2], temp[3], double.Parse(temp[4]), temp[5]);
                Session.IncCount();

                line = inFile.ReadLine();
            }
            
            inFile.Close();
            return sessions;
        }

        public void AddSession(){
            Console.Clear();
            Session theSession = new Session();
            int maxID = MaxID();
            theSession.SetSessionID(maxID + 1);
            theSession.SetAvailability("Open");

            Console.WriteLine("Enter the name of the trainer.");
            theSession.SetTrainName(Console.ReadLine());

            Console.WriteLine("Enter the date of the training session. Must be in (mm/dd/yyyy)");
            DateTime exactDate = DateTime.Parse(Console.ReadLine());
            string date = exactDate.ToShortDateString();
            theSession.SetDate(date);

            Console.WriteLine("Enter the time of the training session. Must be (6.00 pm) format");
            DateTime exactTime = DateTime.Parse(Console.ReadLine());
            string startTime = exactTime.ToShortTimeString();
            string endTime = exactTime.AddHours(0).ToShortTimeString();
            theSession.SetTime($"{startTime} - {endTime}");

            Console.WriteLine("Enter the cost of the session: ");
            theSession.SetCost(double.Parse(Console.ReadLine()));
            sessions[Session.GetCount()] = theSession;

            Session.IncCount();
            Session.IncMaxID();
            Save();
        }

        public int MaxID(){
            int max = 0;
            Sort();

            for(int i = 0; i < Session.GetCount(); i++){
                if(sessions[i].GetSessionID() > max){
                    max = sessions[i].GetSessionID();
                }
            }
            return max;
        }

        public void Sort(){
            for(int i = 0; i < Session.GetCount() - 1; i++){
                int min = i;

                for(int j = i + 1; j < Session.GetCount(); j++){
                    if(sessions[j].GetSessionID().CompareTo(sessions[min].GetSessionID()) < 0){
                        min = j;
                    }
                }

                if(min != i){
                    Swap(min,i);
                }
            }
        }

        private void Swap(int x, int y){
            Session temp = sessions[x];
            sessions[x] = sessions[y];
            sessions[y] = temp;
        }

        public int BinarySearch(int searchValue){
            Console.WriteLine(Session.GetCount());
            int min = 0;
            int max = Session.GetCount() - 1;

            while(min <= max){
                int mid = (max + min)/2;

                if(searchValue == sessions[mid].GetSessionID()){
                    return mid;
                }
                if(searchValue < sessions[mid].GetSessionID()){
                    max = mid -1;
                }
                else{
                    min = mid + 1;
                }
            }
            return -1;
        }

        public void Find()
        {
            Console.Write("Enter ID: ");
            int searchValue = int.Parse(Console.ReadLine());
            int searchID = BinarySearch(searchValue);

            if(searchID == -1){
                Console.WriteLine(" \n Not a valid session!! \n\n");
            }
            else{
                Edit(searchID);
                Save();
            }
        }

        public void Edit(int searchID){
            string option = "";

            while(option != "5"){
                Console.WriteLine("\n Make changes tooo.. \n 1.) Trainer Name\n 2.) Date\n 3.) Time\n 4.) Cost\n 5.) Exit ");
                option = Console.ReadLine();

                if(option== "1"){
                    Console.WriteLine("Change the trainers name too: ");
                    sessions[searchID].SetTrainName(Console.ReadLine());
                    option = "5";
                }
                else if(option == "2"){
                    Console.WriteLine("Change the date to .. : must be in (mm/dd/yyyy) format ");
                    DateTime exactDate = DateTime.Parse(Console.ReadLine());
                    string date = exactDate.ToShortDateString();
                    sessions[searchID].SetDate(date);
                    option = "5";
                }
                else if(option == "3"){
                    Console.WriteLine("Change the time .. must be (6:00 pm) format");
                    DateTime exactTime = DateTime.Parse(Console.ReadLine());
                    string startTime = exactTime.ToShortTimeString();
                    string endTime = exactTime.AddHours(0).ToShortTimeString();
                    sessions[searchID].SetTime($"{startTime} - {endTime}");
                    option = "5";

                }
                else if(option == "4"){
                    Console.WriteLine("Change the cost to.. :");
                    sessions[searchID].SetCost(double.Parse(Console.ReadLine()));
                    option = "5";
                }
                else if(option == "5"){
                    // exit
                }
                else{
                    Console.Write("This input is not accpeted! Try Again!");
                }
            }
        }

        public void Save(){
            StreamWriter outFile = new StreamWriter("listings.txt");
            
            for(int i = 0; i < Session.GetCount(); i++){
                outFile.WriteLine(sessions[i].ToFile());
            }
            outFile.Close();
        }


    }
}