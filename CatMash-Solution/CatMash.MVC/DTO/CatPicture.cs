using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.MVC.DTO
{
    public class CatPicture
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Score Score { get; set; }
    }
}
