using MediatR;

namespace SearchClothes.Application.Commands.Tags.CreateTag
{
    public class CreateTagCommand : TokenizedCommand, IRequest<bool>
    {
        public string Name { get; set; }
    }
}
