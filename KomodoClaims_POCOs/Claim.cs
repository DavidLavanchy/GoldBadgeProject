using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_POCOs
{
    public class Claim
    {
        public enum TypeOfClaim { Theft, Car, Home }
        
        public Claim(){}
        public Claim(int claimID, TypeOfClaim claimType, string claimDescription, decimal claimAmount, DateTime incidentDate, DateTime claimDate)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            IncidentDate = incidentDate;
            ClaimDate = claimDate;
        }

        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool IsValid 
        {
            get
            {
                TimeSpan isValidTime = ClaimDate - IncidentDate;
                if (isValidTime.TotalDays <= 30 && isValidTime.TotalDays >=0)
                {
                    return true;
                }
                else 
                {
                    return false;
                };
            }
              
        }
    }
}
