using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PersonViewModel model)
        {
            var imageType = model.Picture.FileName;
            var fileExtension = Path.GetExtension(model.Picture.FileName);

            var isValidException = ".jpg,.png,.bmp".Split(',').Contains(fileExtension);

            if (isValidException)
            {
                var image = ProcessImage(model.Picture.InputStream);
                var width = image.Width;
                var height = image.Height;

                var folderPath = Server.MapPath("/Content/Images");

                var filePath = Path.Combine(folderPath, "image.png");

                //using (var outputStream = System.IO.File.Create(filePath))

                //{
                //    image.CopyTo(outputStream);
                //}
             }


            return View(model);
        }

        public Image ProcessImage(Stream inputImageStream)
        {
            return Image.FromStream(inputImageStream);
        }
        public class PersonViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public HttpPostedFileBase Picture { get; set; }
        }
    }

}