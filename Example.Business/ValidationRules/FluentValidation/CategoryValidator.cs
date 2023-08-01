using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Entities.Models;
using FluentValidation;

namespace Example.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).Length(2,100);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).Length(5, 200);
            RuleFor(c => c.Name).Must(NotStartWith);
        }

        private bool NotStartWith(string arg)
        {
            return !arg.ToLower().StartsWith('ğ');
        }
    }
}
