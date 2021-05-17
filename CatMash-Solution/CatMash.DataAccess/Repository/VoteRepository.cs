using CatMash.DataAccess.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatMash.DataAccess.Repository
{
    public class VoteRepository : IVoteRepository
    {
        private readonly CatMashDbContext _catMashDbContext;
        private readonly ILogger<VoteRepository> _logger;

        public VoteRepository(CatMashDbContext catMashDbContext, ILogger<VoteRepository> logger)
        {
            _catMashDbContext = catMashDbContext;
            _logger = logger;
        }

        public int InsertVote(TVote vote)
        {
            if (vote == null)
            {
                return 0;
            }

            if (vote.CatId <= 0)
            {
                _logger.LogError($"Invalid Vote. WinCatId: {vote.CatId}");
                throw new Exception();
            }

            if (_catMashDbContext.TCatPicture.Where(c => c.Id == vote.CatId).Count() <= 0)
            {
                _logger.LogError($"Cat Not Found for this Vote. CatId : {vote.CatId}");
                throw new Exception();
            }

            try
            {
                vote.CreationDate = DateTime.UtcNow;
                _catMashDbContext.TVote.Add(vote);

                return _catMashDbContext.SaveChanges();
            }
            catch (Exception exp)
            {
                _logger.LogError("DataAccessException");
                throw new Exception("DataAccessException", exp);
            }
        }
    }
}
