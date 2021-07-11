﻿using KomodoClaims_POCOs;
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
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to the main menu..");
            Console.ReadKey();
            Console.Clear();

        }

        private void AddressAClaim()
        {
            bool isTrue = true;

                while (isTrue)
                {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"    {halfDashes} *Komodo Claims* {halfDashes}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("          Address A Claim:\n" +
                    $"{dashes}{dashes}\n" +
                    $"\n");

                Claim claim = _claimRepo.ViewAllClaims().Peek();
                  
                        Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                            $"Claim Type: {claim.ClaimType}\n" +
                            $"Claim Description: {claim.ClaimDescription}\n" +
                            $"Claim Amount: {claim.ClaimAmount}\n" +
                            $"Incident Date: {claim.IncidentDate}\n" +
                            $"Claim Date: {claim.ClaimDate}\n" +
                            $"Valid: {claim.IsValid}\n ");

                        Console.WriteLine("Would you like to deal with this claim? (y/n)");
                        string input = Console.ReadLine().ToLower();

                        switch (input)
                        {
                            case "y":          
                                _claimRepo.ViewAllClaims().Dequeue();
                                break;
                            case "n":
                                Console.WriteLine("You will now be returned to the main menu.");
                                Console.Clear();
                                Menu();
                                break;
                            default:
                                Console.WriteLine("Please enter a valid menu option:");
                                Console.WriteLine("");
                                Console.WriteLine("Press 'y' if you would like to deal with the next claim.\n" +
                                    "Press 'n' if you would like to return to the main menu");
                                break;
                        }

                    
                }

        }

        private void EnterANewClaim()
        {
            throw new NotImplementedException();
        }

        private void SeedClaims()
        {

            Claim claim1 = new Claim(1, Claim.TypeOfClaim.Theft, "Theft of lawn equipment", 1200.00m, DateTime.Parse("04/04/2021"), DateTime.Parse("04/25/2021"));
            Claim claim2 = new Claim(2, Claim.TypeOfClaim.Car, "Car accident- policyholder not at fault", 5000.00m, DateTime.Parse("01/15/2019"), DateTime.Parse("02/03/2019"));
            Claim claim3 = new Claim(3, Claim.TypeOfClaim.Home, "Tornado damage to roof and garage", 15000.00m, DateTime.Parse("08/17/2020"), DateTime.Parse("09/04/2020"));
            Claim claim4 = new Claim(4, Claim.TypeOfClaim.Car, "Policyholder was victim of hit and run", 10000.00m, DateTime.Parse("06/22/2018"), DateTime.Parse("09/04/2018"));

            _claimRepo.CreateClaim(claim1);
            _claimRepo.CreateClaim(claim2);
            _claimRepo.CreateClaim(claim3);
            _claimRepo.CreateClaim(claim4);
        }
    }
}
