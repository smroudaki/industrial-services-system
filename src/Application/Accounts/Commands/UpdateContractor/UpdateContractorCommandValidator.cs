using FluentValidation;

namespace IndustrialServicesSystem.Application.Accounts.Commands.UpdateContractor
{
    public class UpdateContractorCommandValidator : AbstractValidator<UpdateContractorCommand>
    {
        public UpdateContractorCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(128)
                .NotEmpty();
        }
    }
}
