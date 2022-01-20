using FluentValidation;
using WebApiPractise.Models;

namespace WebApiPractise.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .WithMessage("Ad bos olmalidir")
                .MaximumLength(60)
                .WithMessage("simvol sayisi 60 dan cox olmamalidir");
            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("password bos olmalidir")
                .MinimumLength(8)
                .WithMessage("simvol sayisi 8 den az olmamalidir");
            RuleFor(p => p.Email)
                 .NotEmpty()
                .WithMessage("email bos olmalidir");

            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("email adrdesi daxil edin");
        }
    }
}
