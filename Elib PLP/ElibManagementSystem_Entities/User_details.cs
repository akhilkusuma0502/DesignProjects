using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_Entities
{
    public class User_details
    {
        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _landLineNumber;

        public string LandLineNumber
        {
            get { return _landLineNumber; }
            set { _landLineNumber = value; }
        }
        private string _mobileNumber;

        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { _mobileNumber = value; }
        }
        private string _areaOfInterest;

        public string AreaOfInterest
        {
            get { return _areaOfInterest; }
            set { _areaOfInterest = value; }
        }
        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        private string _userType;

        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }
        private DateTime _dateOfRegistration;

        public DateTime DateOfRegistration
        {
            get { return _dateOfRegistration; }
            set { _dateOfRegistration = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User_details()
        {

        }

        public User_details(string UserId, string FirstName, string LastName, DateTime DateOfBirth, string Address, string LandLineNumber, string MobileNumber, string AreaOfInterest, string Gender, string UserType, DateTime DateOfRegistration, string Password)
        {
            this.UserId = UserId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.LandLineNumber = LandLineNumber;
            this.MobileNumber = MobileNumber;
            this.AreaOfInterest = AreaOfInterest;
            this.Gender = Gender;
            this.UserType = UserType;
            this.DateOfRegistration = DateOfRegistration;
            this.Password = Password;
        }

    }

}

