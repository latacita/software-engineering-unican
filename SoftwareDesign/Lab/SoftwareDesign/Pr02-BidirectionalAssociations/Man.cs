using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr02_BidirectionalAssociations
{
    /// <summary>
    ///     This class represents a man
    /// </summary>
    class Man
    {
        // Inv: name != null
        protected String name;

        public String Name {
            get { return name;}
            set { name = value; }
        } // Name

        protected Woman wife;

        public Woman Wife
        {
            get { return wife; }
            set {
                Woman newWife = value;
                Woman oldWife = wife;
                wife = newWife;
                if (oldWife != null) {
                    oldWife.Husband = null;
                } // if
                if ((newWife != null) && (!newWife.Husband.Equals(this))) {
                    newWife.Husband = this;
                } // if
            }
        } // Name

        /// <summary>
        ///     Checks whether this man is the same as the other man passed as paramenter
        /// </summary>
        /// <param name="otherMan">The other man that we need to check if it is equal to 
        /// the man receiving the call</param>
        /// <returns>True if both man are the same, otherwise false</returns>
        public override bool Equals(Object otherMan) {
            bool result = false;
            
            if (otherMan is Man)
            {
                result = name.Equals(((Man)otherMan).Name);
            } // if

            return result;
        } // Equals

    } // Man
}
