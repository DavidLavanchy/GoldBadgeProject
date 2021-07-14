using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_POCOs
{
    public class BadgesRepo
    {
        private readonly List<Badges> _badgeList = new List<Badges>(); //mainly used to track badge names
        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        //create
        public bool CreateABadge(Badges badge)
        {
            //This method creates and instance of a new badge in the dictionary and the list of badges
            //The list of badges is primarily just to associate the ID's and Doors to a Name

            int badgeID = badge.BadgeID;
            List<string> doorNames = badge.DoorNames;
            string badgeName = badge.BadgeName;

            int badgeCount = _badgeDictionary.Count();

            _badgeDictionary.Add(badgeID, doorNames);
            int newBadgeCount = _badgeDictionary.Count();

            Badges newBadge = new Badges();
            newBadge.BadgeID = badgeID;
            newBadge.DoorNames = doorNames;
            newBadge.BadgeName = badgeName;

            _badgeList.Add(newBadge);

            if(newBadgeCount > badgeCount)
            {
                return true;
            }

            return false;
        }

        //read dictionary
        public Dictionary<int, List<string>> ReadBadges()
        {
            return _badgeDictionary;
        }

        //read one badge
        public List<string> ReadOneBadge(int badgeID)
        {
            foreach (int badge in _badgeDictionary.Keys)
            {
                if (badgeID == badge)
                {
                    List<string> doorsOnBadge = _badgeDictionary[badgeID];
                    return doorsOnBadge;
                }
            }
            return null;
        }

        //update
        public bool UpdateDoorsOnExistingBadge(int badgeID, string updatedDoorAccess)
        {

            foreach (int badge in _badgeDictionary.Keys)
            {
                if (badgeID != badge)
                {
                    return false;
                }
            }

            _badgeDictionary[badgeID].Add(updatedDoorAccess);
            
            return true;
        }

        //delete
        public bool DeleteDoorsOnExistingBadge(int badgeID, string doorsToBeDeleted)
        {
            foreach(int badge in _badgeDictionary.Keys)
            {
                if(badgeID != badge)
                {
                    return false;
                }
            }

            _badgeDictionary[badgeID].Remove(doorsToBeDeleted);
            return true; 
        }

        public bool DeleteAllDoorsOnExistingBadge(int badgeID)
        {

            foreach (int badge in _badgeDictionary.Keys)
            {
                if (badge == badgeID)
                {
                    List<string> doorsOnBadge = _badgeDictionary[badgeID];
                    doorsOnBadge.Clear();
                } 
            }

            return false;

        }

        //get name of badge by badge ID
        public string GetBadgeName (int badgeID)
        {
            foreach(var badge in _badgeList)
            {
                if(badge.BadgeID == badgeID)
                {
                    return badge.BadgeName;
                }
            }
            return null;
        }

    }
}
