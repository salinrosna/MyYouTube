using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUtubeApp.Models
{
    public class VideoViewModel
    {
        public int Channel { get; set; }
        public string VideoName { get; set; }
        public string VideoDescription { get; set; }
        public string VideoURL { get; set; }
    }
}