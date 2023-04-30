namespace mis_221_pa_5_dpjefferson1{



    public class Trainer{
        private int trainerID;
        private string name;
        private string mailAddress;
        private string email;
        private string activeStatus;
        private static int count;
        private static int maxID;
        

        private Trainer[] trainerInfo = new Trainer[100];

        public Trainer(){

        }

        // constructor
        public Trainer(int trainerID, string name, string mailAddress, string email, string activeStatus){
        this.trainerID = trainerID;
        this.name = name;
        this.mailAddress = mailAddress;
        this.activeStatus = activeStatus;
        }

        public void SetName(string name){
        this.name = name;
        }

        public string GetName(){
        return name;
        }

        public void SetMailAddress(string mailAddress){
        this.mailAddress = mailAddress;
        }

        public string GetMailAddress(){
        return mailAddress;
        }

        public void SetEmail(string email){
        this.email = email;
        }

        public string GetEmail(){
        return email;
        }

        public void SetTrainerID(int trainerID){
        this.trainerID = trainerID;
        }

        public int GetTrainerID(){
        return trainerID;
        }

        public void SetActiveStatus(string activeStatus){
        this.activeStatus = activeStatus;
        }

        public string GetActiveStatus(){
        return activeStatus;
        }

        public static void SetCount(int count){
        Trainer.count = count;
        }

        public static int GetCount(){
        return Trainer.count;
        }

        public static void SetMaxID(int maxID){
        Trainer.maxID = maxID;
        }

        public static int GetMaxID(){
        return Trainer.maxID;
        }

        public static void MaxID2(){
        maxID++;
        }
         public static void IncCount(){
        count++;
        }


        public string ToFile(){
        return trainerID + "#" + name + "#" + mailAddress + "#" + email + "#" + activeStatus;
        }

        public override string ToString(){
        return $"{trainerID} | {name} | {mailAddress} | {email} | {activeStatus}";
        }
    }
}
