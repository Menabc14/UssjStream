using Microsoft.AspNetCore.Mvc;
using UssjStream.Models;

namespace UssjStream.Web.Controllers
{

    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            var video = new Video
            {
                Id = 1,
                Title = "Video1",
                VideoUrl = Url.Content($"~/videos/RM2Cesaire1.mp4")
            };

            return View(video);
        }
    }
}