using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework_59.CL;

namespace Homework_59.Models
{
    public class LikeViewModel
    {
        public string Message { get; set; }
        public Images Image { get; set; }
        public int HighestId { get; set; }
    }
}