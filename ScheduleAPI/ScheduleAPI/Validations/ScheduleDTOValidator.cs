namespace ScheduleAPI.Validations;
using FluentValidation;
using ScheduleAPI.DTO;

public class ScheduleDTOValidator : AbstractValidator<ScheduleDTO>
{
    public ScheduleDTOValidator()
    {
        //RuleFor(x => x.ToDo)
        //    .NotEmpty()
        //    .NotNull()
        //    .WithMessage("ToDo Required");

        //RuleFor(x => x.Meal)
        //    .NotEmpty()
        //    .NotNull()
        //    .WithMessage("Meal Required");

        //RuleFor(x => x.TimeForRest)
        //    .NotEmpty()
        //    .NotNull()
        //    .WithMessage("TimeForRest Required");
    }
}
