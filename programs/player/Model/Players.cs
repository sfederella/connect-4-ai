using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    class Players
    {
        int turn;
        Player playerX;
        Player playerO;

        public Players(Player playerX, Player playerO)
        {
            this.playerX = playerX;
            this.playerO = playerO;
            this.playerX.setPlayerNum(1);
            this.playerO.setPlayerNum(-1);
            turn = -1;
        }

        public Player next()
        {
            turn = turn * -1;
            return (turn == 1 ? playerX : playerO);
        }
    }
}
