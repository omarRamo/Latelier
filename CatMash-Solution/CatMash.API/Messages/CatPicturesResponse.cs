using CatMash.API.Models;
using System;
using System.Collections.Generic;

namespace CatMash.API.Messages
{
    public class CatPicturesResponse
    {
        public IEnumerable<Tuple<CatPicture,CatPicture>> Cats { get; set; }
    }
}
