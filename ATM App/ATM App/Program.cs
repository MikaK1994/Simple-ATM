using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_App
{
    public class cardHolder
    {
        String cardNum;
        int pin;
        String firstName;
        String lastName;
        double balance;

        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public String getNum()
        {
            return cardNum;
        }

        public int getPin()
        {
            return pin;
        }

        public String getFirstname()
        {
            return firstName;
        }

        public String getLastname()
        {
            return lastName;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setNum(String newCardNum)
        {
            cardNum = newCardNum;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFirstname(String newFirstName)
        {
            firstName = newFirstName;
        }

        public void setLastname(String newLastName)
        {
            lastName = newLastName;
        }

        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }

        public static void Main(String[] Args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to deposit: ");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance() + deposit);
                Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
            }

            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to withdraw: ");
                double withdraw = Double.Parse(Console.ReadLine());
                //Check if the user has enough money
                if(currentUser.getBalance() < withdraw)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdraw);
                    Console.WriteLine("Transaction completed. Thank you.");
                }
            }

            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current balance: " + currentUser.getBalance());
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
                cardHolders.Add(new cardHolder("734743743783", 1234, "John", "Griffith", 2901.54));
                cardHolders.Add(new cardHolder("029383750223", 9837, "Ashley", "Jones", 9387.43));
                cardHolders.Add(new cardHolder("02084774579", 4344, "Josh", "Smith", 22.98));
                cardHolders.Add(new cardHolder("43545656556", 5555, "Frida", "Dickerson", 111.43));
                cardHolders.Add(new cardHolder("93874398374", 9669, "Mark", "Jackson", 455.75));

            //Prompt user
            Console.WriteLine("Welcome to SimpleATM");
            Console.WriteLine("Please insert your debit card: ");
            String debitCardNum = "";
            cardHolder currentUser;

            while(true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    //Check against our db
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized. Please try again."); }
                }

                catch { Console.WriteLine("Card not recognized. Please try again."); }
            }

            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect pin. Please try again."); }
                }

                catch { Console.WriteLine("Incorrect pin. Please try again."); }
            }

            Console.WriteLine("Welcome " + currentUser.getFirstname() +".");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }            
            }
            while (option != 4);
            Console.WriteLine("Thank you for using our service. Have a nice day.");
        }
    }
}
