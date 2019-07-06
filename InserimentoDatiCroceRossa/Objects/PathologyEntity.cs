using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class PathologyEntity :  BaseEntity
    {
        public PathologyEntity() : base()
        {

        }

        private string m_PathologyName;

        public string PathologyName
        {
            get { return m_PathologyName; }
            set { m_PathologyName = value; }
        }

    }
}
