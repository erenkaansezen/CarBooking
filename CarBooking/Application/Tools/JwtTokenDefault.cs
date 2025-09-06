using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools
{
    public class JwtTokenDefault
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "WebRentACar+*010203WebRentACar01+*..020304WebRentACarProje";
        public const int Expire = 5;
    }
}
