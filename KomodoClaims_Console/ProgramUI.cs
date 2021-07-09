using KomodoClaims_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    public class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        private string dashes = "--------------------";
        private string halfDashes = "----------";
        public void Run()
        {
            SeedClaims();
            Menu();
        }

        private void Menu()
        {
            bool isTrue = true;

            while (isTrue)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  {halfDashes} *Komodo Claims* {halfDashes}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("          Select a menu option:\n" +
                    $"{dashes}{dashes}\n" +
                    $"\n" +
                    "          1. See All Claims\n" +
                    "          2. Address a Claim\n" +
                    "          3. Enter a New Claim\n" +
                    "          4. Exit This Application\n" +
                    "\n" +
                    $"{dashes}{dashes}");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        AddressAClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        isTrue = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
            }
        }

        private void SeeAllClaims()
        { 

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} *Komodo Claims* {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          View All Claims:\n" +
                $"{dashes}{dashes}\n" +
                $"\n");

            foreach(var claim in _claimRepo.ViewAllClaims())
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                        $"Claim Type: {claim.ClaimType}\n" +
                        $"Claim Description: {claim.ClaimDescription}\n" +
                        $"Claim Amount: {claim.ClaimAmount}\n" +
                        $"Incident Date: {claim.IncidentDate}\n" +
                        $"Claim Date: {claim.ClaimDate}\n" +
                        $"Valid: {claim.IsValid}\n ");
                Console.WriteLine("");
                Console.WriteLine($"{dashes}{dashes}");
            }


        }

        private void AddressAClaim()
        {
            throw new NotImplementedException();
        }

        private void EnterANewClaim()
        {
            throw new NotImplementedException();
        }

        private void SeedClaims()
        {
            DateTime incidentDate1 = new DateTime(04 / 04 / 2021);
            DateTime claimDate1 = new DateTime(04 / 25 / 2021);

            DateTime incidentDate2 = new DateTime(01 / 15 / 2019);
            DateTime claimDate2 = new DateTime(02 / 03 / 2019);

            DateTime incidentDate3 = new DateTime(08 / 17 / 2020);
            DateTime claimDate3 = new DateTime(09 / 04 / 2020);

            DateTime incidentDate4 = new DateTime(06 / 22/ 2018);
            DateTime claimDate4 = new DateTime(09 / 04 / 2018);



            Claim claim1 = new Claim(1, Claim.TypeOfClaim.Theft, "Theft of lawn equipment", 1200.00m, incidentDate1, claimDate1);
            Claim claim2 = new Claim(2, Claim.TypeOfClaim.Car, "Car accident- policyholder not at fault", 5000.00m, incidentDate2, claimDate2);
            Claim claim3 = new Claim(3, Claim.TypeOfClaim.Home, "Tornado damage to roof and garage", 15000.00m, incidentDate3, claimDate3);
            Claim claim4 = new Claim(4, Claim.TypeOfClaim.Car, "Policyholder was victim of hit and run", 10000.00m, incidentDate4, claimDate4);

            _claimRepo.CreateClaim(claim1);
            _claimRepo.CreateClaim(claim2);
            _claimRepo.CreateClaim(claim3);
            _claimRepo.CreateClaim(claim4);
        }
    }
}
