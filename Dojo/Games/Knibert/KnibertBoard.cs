using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dojo.Games.Mollymage;
using Dojo.Infrastructure;

namespace Dojo.Games.Knibert
{
    public class KnibertBoard : AbstractBoard<KnibertElement>
    {
        public KnibertBoard(string boardString) : base(boardString)
        {
        }

        public Point GetApple()
        {
            var point = Get(KnibertElement.GOOD_APPLE);
            if (!point.Any())
            {
                throw new NullReferenceException("Apple element has not been found.");
            }

            return point.FirstOrDefault();

        }

        //public override string ToString()
        //{
        //    return string.Format("{0}\n", BoardAsString());
        //}

        public Point GetBadApple()
        {
            var point = Get(KnibertElement.BAD_APPLE);
            if (!point.Any())
            {
                throw new NullReferenceException("Bad apple element has not been found.");
            }

            return point.FirstOrDefault();

        }

        public Point GetHead()
        {
            var points = Get(
                    KnibertElement.HEAD_UP,
                    KnibertElement.HEAD_DOWN,
                    KnibertElement.HEAD_LEFT,
                    KnibertElement.HEAD_RIGHT);
            if (!points.Any())
            {
                throw new NullReferenceException("Head element has not been found.");
            }

            return points.FirstOrDefault();
        }

        public List<Point> GetBreak()
        {
            return Get(KnibertElement.BREAK);
        }

        public List<Point> GetSnake()
        {
            var Points = Get(KnibertElement.HEAD_UP,
                    KnibertElement.HEAD_DOWN,
                    KnibertElement.HEAD_LEFT,
                    KnibertElement.HEAD_RIGHT,
                    KnibertElement.TAIL_HORIZONTAL,
                    KnibertElement.TAIL_VERTICAL,
                    KnibertElement.TAIL_LEFT_DOWN,
                    KnibertElement.TAIL_LEFT_UP,
                    KnibertElement.TAIL_RIGHT_DOWN,
                    KnibertElement.TAIL_RIGHT_UP,
                    KnibertElement.TAIL_END_DOWN,
                    KnibertElement.TAIL_END_LEFT, 
                    KnibertElement.TAIL_END_UP,
                    KnibertElement.TAIL_END_RIGHT);

            return Points;
        }
    }
}
