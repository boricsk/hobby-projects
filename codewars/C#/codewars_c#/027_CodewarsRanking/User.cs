using _027_CodewarsRanking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _027_CodewarsRanking
{
    public class User
    {

        public int rank { get; private set; }
        public int progress { get; private set; }

        private readonly List<int> _ranks = new() { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 };
        private int _index;
        public User()
        {
            _index = 0;
            rank = _ranks[_index];
            progress = 0;

        }

        public void incProgress(int taskRank)
        {
            if (!_ranks.Contains(taskRank))
                throw new ArgumentException("Wrong rank!");

            int taskIndex = _ranks.IndexOf(taskRank);
            int diff = taskIndex - _index;

            if (diff == 0) progress += 3;
            else if (diff == -1) progress += 1;
            else if (diff > 0) progress += 10 * diff * diff;

            UpdateRank();

        }

        public void UpdateRank()
        {
            while (progress >= 100 && rank < 8)
            {
                progress -= 100;
                _index++;
                rank = _ranks[_index];
            }

            if (rank == 8) progress = 0;
        }
    }
}
