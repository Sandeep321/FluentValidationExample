using FluentValidation;
using FluentValidationExample.Localization;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validators
{
    public class StudentViewModelValidator : AbstractValidator<StudentViewModel>
    {
        public StudentViewModelValidator(ILocalizer localizer)
        {
            RuleFor(x => x.Id).GreaterThan(100).WithMessage(localizer.GetLocalizedString("Student Id should be greater than 100"));
            RuleFor(x => x.Name).MaximumLength(10).WithMessage(localizer.GetLocalizedString("Student Name should be less than 10 chars"));
        }
    }
}
