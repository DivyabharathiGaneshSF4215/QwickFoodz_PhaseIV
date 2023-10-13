using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApplication
{
    public enum Gender {Select,Male,Female,Transgender}
    public class PersonalDetails
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public long Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string MailID { get; set; }
        public string Location { get; set; }

        public PersonalDetails(string name,string fatherName,Gender gender,long mobile,DateTime dob,string mailID,string location)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile= mobile;
            DOB = dob;
            MailID = mailID;
            Location = location;
        }

    }
}
//Name, FatherName, Gender- {Select, Male, Female, Transgender}, Mobile, DOB, MailID, Location