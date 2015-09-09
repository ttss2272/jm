using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
namespace BusinessLayer
{
    public class BLTransferToTally
    {
        DLTransferToTally dlObjTranTally = new DLTransferToTally();
        public string transferTallyInv(string from, string to)
        {

            string msg = dlObjTranTally.transferTallyInv(from, to);
            return msg;

        }
        public string transferTallyRec(string from, string to)
        {

            string msg = dlObjTranTally.transferTallyRec(from, to);
            return msg;

        }
    }
}
