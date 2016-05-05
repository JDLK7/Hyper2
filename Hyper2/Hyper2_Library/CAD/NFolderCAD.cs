using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyper.CAD;
using Hyper.EN;

namespace Hyper.CAD
{
    class NFolderCAD
    {

        private string path;
        private string owner;

        public NFolderCAD()
        {
            this.path = "";
            this.path = "";
        }

        public NFolderCAD(NFolderEN en)
        {
            this.path = en.Path;
            this.owner = en.Owner;
        }

        public void Delete()
        {

        }
    }
}
