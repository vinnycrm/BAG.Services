using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class A_ModelGroupsList
    {
        public U_USR_MASTER MasterData { get; set; }
        public U_USR_Lgn LoginData { get; set; }
        public U_EVNT_MASTER EventData { get; set; }
        public U_ADM_MEDIA_MASTER ImageData { get; set; }
        public U_ADM_ITEM_MASTER ItemData { get; set; }
    }
}
