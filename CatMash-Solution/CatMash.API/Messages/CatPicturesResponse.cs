using CatMash.API.Models;
using System.Collections.Generic;

namespace CatMash.API.Messages
{
    public class CatPicturesResponse
    {
        public IEnumerable<CatPicture> Cats { get; set; }
    }
}
