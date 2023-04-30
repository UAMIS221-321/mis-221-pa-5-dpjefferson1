namespace mis_221_pa_5_dpjefferson1{
    public class Report{
        Trainer[] trainers;
        Session[] sessions;
        Transaction[] transactions;

        public Report(Trainer[] trainers , Session[] sessions, Transaction[] transactions){
            this.trainers = trainers;
            this.sessions = sessions;
            this.transactions = transactions;
        }

        public void DisplayTrainers(){
            for(int i = 0; i < Trainer.GetCount(); i++){
                Console.WriteLine(trainers[i].ToString());
            }
        }

        public void DisplaySessions(){
            for(int i = 0; i < Session.GetCount(); i++){
                Console.WriteLine(sessions[i].ToString());
            }
        }

        public void DisplayTransactions(){
            for(int i = 0; i < Transaction.GetCount(); i++){
                Console.WriteLine(transactions[i].ToString());
            }
        }
        public void SortDateTime(){
            for (int i = 0; i < Session.GetCount(); i++){
                int min = i;

                for(int j = i + 1; j < Session.GetCount(); j++){
                    if(sessions[j].GetDate().CompareTo(sessions[min].GetDate()) > 0 || sessions[j].GetDate() == sessions[min].GetDate()
                    && DateTime.Parse(sessions[j].GetTime()) < DateTime.Parse(sessions[min].GetTime())){
                        min = j;
                    
                    }
                }
                if (min != i){
                    SwapSess(min , i);
                }
            }
            DisplaySessions();
        }

        private void SwapSess(int x, int y){
            Session temp = sessions[x];
            sessions[x] = sessions[y];
            sessions[y] = temp;
        }

        public void Personal(){
            Console.WriteLine("Enter email adress to display report.");
            string email = Console.ReadLine();
            Console.WriteLine($"\n See Report: {email}");
            for(int i = 0; i < Transaction.GetCount(); i++){
                if(transactions[i].GetEmail() == email){
                    Console.WriteLine(transactions[i].ToString());
                }
            }
        }

        public void SwapTrans(int x, int y){
            Transaction temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;
        }

        public void SortNameDate(){
            for(int i = 0; i < Transaction.GetCount() - 1; i++){
                int min = i;

                for(int j = i + 1; j < Transaction.GetCount(); j++){
                    if(transactions[j].GetCustName().CompareTo(transactions[min].GetCustName()) < 0 || transactions[j].GetCustName() == 
                    transactions[min].GetCustName() && DateTime.Parse(transactions[j].GetDate()) > DateTime.Parse(transactions[min].GetDate())){
                        min = j;
                    }
                }

                if(min != i){
                    SwapTrans(min, i);
                }
            }
            DisplayTransactions();
        }

    }
}