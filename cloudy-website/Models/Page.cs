using Cloudy.CMS.EntitySupport;
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
    }
}
