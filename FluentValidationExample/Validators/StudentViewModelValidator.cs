using System;
using FluentValidation;
using FluentValidationExample.Localization;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validators
{
    public class StudentViewModelValidator : AbstractValidator<StudentViewModel>
    {
        public StudentViewModelValidator(ILocalizer localizer)
        {
            RuleFor(x => x.Id).GreaterThan(100).WithMessage(x => localizer.GetLocalizedString("Student Id should be greater than 100"));
            RuleFor(x => x.Name).MaximumLength(10).WithMessage(x => localizer.GetLocalizedString("Student Name should be less than 10 chars"));
            Console.WriteLine(new System.Diagnostics.StackTrace().ToString());
        }
    }
}
