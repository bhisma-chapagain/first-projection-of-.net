
using opps_concept;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class Car // create calss
{
    public string Name; //create feild

    public Car()
    {
        Name = "";// intinalize the value
    }


    static void Main(string[] agrs)
    {
        {
            Car Ford = new Car();// call the constrcution 
            Console.WriteLine(Ford.Name);
        }
        {
            Console.WriteLine("\t\t transaction detail\t\n");

            Bankaccount account = new Bankaccount("Halen", 20000);// creating bankaccount as a object

            Console.WriteLine($"Account  {account.Number} was created for {account.OWner} with {account.Balance}");
           account.MakeWithdraw(120, DateTime.Now, "Ryan");// withdraw
            account.Makedeposite(1000, DateTime.Now, "Aryan");// for deposte money message

            Console.WriteLine( /*You have withdrwan Rs120  ,so*/ $"your current balance :  {account.Balance}\n");
            Console.WriteLine( account.GetAmountHistory());// calling the function for the report analyasis
    
        }
        //program to find out the sum of the number
        int m;
        
        int sum = 0;
        int reserve = 0;
        Console.WriteLine("enter the number ");
        int n = Convert.ToInt32(Console.ReadLine());
        while (n > 0)
        {
            m = n % 10;
            reserve = reserve * 10 + m;// reverse of the number
            sum = sum + m;// sum of the number
            n = n / 10;
        }
        Console.WriteLine($"sum of the number is: {sum}");
        Console.WriteLine($"reserve of the number is{reserve}");



    }
}

 public  class Bankaccount
{
    public string Number { get; }
    public string OWner { get; set; }// here get value hekps to return the rpoprty value ,and set value helps to aasign the new value.
    //for every transcation we need to check the balance so we set the get as AbandonedMutexException function
    public  decimal Balance { get
        {
            decimal balance = 0;
            foreach (var item in alltransaction)
            {
                balance = balance + item.Amount;
            }
            return balance;
        }
    }
    private static int accountseed = 1234567890;

    // we need to know the how many transaction we have done , so to calculate the list of transcation  we set the list of transaction like wise
    private List<transaction> alltransaction = new List<transaction>();


    public Bankaccount(string name,decimal initialbalance) // creating the bank account using constructor

    {
        this.OWner = name;
       // this.Balance = initalbalance;// here  "this" property is not necessary to write,its seems good while writting
         this.Number = accountseed.ToString();// we need to get account number  of the user
        accountseed++;
        Makedeposite(initialbalance, DateTime.Now, "initialbalance");

     }
     public void Makedeposite(decimal amount, DateTime date,string notes)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount)); // amount of deposite must be positive
        }
         var deposite = new transaction(amount, date, notes);
        alltransaction.Add(deposite);

    }
    public void MakeWithdraw(decimal amount, DateTime date, string notes)
    {
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));// the amount must be positive for the withdrawn

        }
        if (Balance - amount<0)
        {
            throw new InvalidOperationException("you dont have sufficient money to withdrawn ");
        }
        var withdrawn = new transaction(-amount, date, notes);
        alltransaction.Add(withdrawn);
    }
    // this is main line for the history
    public string GetAmountHistory()
    {
        var report = new StringBuilder();
        Console.WriteLine("\t\tHistory of the transaction\n");
        report.AppendLine("\tDate\t\t  Amount\tNotes");
        //report
        foreach (var item in alltransaction)
        {
            report.AppendLine($"{item.Date}\t {item.Amount}\t\t{item.Notes} ");
        }
        //rows
        return report.ToString();

    }

}

 
    


