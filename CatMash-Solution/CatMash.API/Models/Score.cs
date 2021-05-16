using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.Models
{
    public class Score
    {
        public int VoteCount { get; set; }
        /// <summary>
        /// Calculated score based on the defined win's weight and the number of votes
        /// </summary>
        public int TotalScore { get; set; }
    }
}
