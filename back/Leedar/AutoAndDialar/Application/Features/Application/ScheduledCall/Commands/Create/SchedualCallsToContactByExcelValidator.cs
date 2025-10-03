using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.ScheduledCall.Commands.Create
{
    public class SchedualCallsToContactByExcelValidator : AbstractValidator<SchedualCallsToContactByExcelCommand>
    {
        public SchedualCallsToContactByExcelValidator()
        {

        }
    }
}
