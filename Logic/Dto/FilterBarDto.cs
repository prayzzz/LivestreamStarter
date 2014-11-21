using System.Windows.Media;

namespace Logic.Dto
{
    public class FilterBarDto : BaseDto
    {
        public string Name { get; set; }

        public ImageSource Image { get; set; }

        public bool IsAllowed { get; set; }
    }
}