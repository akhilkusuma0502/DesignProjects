using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElibManagementSystem_BusinessLogicLayer
{
    using System.Text.RegularExpressions;
    using ElibManagementSystem_DataAccessLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    public class User_detailsBLL
    {
        public User_details LogIn(User_details userobj)
        {
            User_details newObj = null;
            try
            {
                var DALObj = new User_detailsOperations();
                newObj = DALObj.LogIn(userobj);


            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }
            return newObj;
        }

        private bool ValidateUser(User_details userobj)
        {
            var IsValid = true;
            var ErrorMessages = new StringBuilder();
            var RegExObj = new Regex("^[a-zA-Z0-9]{8,15}$");
            var RegNumber = new Regex("^[0-9]{3}-[0-9]{4}-[0-9]{4}$");
            var regTenDigits = new Regex("^[1-9]{1}[0-9]{9}$");

            if (string.IsNullOrEmpty(userobj.UserId.ToString()) || !RegExObj.IsMatch(userobj.UserId.ToString()))
            {
                IsValid = false;
                ErrorMessages.AppendLine("User Id should not be blank");
                ErrorMessages.AppendLine("Minimum of 8 Characters and maximum of 15 characters");
            }
            if (string.IsNullOrEmpty(userobj.FirstName))
            {
                IsValid = false;
                ErrorMessages.AppendLine("FirstName Should Not Be Blank");
            }
            if (string.IsNullOrEmpty(userobj.LastName))
            {
                IsValid = false;
                ErrorMessages.AppendLine("LastName Should Not Be Blank");
            }
            if (string.IsNullOrEmpty(userobj.DateOfBirth.ToString()))
            {
                IsValid = false;
                ErrorMessages.AppendLine("Date Of Birth Should Not Be Blank");
            }
            var age = DateTime.Now.Year - userobj.DateOfBirth.Year;
            if (age < 18)
            {
                IsValid = false;
                ErrorMessages.AppendLine("You are not eligible to register.Age should be 18");
            }
            if (string.IsNullOrEmpty(userobj.Address))
            {
                IsValid = false;
                ErrorMessages.AppendLine("Address Should Not Be Blank");
            }
            if (string.IsNullOrEmpty(userobj.LandLineNumber.ToString()) || !regTenDigits.IsMatch(userobj.LandLineNumber.ToString()))
            {
                IsValid = false;
                ErrorMessages.AppendLine("LandLineNumber should not be blank");
                ErrorMessages.AppendLine("LandLine Number Should Be in 10 digits");
            }
            if (string.IsNullOrEmpty(userobj.MobileNumber.ToString()) || !regTenDigits.IsMatch(userobj.MobileNumber.ToString()))
            {
                IsValid = false;
                ErrorMessages.AppendLine("MobileNumber should not be blank");
                ErrorMessages.AppendLine("LandLine Number Should Be in 10 digits");
            }
            if (string.IsNullOrEmpty(userobj.AreaOfInterest))
            {
                IsValid = false;
                ErrorMessages.AppendLine("Area of Interest should not be blank");
            }
            if (string.IsNullOrEmpty(userobj.Gender.ToString()))
            {
                IsValid = false;
                ErrorMessages.AppendLine("Gender Is Not Selected");
            }

            if (string.IsNullOrEmpty(userobj.UserType.ToString()))
            {
                IsValid = false;
                ErrorMessages.AppendLine("UserType Is Not Selected");
            }
            var UserType = userobj.UserType.ToLower();
            if (!UserType.Equals("subscriber") && !UserType.Equals("non_subscriber"))
            {
                IsValid = false;
                ErrorMessages.AppendLine("Invalid UserType. Only Subscriber , Nonsubscriber is allowed");
            }
            if (string.IsNullOrEmpty(userobj.DateOfRegistration.ToString()))
            {
                IsValid = false;
                ErrorMessages.AppendLine("Date Of Registration Should Not Be Blank");
            }
            if (!userobj.DateOfRegistration.Equals(DateTime.Now.Date))
            {
                IsValid = false;
                ErrorMessages.AppendLine("Date Of Registration Should Be Current system's Date");
            }
            if (string.IsNullOrEmpty(userobj.Password))
            {
                IsValid = false;
                ErrorMessages.AppendLine("Password Should Not Be Null");
            }

            if (IsValid == false)
            {
                throw new ELibException(ErrorMessages.ToString());
            }

            return IsValid;
        }

        public User_details FindbyID(string userId)
        {
            var DALObj = new User_detailsOperations();
            var DetailsObj = DALObj.FindbyID(userId);

            return DetailsObj;

        }

        public bool Register(User_details userobj)
        {
            var IsSaved = false;
            try
            {
                if (ValidateUser(userobj))
                {
                    var DALObj = new User_detailsOperations();
                    IsSaved = DALObj.Register(userobj);
                }
            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }
            return IsSaved;
        }

        public bool UpdateUserDetails(User_details userobj)
        {
            var IsSaved = false;
            try
            {

                var DALObj = new User_detailsOperations();
                IsSaved = DALObj.UpdateUserDetails(userobj);

            }
            catch (ELibException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ELibException("Unknown error", ex);
            }
            return IsSaved;
        }


    }
}
