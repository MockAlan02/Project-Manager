

using FluentValidation;
using ManagerApi.Core.Dto;

namespace Persistencia.Validators
{
    public class TareaDtoValidator: AbstractValidator<TareaDto>
    {
        public TareaDtoValidator()
        {
            RuleFor(tarea => tarea.Detalles)
                .NotNull().Length(10, 50);
            RuleFor(tarea => tarea.Estado)
                .NotNull();
            RuleFor(tarea => tarea.ExpireTime)
                .NotNull();
            RuleFor(tarea => tarea.IdUser)
                .NotNull().Empty();

        }
    }
}
