using Build.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Build
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomNameValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = null;
            if (string.IsNullOrWhiteSpace((string)value) == true)
            {
                this.ErrorMessage = "Name required";
                validationResult = new ValidationResult(this.ErrorMessage);
                return validationResult;
            }
            if (value.ToString().Any(char.IsDigit))
            {
                this.ErrorMessage = "Name could not contain any digits";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (value.ToString().Count(char.IsLetter) < 2)
            {
                this.ErrorMessage = "Name must contain at least 2 letters";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (validationResult == null)
            {
                validationResult = ValidationResult.Success;
            }
            return validationResult;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomSurnameValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = null;
            if (string.IsNullOrWhiteSpace((string)value) == true)
            {
                validationResult = ValidationResult.Success;
                return validationResult;
            }
            if (value.ToString().Count(char.IsLetter) < 2)
            {
                this.ErrorMessage = "Surname must contain at least 2 letters";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (value.ToString().Any(char.IsDigit))
            {
                this.ErrorMessage = "Surname could not contain any digits";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (validationResult == null)
            {
                validationResult = ValidationResult.Success;
            }
            return validationResult;
        }
    }
        [AttributeUsage(AttributeTargets.Property)]
    public class CustomEmailValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = null;
            if (string.IsNullOrWhiteSpace((string)value) == true)
            {
                this.ErrorMessage = "Field required";
                validationResult = new ValidationResult(this.ErrorMessage);
                return validationResult;
            }
            if (!value.ToString().Contains("@gmail.com"))
            {
                this.ErrorMessage = "Wrong e-mail address";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (validationResult == null)
            {
                validationResult = ValidationResult.Success;
            }
            return validationResult;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomPasswordValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = null;
            if (string.IsNullOrWhiteSpace((string)value) == true)
            {
                this.ErrorMessage = "Password required";
                validationResult = new ValidationResult(this.ErrorMessage);
                return validationResult;
            }
            if (value.ToString().Length < 8)
            {
                this.ErrorMessage = "Password is too short";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (value.ToString().Count(char.IsLetter) < 2)
            {
                this.ErrorMessage = "Password must contain at least 2 letters";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (value.ToString().Count(char.IsUpper) < 1)
            {
                this.ErrorMessage = "Password must contain at least 1 or more Uppercase letter";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (validationResult == null)
            {
                validationResult = ValidationResult.Success;
            }
            return validationResult;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomRoleValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = null;
            if (string.IsNullOrWhiteSpace((string)value) == true)
            {
                this.ErrorMessage = "Field required";
                validationResult = new ValidationResult(this.ErrorMessage);
                return validationResult;
            }
            if (value.ToString() != "seller" && value.ToString() != "buyer" && value.ToString() != "admin")
            {
                this.ErrorMessage = "Role must be seller of buyer or admin";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (validationResult == null)
            {
                validationResult = ValidationResult.Success;
            }
            return validationResult;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomNumberValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = null;
            if (string.IsNullOrWhiteSpace(value.ToString()) == true)
            {
                this.ErrorMessage = "Field could not ne empty";
                validationResult = new ValidationResult(this.ErrorMessage);
                return validationResult;
            }
            if (value.ToString().Any(char.IsLetter))
            {
                this.ErrorMessage = "Name could not contain any letters";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (validationResult == null)
            {
                validationResult = ValidationResult.Success;
            }
            return validationResult;
        }
    }
    public class CustomYearValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = null;
            if ((int)value < 1550)
            {
                this.ErrorMessage = "Year is invalid";
                validationResult = new ValidationResult(this.ErrorMessage);
                return validationResult;
            }
            if (value.ToString().Any(char.IsLetter))
            {
                this.ErrorMessage = "Name could not contain any letters";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            if (validationResult == null)
            {
                validationResult = ValidationResult.Success;
            }
            return validationResult;
        }
    }
}
