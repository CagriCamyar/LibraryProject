﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.BookName).MinimumLength(3);
            RuleFor(b => b.DailyPrice).NotNull();
            RuleFor(b => b.DailyPrice).GreaterThan(0);
        }
    }
}
