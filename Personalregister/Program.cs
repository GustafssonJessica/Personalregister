using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personalregister
{
    internal class Program
    {

        /*
        //Klasser som bör implementeras:
            Det skulle kanske vara bra med olika typer av underklasser till personal om de blir större i framtiden. 
            Exempelvis administrativ personal, kökspersonal, serveringspersonal. Tyvärr minns jag inte hur man skapar underklasser dock.


        Attribut som bör ingå i klasserna:
            Förnamn, Efternamn, födelsedag, bostadsadress, kontaktuppgifter till närmast anhörig, mejladress, telefonnummer, hur länge personenen varit anställd, datum som personen ska vara ledig,
            "behörigheter" och övrig info (ex om får hantera känsliga livsmedel, ha ansvar för kassa osv)
            Metoder: Get och Set. Kanske skicka mejl eller ringa. 
            Sen måste man såklart kunna ta bort personal med, men tror inte det är en metod i själva klassen. 

        */

        static void Main(string[] args)
        {

            int personalId = 0;
            List<Personal> personalList = new List<Personal>();
            bool addPersonal = true;

            do
            {
                Console.WriteLine("Vad vill du göra?\n" +
                    "1) Lägg till ny anställd\n" +
                    "2) Se och ändra information om anställd\n" +
                    "3) Radera anställd\n" +
                    "4) Logga ut");
                string answer = Console.ReadLine();

                //om vill lägga till ny anställd 
                if (answer == "1")
                {
                    Console.WriteLine("Var god mata in namn på personalen: ");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Var god mata in {name}s lön (i SEK):  ");
                    double salary = double.Parse(Console.ReadLine().Trim());
                    string fullId = "personal" + personalId.ToString(); 
                    Personal personal = new Personal(name, salary);
                    personalList.Add(personal);

                    personalId++;
                    /* måste särskilja dem på något sätt. Typ ge varje person ett unikt ID,
                     men det är inget som jag minns hur man gör... tänkte göra det mha ett personalId-nummer som ökar
                    med varje anställd. Men det gick inte så bra för jag vet inte hur jag ska få över den strängen från variabeln
                    fullId till variabeln för personal.
                    */
                    Console.WriteLine($"Du har lagt till {name} med lön {salary}. Vill du lägga till ytterligare info? Svara ja eller nej: ");
                    string answer2 = Console.ReadLine().ToLower();
                    if (answer2 == "ja")
                    {
                        Console.WriteLine("Lägg till födelsedatum (åååå mm dd): ");

                        personal.BirthDate = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Lägg till adress: ");
                        personal.Address = Console.ReadLine();

                        Console.WriteLine("Lägg till telefonnumer (endast siffror): ");
                        personal.PhoneNumber =  int.Parse(Console.ReadLine());

                        Console.WriteLine("Nu har du lagt till all information om "+ personal.Name);

                    }
                    if (answer2 == "nej")
                    {
                        Console.WriteLine("Okej, ingen mer info tillagd.");

                    }
                }

               else if (answer== "2")
                {
                    Console.WriteLine("Här kan du se och ändra informationen på nått sätt! Tyvärr ej implementerat :)");
                    Console.WriteLine("Skriv namn på personen du vill se: ");

                }

                else if (answer == "3")
                {
                    Console.WriteLine("Här kan du radera en anställd... om jag hade kommit ihåg hur man raderar ett objekt.");
                }

                else if (answer == "4")
                {
                    Console.WriteLine("Du har loggat ut.");
                    addPersonal = false;
                }
            } while (addPersonal);

            

        }

        public class Personal
        {
            public string Name { get; set; }
            public double Salary { get; set; }
            public DateTime BirthDate { get; set; }
            public string Address { get; set; }
            public int? PhoneNumber { get; set; }
            public string Email { get; set; }
            public string EmergencyContact { get; set; }
            public string Befattning { get; set; }
            public TimeSpan Employed { get; set; }


            public Personal(string name, double salary)
            {
                Name = name;
                Salary = salary;
                BirthDate = new DateTime(0001, 01, 001);
                Address = string.Empty;
                PhoneNumber = 0;
                Email = string.Empty;
                EmergencyContact = string.Empty;
                Befattning = string.Empty;
                Employed = new TimeSpan(0, 0, 0);

            }

            public Personal(string name, double salary, DateTime birthDate, string address, int phoneNumber, string email, string emergencyContact, string befattning, TimeSpan employed)
            {
                Name = name;
                Salary = salary;
                BirthDate = birthDate;
                Address = address;
                PhoneNumber = phoneNumber;
                Email = email;
                EmergencyContact = emergencyContact;
                Befattning = befattning;
                Employed = employed;
            }

        }

    }
}
