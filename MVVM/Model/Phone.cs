using System;
namespace MVVM.Model
{
    public class Phone
    {
        public Phone()
        {
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }
}
