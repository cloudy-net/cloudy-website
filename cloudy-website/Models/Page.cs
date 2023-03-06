using Cloudy.CMS.EntitySupport;
using cloudy_website.Models.Blocks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cloudy_website.Models
{
    [Display(Description = "This is a sample class to show off most bells and whistles of the CMS.")]
    public class Page : INameable, IRoutable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Display]
        public string UrlSegment { get; set; }

        [UIHint("html")]
        public string MainBody { get; set; }


        public ITeaserBlock Teaser1 { get; set; }
        public ITeaserBlock Teaser2 { get; set; }
        public ITeaserBlock Teaser3 { get; set; }
    }
}
