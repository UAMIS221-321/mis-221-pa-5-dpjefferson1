namespace mis_221_pa_5_dpjefferson1{


    public class TrainerUtility{
        private Trainer[] trainers;

        // constructor
        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }

        public Trainer[] GetTrainInfo(){
            StreamReader inFile = new StreamReader("trainer.txt");

            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line!= null){
                string[] temp = line.Split("#");
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }
            
            inFile.Close();
            return trainers;
        }

        public void AddATrainer(){
            Trainer theTrainer = new Trainer();
            int maxID = MaxID();
            theTrainer.SetTrainerID(maxID + 1);
            theTrainer.SetActiveStatus("Active");

            Console.WriteLine("Enter the name of the trainer.");
            theTrainer.SetName(Console.ReadLine());
            theTrainer.SetTrainerID(maxID + 1);

            Console.WriteLine("Enter the mailing address");
            theTrainer.SetMailAddress(Console.ReadLine());
            trainers[Trainer.GetCount()] = theTrainer;

            Console.WriteLine("Enter the email address");
            theTrainer.SetEmail(Console.ReadLine());
            trainers[Trainer.GetCount()] = theTrainer;

            Trainer.IncCount();
            Trainer.MaxID2();

            Save();
        }

        public void Find(){
            Console.WriteLine("Enter ID: ");
            int searchValue = int.Parse(Console.ReadLine());
            int searchID = BinarySearch(searchValue);

            if(searchID == -1){
                Console.WriteLine("\nTrainer is not valid\n");
            }
            else{
                Edit(searchID);
                Save();
            }
        }

        public int BinarySearch(int searchValue){
            int min = 0;
            int max = Trainer.GetCount() -1;
            int mid = (max + min)/2;

            while(min <= max){
                if(searchValue < trainers[mid].GetTrainerID()){
                    mid = min + 1;
                }
                if(searchValue == trainers[mid].GetTrainerID()){
                    return mid;
                }
                else{
                    mid = max -1;
                }
            }
            return -1;
        }

        public void Edit(int searchID){
            string choice = "";

            while(choice != "5"){
                Console.WriteLine("What would you like to change?.. \n1.) Trainer Name \n2.) Mailing Address \n3.) Email Address \n4.) Activity Status \n5.) Exit");
                choice = Console.ReadLine();

                if(choice == "1"){
                    Console.WriteLine("Change name to :");
                    trainers[searchID].SetName(Console.ReadLine());
                    choice = "5";
                }
                else if(choice == "2"){
                    Console.WriteLine("Change mailing address to:");
                    trainers[searchID].SetMailAddress(Console.ReadLine());
                    choice = "5";
                }
                else if(choice == "3"){
                    Console.WriteLine("Change email address to: ");
                    trainers[searchID].SetEmail(Console.ReadLine());
                    choice = "5";
                }
                else if(choice == "4"){
                    Console.WriteLine("Change Active Status: Active -> A \n Not Active -> N ");
                    trainers[searchID].SetActiveStatus(Console.ReadLine());
                    choice = "5";
                }
                else if (choice == "5"){
                    //EXIT 
                }
                else{
                    Console.WriteLine("Error Code 1911! That input cannot be accepted!!");
                }
            }
        }

        public int MaxID(){
            Sort();
            int max = 0;
            
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainers[i].GetTrainerID() > max){
                    max = trainers[i].GetTrainerID();
                }
            }
            return max;
        }
        public void Sort(){
            for(int i = 0; i < Trainer.GetCount() - 1; i++){
                int min = 1;
                
                for(int j = i + 1; j < Trainer.GetCount(); j++){
                    if (trainers[j].GetTrainerID().CompareTo(trainers[min].GetTrainerID()) < 0){
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min , i);
                }
            }
        }

        private void Swap(int x, int y){
            Trainer temp = trainers[x];
            trainers[x] = trainers[y];
            trainers[y] = temp;
        }

        public void Save(){
            StreamWriter outFile = new StreamWriter("trainer.txt");

            for(int i = 0; i < Trainer.GetCount(); i++){
                outFile.WriteLine(trainers[i].ToFile());
            }
            outFile.Close();
        }

        public string Status(string input){
            if(input.ToUpper() == "0"){
                return "Inactive";
            }
            return "Active";
        }
    }
}