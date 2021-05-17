using CatMash.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatMash.DataAccess.Repository
{
    public class CatPictureRepository : ICatPictureRepository
    {
        private readonly CatMashDbContext _catMashDbContext;

        public CatPictureRepository(CatMashDbContext catMashDbContext)
        {
            _catMashDbContext = catMashDbContext;
        }

        public IEnumerable<TCatPicture> GetCatsPictures()
        {
            return _catMashDbContext.TCatPicture.Include(c => c.TVoteWinCat);
        }

        public TCatPicture GetCatPictureById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _catMashDbContext.TCatPicture.Where(c => c.Id == id).FirstOrDefault();
        }

        public TCatPicture GetCatPictureRandomly()
        {
            return _catMashDbContext.TCatPicture.OrderBy(o => Guid.NewGuid()).First();
        }
    }
}
