using Microsoft.AspNetCore.Http;

namespace Final_Project.ViewModels.Slider
{
    public class SliderEditVM
    {
        public string Title { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
