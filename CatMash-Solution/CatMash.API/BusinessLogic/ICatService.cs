using CatMash.API.Messages;
using CatMash.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.BusinessLogic
{
    public interface ICatService
    {
         CatPicturesResponse GetCats();

        Tuple<CatPicture, CatPicture> GetCandidatesCats();

        bool InsertVote(VoteRequest voteRequest);
    }
}
