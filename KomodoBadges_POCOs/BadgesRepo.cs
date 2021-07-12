using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_POCOs
{
    public class BadgesRepo
    {
        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        //create
        public bool CreateABadge(Badges badge)
        {
            int badgeID = badge.BadgeID;
            List<string> doorNames = badge.DoorNames;

            int badgeCount = _badgeDictionary.Count();

            _badgeDictionary.Add(badgeID, doorNames);
            int newBadgeCount = _badgeDictionary.Count();

            if(newBadgeCount > badgeCount)
            {
                return true;
            }

            return false;
        }

        //read

        //update


        //delete

        //helper method

    }
}
