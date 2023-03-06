using System.ComponentModel.DataAnnotations;

namespace cloudy_website.Models.Blocks
{

    public interface ITeaserBlock { }

    public class TeaserBlock : ITeaserBlock
    {
        public string Heading { get; set; }

        [UIHint("html")]
        public string Preamble { get; set; }

        public string Link { get; set; }
        public string LinkText { get; set; }
    }
}
