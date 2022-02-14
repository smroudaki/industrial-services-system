using FluentValidation;

namespace IndustrialServicesSystem.Application.Accounts.Commands.RegisterClient
{
    public class RegisterClientCommandValidator : AbstractValidator<RegisterClientCommand>
    {
        public RegisterClientCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(128)
                .NotEmpty();
        }
    }
}
