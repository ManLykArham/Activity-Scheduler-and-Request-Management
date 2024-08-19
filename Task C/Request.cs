using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task_C
{
    internal class Request
    {
        // Members
        private string id; // Declares a private field for request ID
        private string sTime; // Declares a private field for start time
        private string fTime; // Declares a private field for finish time

        // Properties
        public string ID
        {
            set { id = value; } // Sets the value of the ID field
            get { return id; } // Gets the value of the ID field
        }

        public string STime
        {
            set { sTime = value; } // Sets the value of the start time field
            get { return sTime; } // Gets the value of the start time field
        }

        public string FTime
        {
            set { fTime = value; } // Sets the value of the finish time field
            get { return fTime; } // Gets the value of the finish time field
        }

        // Constructor
        public Request(string ID, string STime, string FTime)
        {
            this.id = ID; // Initializes the id field
            this.sTime = STime; // Initializes the start time field
            this.fTime = FTime; // Initializes the finish time field
        }
    }
}