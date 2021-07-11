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
