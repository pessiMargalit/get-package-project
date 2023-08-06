
namespace Dal.Models
{
    public class Size
    {
        public double Hight { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public Size(double hight, double width, double weight)
        {
            Hight = hight;
            Width = width;
            Weight = weight;
        }
    }
}
