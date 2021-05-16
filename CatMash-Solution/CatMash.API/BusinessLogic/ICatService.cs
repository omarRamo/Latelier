using CatMash.API.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.BusinessLogic
{
    public interface ICatService
    {
         CatPicturesResponse GetCats();
    }
}
