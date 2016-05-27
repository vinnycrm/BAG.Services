using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class Groups
    {
        public string Group_Id
        {
            get { return _Group_Id; }
            set { _Group_Id = value; }
        }
        private string _Group_Id;

        public string Group_Name
        {
            get { return _Group_Name; }
            set { _Group_Name = value; }
        }
        private string _Group_Name;

        public Groups() { }
        public Groups(
            string Group_Id,
            string Group_Name
            )
        {
            _Group_Id = Group_Id;
            _Group_Name = Group_Name;
        }

    }
}
