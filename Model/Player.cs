using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    interface Player
    {
        int getSelectedCol(Board board);
        int getPlayerNum();
        void setPlayerNum(int playerNum);
    }


}
