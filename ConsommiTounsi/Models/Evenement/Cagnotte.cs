using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Evenement
{
    public class Cagnotte

    {
        public int id { get; set; }
        public int jackpot { get; set; }
        public List<Ticket> tickets { get; set; }
        public DateTime cagnotteDate { get; set; }
        public Boolean expired { get; set; }




    }
}