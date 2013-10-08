using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr02_BidirectionalAssociations
{
    /// <summary>
    ///     This class represents a woman
    /// </summary>
    class Woman
    {

        // Inv: name != null
        protected String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        } // Name

        protected Man husband;

        public Man Husband
        {
            get { return husband; }
            set {
                Man newHusband = value;
                Man oldHusband = husband;
                husband = newHusband;
                if (oldHusband != null) {
                    oldHusband.Wife = null;
                } // if
                if ((newHusband != null) && (!newHusband.Wife.Equals(this))) {
                    newHusband.Wife = this;
                } // if
            }
        } // Name

        /// <summary>
        ///     Checks whether this woman is the same as the other woman passed as parameter
        /// </summary>
        /// <param name="otherMan">The other woman that we need to check if it is equal to 
        /// the woman receiving the call</param>
        /// <returns>True if both woman are the same, otherwise false</returns>
        public override bool Equals(Object otherWoman)
        {
            bool result = false;

            if (otherWoman is Woman)
            {
                result = name.Equals(((Woman) otherWoman).Name);
            } // if

            return result;
        } // Equals
        
    } // Woman
} // Pr02_BidirectionalAssociations
