using CatMash.MVC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.MVC.Models
{
    public class VoteModel
    {
        public CatPicture FirstCat { get; set; }

        public CatPicture SecondCat { get; set; }

        public int CatId { get; set; }

    }
}
