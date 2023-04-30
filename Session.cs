namespace mis_221_pa_5_dpjefferson1{

    public class Session{
        private int sessionID;
        private string trainName;
        private string date;
        private string time;
        private double cost;
        private string availability;
        private static int count;
        private static int maxID;
        private static Session[] sessionInfo = new Session[100];

        public Session(){

        }

        public Session (int sessionID, string trainName, string date, string time, double cost, string availability ){
            this.sessionID = sessionID;
            this.trainName = trainName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.availability = availability;
        }

        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }

        public int GetSessionID(){
            return sessionID;
        }

        public void SetTrainName(string trainName){
            this.trainName = trainName;
        }

        public string GetTrainName(){
            return trainName;
        }

        public void SetDate(string date){
            this.date = date;
        }

        public string GetDate(){
            return date;
        }

        public void SetTime(string time){
            this.time = time;
        }

        public string GetTime(){
            return time;
        }

        public void SetCost(double cost){
            this.cost = cost;
        }

        public double GetCost(){
            return cost;
        }

        public void SetAvailability(string availability){
            this.availability = availability;
        }

        public string GetAvailability(){
            return availability;
        }
        public static void SetCount(int count){
            Session.count = count;
        }

        public static int GetCount(){
            return count;
        }

        public static int GetMaxID(){
            return maxID;
        }

        public static void SetMaxID(int maxID){
            Session.maxID = maxID;
        }

        public static void IncCount(){
            count++;
        }
        public static void IncMaxID(){
            maxID++;
        }

        public string ToFile(){
        return sessionID + "#" + trainName + "#" + date + "#" + time + "#" + cost + "#" + availability;
        }
         public override string ToString(){
        return $"{sessionID} | {trainName} | {date} | {time} | {date} | ${cost} : {availability}";
        }
    }
}
