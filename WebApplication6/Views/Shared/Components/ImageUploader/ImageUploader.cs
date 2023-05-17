using Microsoft.AspNetCore.Mvc;
namespace WebApplication6.Views.Shared.Components.ImageUploader
{
    public class ImageUploader:ViewComponent
    {
        public ImageUploader()
        {

        }
        public IViewComponentResult Invoke(string FieldName) 
        { 
            return View("Default", FieldName); 
        }
    }
}
