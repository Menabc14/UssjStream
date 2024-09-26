using UssjStream.Models;

namespace UssjStream.Web.Services.Videos
{
    public interface IVideoService
    {
        string GetVideoUrl(string videoName)
            ;
        Video GetVideoById(int idVideo);
    }
}
