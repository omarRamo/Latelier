using CatMash.MVC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.MVC.Models
{
    public class CatsModel
    {
        public IEnumerable<CatPicture> Cats { get; set; }
    }
}
