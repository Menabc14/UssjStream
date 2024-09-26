using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UssjStream.Web.Services.Videos;

namespace UssjStream.Web.Controllers
{
    [Authorize]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        public IActionResult Index()
        {
            _videoService.GetVideoById(1);

            var video = _videoService.GetVideoById(1);
            video.VideoUrl = Url.Content(_videoService.GetVideoUrl(video.Title));

            return View(video);
        }
    }
}