﻿using AutoMapper;
using CatMash.API.DTO;
using CatMash.API.Messages;
using CatMash.API.Models;
using CatMash.API.Utility;
using CatMash.DataAccess.Entities;
using CatMash.DataAccess.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.BusinessLogic
{
    public class CatService : ICatService
    {
        private readonly ILogger<CatService> _logger;
        private readonly IMapper _mapper;
        private readonly ICatPictureRepository _catPictureRepository;
        private readonly IVoteRepository _voteRepository;
        private const int MAX_RANDOM_TRY = 50;
        public CatService(ILogger<CatService> logger, IMapper mapper, ICatPictureRepository catPictureRepository, IVoteRepository voteRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _catPictureRepository = catPictureRepository;
            _voteRepository = voteRepository;
        }
        public CatPicturesResponse GetCats()
        {
            var listCatsPictures = _catPictureRepository.GetCatsPictures().ToList();

            var catsPictures = new List<CatPicture>();

            foreach (var cat in listCatsPictures)
            {
                catsPictures.Add(new CatPicture
                {
                    Id = cat.Id,
                    Url = cat.Url,
                    Score = ScoreCalculator.CalculateScore(cat.TVoteWinCat.Count())
                });
            }

            catsPictures = catsPictures.OrderBy(c => c.Score?.TotalScore)
                     .OrderByDescending(c => c.Score?.TotalScore)
                     .ThenBy(c => c.Id).ToList();

            var listofT = new List<Tuple<CatPicture, CatPicture>>(); 
            for (int i = 0; i < catsPictures.Count - 1;)
            {
                var t = new Tuple<CatPicture, CatPicture>(catsPictures[i], catsPictures[i + 1]);
                listofT.Add(t);
                i = i + 2;
            }
            return new CatPicturesResponse()
            {
                Cats = listofT
            };
        }

        public Tuple<CatPicture, CatPicture> GetCandidatesCats()
        {
            var firstCat = _mapper.Map<CatPicture>(_catPictureRepository.GetCatPictureRandomly());


            var nbrTrie = 0;

            var secondCat = _mapper.Map<CatPicture>(_catPictureRepository.GetCatPictureRandomly());
            while (secondCat.Id == firstCat.Id && nbrTrie < MAX_RANDOM_TRY)
            {
                secondCat = _mapper.Map<CatPicture>(_catPictureRepository.GetCatPictureRandomly());
                if (secondCat.Id != firstCat.Id)
                {
                    break;
                }
            }

            if (secondCat.Id == firstCat.Id)
            {
                return null;
            }
            else
            {
                return Tuple.Create(firstCat, secondCat);
            }

        }

        public bool InsertVote(VoteRequest voteRequest)
        {
            var vote = _mapper.Map<TVote>(voteRequest);
            var updateCount = _voteRepository.InsertVote(vote);

            return updateCount > 0;
        }
    }
}
