using CatMash.DataAccess.Entities;
using System.Collections.Generic;

namespace CatMash.DataAccess.Repository
{
    public interface ICatPictureRepository
    {
        IEnumerable<TCatPicture> GetCatsPictures();

        TCatPicture GetCatPictureById(int id);

        TCatPicture GetCatPictureRandomly();
    }
}
