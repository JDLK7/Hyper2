using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Hyper.EN;
using Hyper.CAD;

namespace Hyper.EN
{
    public abstract class DataEN
    {
        protected int id;
        protected string date;
        protected string name;
        protected string route;
        protected bool visibility;
        
        public DataEN()
        {
            id = -1;
            date = "";
            name = "";
            route = "";
            visibility = false;
        }
        
        public DataEN(int nid, string ndate, string nname,
            string nroute, bool nvisibility)
        {
            id = nid;
            date = ndate;
            name = nname;
            route = nroute;
            visibility = nvisibility;
        }

        public string GetRoute(int s_id)
        {
            return DataCAD.GetRoute(s_id);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Route
        {
            get { return route; }
            set { route = value; }
        }

        public bool Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

    }
}