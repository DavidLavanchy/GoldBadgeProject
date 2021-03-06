using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreetings_POCOs
{
    public class GreetingsRepo
    {
        private readonly List<Greetings> _greetingsList = new List<Greetings>();

        //create
        public bool CreateANewGreeting(Greetings newGreeting)
        {
            if(newGreeting == null)
            {
                return false;
            }
            _greetingsList.Add(newGreeting);
            return true;
        }

        //read
        public List<Greetings> ReadListOfGreetings()
        {
            return _greetingsList;
        }

        //update
        public bool UpdateGreeting(Greetings greeting, Greetings newGreeting)
        {
            Greetings greetingToBeUpdated = FindGreetingByLast(greeting.LastName);

            if(greetingToBeUpdated == null)
            {
                return false;
            }
            _greetingsList.Remove(greeting);
            CreateANewGreeting(newGreeting);
            return true;

        }

        public bool DeleteAGreeting(Greetings greeting)
        {
            Greetings greetingToBeUpdated = FindGreetingByLast(greeting.LastName);

            if (greetingToBeUpdated == null)
            {
                return false;
            }
            _greetingsList.Remove(greeting);
            return true;
        }

        //helper method
        public Greetings FindGreetingByLast(string lastName)
        {
            List<Greetings> _listOfGreetings = ReadListOfGreetings();

            foreach(var greeting in _listOfGreetings)
            {
                if((greeting.LastName == lastName))
                {
                    return greeting;
                }
            }
            return null;
        }
    }
}
