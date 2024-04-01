namespace XFood.API.Photos.Commands.Create
{
    public record CreatePhotoRequest(List<IFormFile>? Photos, int AppealId);
}
