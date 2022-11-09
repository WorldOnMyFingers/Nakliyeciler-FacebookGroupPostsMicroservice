using System;
using FluentValidation;

namespace Application.GroupPosts.Commands.CreateGroupPost
{
    public class GroupPostDtoValidator : AbstractValidator<CreateGroupPostDto>
    {
        public GroupPostDtoValidator()
        {
            RuleForEach(model => model.Id)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("Please ensure Post id is populated");

            RuleFor(model => model.Message)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("Please ensure you have entered 'Message' field")
              .NotEmpty().WithMessage("Message field shouldn't be empty");

        }
        public class CreateGroupPostValidator : AbstractValidator<CreateGroupPostCommand>
        {
            public CreateGroupPostValidator()
            {
                RuleForEach(model => model.CreateGroupPostDtos).SetValidator(new GroupPostDtoValidator());
            }
        }
    }
}

