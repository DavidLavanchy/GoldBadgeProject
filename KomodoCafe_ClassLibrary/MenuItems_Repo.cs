using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_ClassLibrary
{
    public class MenuItems_Repo
    {
        List<MenuItems> _menuItemsList = new List<MenuItems>();

        //create
        public void CreateMenuItem(MenuItems menuItem)
        {
            _menuItemsList.Add(menuItem);
        }

        //read
        public List<MenuItems> ReadMenuItems()
        {
            return _menuItemsList;
        }

        //delete
        public bool DeleteItemFromList(int identificationNumber)
        {
            MenuItems menuItem = GetMenuItemByID(identificationNumber);

            if(menuItem != null)
            {
                _menuItemsList.Remove(menuItem);
                return true;
            }
            else
            {
                return false;
            }
        }


        public MenuItems GetMenuItemByID(int identificationNumber)
        {
            foreach(MenuItems item in _menuItemsList)
            {
                if(identificationNumber == item.MealNumber)
                {
                    return item;
                }

            }
                return null;
            
        }
    }
}
