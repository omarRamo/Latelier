using System;
using System.Collections.Generic;
using System.Text;

namespace CatMash.DataAccess.Entities
{
    public partial class TCatPicture
    {
        public TCatPicture()
        {
            TVoteWinCat = new HashSet<TVote>();
        }

        public int Id { get; set; }
        public string Url { get; set; }

        public ICollection<TVote> TVoteWinCat { get; set; }
    }
}
