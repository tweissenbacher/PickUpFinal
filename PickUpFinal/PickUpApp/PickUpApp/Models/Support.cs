using System;
using System.Collections.Generic;
using System.Text;

namespace PickUpApp.Models
{
    internal class Support
    {
        private long telNr;
        private string mail;

        public Support(long telNr, string mail)
        {
            this.telNr = telNr;
            this.mail = mail;
        }

        public long TelNr { get => telNr; set => telNr = value; }
        public string Mail { get => mail; set => mail = value; }

        public object activateSupport(Person person)
        {
            return null;
        }
    }
}
