namespace mis_221_pa_5_dpjefferson1;

public class Transaction{
    private int bookingID;
    private int sessionID;
    private string custName;
    private string email;
    private string date;
    private int trainerID;
    private string trainerName;
    private string status;
    private static int count;

    private Transaction[] TransactionInfo = new Transaction[100];

    public Transaction(){

    }
    
    //constructor

    public Transaction(int bookingID, int sessionID, string custName, string email, string date, int trainerID, string trainerName, string status){
        this.bookingID = bookingID;
        this.sessionID = sessionID;
        this.custName = custName;
        this.email = email;
        this.date = date;
        this.trainerID = trainerID;
        this.trainerName = trainerName;
        this.status = status;
    }

    public void SetBookingID(int bookingID){
        this.bookingID = bookingID;
    }

    public int GetBookingID(){
        return bookingID;
    }

    public void SetSessionID(int sessionID){
        this.sessionID = sessionID;
    }

    public int GetSessionID(){
        return sessionID;
    }

    public void SetCustName(string custName){
        this.custName = custName;
    }

    public string GetCustName(){
        return custName;
    }

    public void SetEmail(string email){
        this.email = email;
    }

    public string GetEmail()
    {
        return email;
    }

    public void SetDate(string date){
        this.date = date;
    }

    public string GetDate(){
        return date;
    }

    public void SetTrainerID(int trainerID){
        this.trainerID = trainerID;
    }

    public int GetTrainerID(){
        return trainerID;
    }
    public void SetTrainName(string trainerName){
        this.trainerName = trainerName;
    }
    public string GetTrainName(){
        return trainerName;
    }
    public void SetActiveStatus(string status){
        this.status = status;
    }
    public string GetStatus(){
        return status;
    }
    public static void SetCount(int count){
        Transaction.count = count;
    }
    public static int GetCount(){
        return Transaction.count;
    }
    public static void IncCount(){
        count++;
    }

    public string ToFile(){
        return bookingID + "#" + sessionID + "#" + custName + "#" + email + "#" + date + "#" + trainerID + "#" + trainerName + "#" + status;
    }
    public override string ToString()
    {
        return $"{bookingID} | {sessionID} | {custName} | {email} | {date} | {trainerID}: {trainerName} | {status}";
    }
}