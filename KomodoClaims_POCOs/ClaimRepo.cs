using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_POCOs
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _claimQueue = new Queue<Claim>();

        //create
        public bool CreateClaim(Claim claim)
        {
            if(claim == null)
            {
                return false;
            }
            _claimQueue.Enqueue(claim);
            return true;
        }

        //read
        public Queue<Claim> ViewAllClaims()
        {
            return _claimQueue;
        }

        //view claim in order
        //public Queue<Claim> ViewClaimInOrder()
        //{
        //    bool isTrue = true;

        //    while (isTrue)
        //    {
        //        foreach (var claim in _claimQueue)
        //        {
        //           Claim claim1  = _claimQueue.Peek();

        //            Console.WriteLine($"Claim ID: {claim1.ClaimID}\n" +
        //                $"Claim Type: {claim1.ClaimType}\n" +
        //                $"Claim Description: {claim1.ClaimDescription}\n" +
        //                $"Claim Amount: {claim1.ClaimAmount}\n" +
        //                $"Incident Date: {claim1.IncidentDate}\n" +
        //                $"Claim Date: {claim1.ClaimDate}\n" +
        //                $"Valid: {claim1.IsValid}\n ");

        //            Console.WriteLine("Would you like to deal with this claim? (y/n)");
        //            string input = Console.ReadLine().ToLower();

        //            switch (input)
        //            {
        //                case "y":
        //                    _claimQueue.Dequeue();
        //                    break;
        //                case "n":
        //                    Console.WriteLine("You will now be returned to the main menu.");
        //                    break;
        //                default:
        //                    Console.WriteLine("Please enter a valid menu option:");
        //                    Console.WriteLine("");
        //                    Console.WriteLine("Press 'y' if you would like to deal with the next claim.\n" +
        //                        "Press 'n' if you would like to return to the main menu");
        //                    break;
        //            }

        //        }
        //    }
        //}

        // Helper method in case I need it
        public Claim GetClaimByID(int claimID)
        {
            foreach (var claim in _claimQueue) 
            {
                if (claimID == claim.ClaimID)
                {
                    return claim;
                }
            }
            return null;
        }



    }
}
