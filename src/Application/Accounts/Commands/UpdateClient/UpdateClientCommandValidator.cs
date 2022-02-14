using FluentValidation;

namespace IndustrialServicesSystem.Application.Accounts.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(128)
                .NotEmpty();
        }
    }
}
