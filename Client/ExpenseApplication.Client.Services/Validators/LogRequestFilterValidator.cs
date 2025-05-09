using FluentValidation;

namespace ExpenseApplication.Client.Services.Validators;

public class LogRequestFilterValidator : AbstractValidator<LogRequestFilterDto>
{
    public LogRequestFilterValidator()
    {
        RuleFor(logRequestFilter => logRequestFilter.StartTimeStamp)
            .LessThanOrEqualTo(logRequestFilter => logRequestFilter.EndTimeStamp)
            .When(logRequestFilter => logRequestFilter.EndTimeStamp.HasValue)
            .WithMessage("Start date should be less than or equal to end date!")
            .WithName(logRequestFilter => nameof(logRequestFilter.StartTimeStamp));

        RuleFor(logRequestFilter => logRequestFilter.EndTimeStamp)
            .GreaterThanOrEqualTo(logRequestFilter => logRequestFilter.StartTimeStamp)
            .When(logRequestFilter => logRequestFilter.StartTimeStamp.HasValue)
            .WithMessage("End date should be greater than or equal to start date!")
            .WithName(logRequestFilter => nameof(logRequestFilter.EndTimeStamp));

        RuleFor(logRequestFilter => logRequestFilter.Level)
            .MaximumLength(50)
            .WithMessage("Maximum length of Level is 50 characters!")
            .WithName(logRequestFilter => nameof(logRequestFilter.Level));

        RuleFor(logRequestFilter => logRequestFilter.Message)
            .MaximumLength(100)
            .WithMessage("Maximum length of Message is 100 characters!")
            .WithName(logRequestFilter => nameof(logRequestFilter.Message));
    }
}