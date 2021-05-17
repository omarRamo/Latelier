using System;
using System.Collections.Generic;
using System.Text;

namespace CatMash.DataAccess.Entities
{
    public partial class TVote
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public DateTime? CreationDate { get; set; }

        public TCatPicture Cat { get; set; }
    }
}
