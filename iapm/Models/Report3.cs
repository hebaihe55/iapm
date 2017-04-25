using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iapm.Models
{
    public class Report3
    {
        public int Report3id { set; get; }
        //日期
        public DateTime R3date { set; get; }

        //摇一摇人数
        public int R3pnum { set; get; }

        //摇到金币人数
        public int R3jbnum { set; get; }

        //参与游戏次数
        public int R3cynum { set; get; }

        //发出金币
        public int R3fc { set; get; }
        //兑换奖品
        public int R3prize { set; get; }

        //LG2
        public int R3LG2 { set; get; }

        //LG1
        public int R3LG1 { set; get; }

        //L1
        public int R3L1 { set; get; }
        //L2
        public int R3L2 { set; get; }
        //L3
        public int R3L3 { set; get; }
        //L4
        public int R3L4 { set; get; }
        //L5

        public int R3L5 { set; get; }
        //L6
        public int R3L6 { set; get; }

    }
}