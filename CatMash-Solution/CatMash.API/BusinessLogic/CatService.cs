using CatMash.API.Messages;
using CatMash.API.Models;
using CatMash.API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.BusinessLogic
{
    public class CatService : ICatService
    {
        public CatPicturesResponse GetCats()
        {
            // mock list of cats,
            CatPicturesResponse cats = new CatPicturesResponse();

            cats.Cats = new List<CatPicture>
                {
                    new CatPicture{ Id=1, Url="http://25.media.tumblr.com/tumblr_m33r7lpy361qzi9p6o1_500.jpg", Score= ScoreCalculator.CalculateScore(8) },
                    new CatPicture{ Id=2, Url="http://24.media.tumblr.com/tumblr_m1ku66jPWV1qze0hyo1_400.jpg", Score= ScoreCalculator.CalculateScore(3) },
                    new CatPicture{ Id=2, Url="http://25.media.tumblr.com/tumblr_lyj0y5tg4L1qbwemzo1_1280.jpg", Score= ScoreCalculator.CalculateScore(2) },
                    new CatPicture{ Id=3, Url="http://25.media.tumblr.com/Jjkybd3nS98hfqy8vevnj6R9_500.jpg", Score= ScoreCalculator.CalculateScore(0) }
                };

            return cats;
        }
    }
}
