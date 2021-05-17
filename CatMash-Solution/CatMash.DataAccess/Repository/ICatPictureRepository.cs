using CatMash.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatMash.DataAccess.Repository
{
    public interface ICatPictureRepository
    {
        IEnumerable<TCatPicture> GetCatsPictures();

        TCatPicture GetCatPictureById(int id);
    }
}
