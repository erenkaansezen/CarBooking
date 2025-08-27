using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Results.SocaimalMediaResults
{
    public class GetSocialMediaQueryResult
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Url { get; set; }
    }
}
