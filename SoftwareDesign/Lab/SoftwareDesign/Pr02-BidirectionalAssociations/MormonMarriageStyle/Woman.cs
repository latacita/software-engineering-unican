using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr02_BidirectionalAssociations.MormonMarriageStyle
{
    /// <summary>
    ///     This class represents a woman
    /// </summary>
    class Woman
    {

        // Inv: name != null
        protected String name;

        /// <summary>
        ///     The name of this woman
        /// </summary>
        public String Name
        {
            get { return name; }
            // value != null
            set { name = value; }
        } // Name

        // Inv: (husband != null) implies husband.HasMarried(this)
        protected Man husband;

        /// <summary>
        ///     The man who has married this woman, in case she is married.
        ///     Otherwise, this property is set to null
        /// </summary>
        public Man Husband
        {
            get { return husband; }
            set {
                Man newHusband = value;
                Man oldHusband = husband;
                husband = newHusband;
                if ((oldHusband != null) && (oldHusband.HasMarried(this))) {
                    oldHusband.RemoveWife(this);
                } // if
                if ((newHusband != null) && (!newHusband.HasMarried(this)))
                {
                    newHusband.AddWife(this);
                } // if
            }
        } // Name

        /// <summary>
        ///     Constructor for the class Woman    
        /// </summary>
        /// <param name="name">The name of the woman to be created</param>
        // Pre: name != null
        public Woman(String name) {
            this.name = name;
        } // Woman

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

        /// <summary>
        ///     Returns an appropriate hash code for this object
        /// </summary>
        public override int GetHashCode()
        {
            return name.GetHashCode();
        } // GetHashCode
        
    } // Woman
} // Pr02_BidirectionalAssociations
