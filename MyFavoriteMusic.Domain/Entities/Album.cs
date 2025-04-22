using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Domain.Entities
{
    public class Album
    {

        protected Album()
        {

        }
        public Album(string title, decimal rate)
        {
            this.Title = title;
            this.Rate = rate;
        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public decimal Rate { get; private set; }

        public void ChangeTitle(string title)
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title), "The title cannot be empty!");


            this.Title = title;
        }

        public void ChangeRate(decimal rate)
        {
            if (rate < 0)
                throw new ArgumentOutOfRangeException(nameof(rate), "The rate cannot be below 0!");

            if (rate > 10)
                throw new ArgumentOutOfRangeException(nameof(rate), "The rate cannot be above 10!");

            this.Rate = rate;
        }

    }
}
