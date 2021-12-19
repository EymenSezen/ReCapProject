using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {    
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
           // RuleFor(u => u.Password).NotEmpty();            
            RuleFor(u => u.FirstName).Must(minLength).WithMessage("2 karakterden büyük olmalı");

        }

        private bool minLength(string arg)
        {
            return arg.Length > 2;
        }
    }
}
