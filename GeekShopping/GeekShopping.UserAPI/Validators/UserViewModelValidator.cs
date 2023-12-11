using FluentValidation;
using GeekShopping.UserAPI.Data.ValueObjects;

namespace GeekShopping.UserAPI.Validators;

public class UserViewModelValidator : AbstractValidator<UserViewModel>
{
    public UserViewModelValidator()
    {
        RuleFor(c => c.UserName)
        .NotEmpty().WithMessage("User name cannot be empty")
        .Length(3, 150).WithMessage("User name must be between 3 and 150 characters");

        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");

        RuleFor(c => c.Role)
            .NotEmpty().WithMessage("Role cannot be empty");            
    }
}
