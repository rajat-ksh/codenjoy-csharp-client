using Dojo.Games.Mollymage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Games.Knibert
{
    public class KnibertSolver : ISolver
    {
        public string Get(IBoard gameBoard)
        {
            return Get(gameBoard as KnibertBoard);
        }

        private string Get(KnibertBoard gameBoard)
        {


            // TODO your code here
            return KnibertCommand.UP;
        }
    }
}
