using FluentValidation;
using PetStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPetStoreProject.Validators
{
    public class AddProductValidator : AbstractValidator<Product>
    {
        public AddProductValidator()
        {
            RuleFor(Product => Product.Name).NotNull();
            RuleFor(Product => Product.Price).GreaterThan(0);
            RuleFor(Product => Product.Quantity).GreaterThan(0);
            RuleFor(Product => Product.Description).MinimumLength(10).When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}
