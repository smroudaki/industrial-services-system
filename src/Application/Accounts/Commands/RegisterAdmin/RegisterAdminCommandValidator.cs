using FluentValidation;

namespace IndustrialServicesSystem.Application.Accounts.Commands.RegisterAdmin
{
    public class RegisterAdminCommandValidator : AbstractValidator<RegisterAdminCommand>
    {
        public RegisterAdminCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(128)
                .NotEmpty();
        }
    }
}
