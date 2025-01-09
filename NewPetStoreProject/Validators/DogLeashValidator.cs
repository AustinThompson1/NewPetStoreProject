using FluentValidation;

namespace NewPetStoreProject
{
    public class DogLeashValidator : AbstractValidator<DogLeash>
    {
        public DogLeashValidator()
        {
            RuleFor(DogLeash => DogLeash.Name).NotNull();
            RuleFor(DogLeash => DogLeash.Price).GreaterThan(0);
            RuleFor(DogLeash => DogLeash.Quantity).GreaterThan(0);
            RuleFor(x => x.Description).MinimumLength(10).When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}
