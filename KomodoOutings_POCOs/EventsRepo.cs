using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings_POCOs
{
    public class EventsRepo
    {
       private readonly List<Events> _outings = new List<Events>();

        //create
        public bool AddAnEvent(Events newEvent)
        {
            if(newEvent == null)
            {
                return false;
            }
            _outings.Add(newEvent);
            return true;
        }

        //read
        public List<Events> ReadListOfEvents()
        {
            return _outings;
        }

        //helper method to display Event by 

    }
}
