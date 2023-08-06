
namespace BL.DTO
{
    public class SizeBL
    {
        public double Hight { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public SizeBL(double hight, double width, double weight)
        {
            Hight = hight;
            Width = width;
            Weight = weight;
        }
    }
}
