using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADN.Samples.WebDemo.Models
{
    public class QuizViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TopicViewModel> Topics { get; set; }
    }
}