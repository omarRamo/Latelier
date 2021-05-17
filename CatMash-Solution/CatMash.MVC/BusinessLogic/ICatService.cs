using CatMash.MVC.DTO;
using CatMash.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.MVC.BusinessLogic
{
    public interface ICatService
    {
        Task<CatsModel> GetCats();
        Task<Tuple<CatPicture, CatPicture>> GetCatsForVote();
        Task SendVote(VoteModel vote);
    }
}
