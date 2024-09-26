using UssjStream.Models;

namespace UssjStream.Web.Services.Videos
{
    public class VideoService: IVideoService
    {
        public string GetVideoUrl(string videoName)
        {
            return $"~/videos/{videoName}.mp4";
        }

        public Video GetVideoById(int idVideo)
        {
            var video = new Video
            {
                Id = idVideo,
                Title = "RM2Cesaire1",              
            };

            return video;
        }
    }
}
