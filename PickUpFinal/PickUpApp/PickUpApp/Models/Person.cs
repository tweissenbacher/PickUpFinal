using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;


namespace PickUpApp.Models
{
    public class Person
    {
        private string name;
        private string mail;
        private long telNr;

        private List<Delivery> deliveries;

        public Person(string name, string mail, long telNr)
        {
            this.name = name;
            this.mail = mail;
            this.telNr = telNr;


            this.deliveries = new List<Delivery>();
        }

        public string Name { get => name; set => name = value; }
        public string Mail { get => mail; set => mail = value; }
        public long TelNr { get => telNr; set => telNr = value; }





        public void giveUp(Delivery delivery)
        {

        }
        public void pickUp(Delivery delivery)
        {

        }



        public Station findNearestAvailableStation(Size size)
        {
            return null;
        }

        public void returnBox(Station station)
        {

        }

    }


}
