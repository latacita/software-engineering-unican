using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pr02_BidirectionalAssociations.PeopleMustBeMarried;

namespace Pr02_BidirectionalAssociations.PeopleMustBeMarried
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

        // Inv: husband.Wife.Equals(this)
        protected Man husband;

        /// <summary>
        ///     The man who has married this woman
        /// </summary>
        public Man Husband
        {
            get { return husband; }
            // Note: This operation can leaves several objects in an invalid state
            //       - ((@pre) this).IsValid() implies not ((@pre) this).Husband.IsValid()
            //       - ((@pre) value).IsValid() implies not ((@pre) value).Wife().IsValid()
            //       - (value == null) implies not this.IsValid()
            set {
                Man newHusband = value;
                Man oldHusband = husband;
                husband = newHusband;
                if (oldHusband != null) {
                    oldHusband.Wife = null;
                } // if
                if ((newHusband != null) && ((newHusband.Wife == null) || (!newHusband.Wife.Equals(this))))
                {
                    newHusband.Wife = this;
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

        /// <summary>
        ///     Checks if the object satifies all its invariants
        /// </summary>
        /// <returns>
        ///     True if the objects satisfies all its invariants, otherwise false
        /// </returns>
        public virtual bool IsValid()
        {
            return this.husband != null;
        } // IsValid
        
    } // Woman
} // Pr02_BidirectionalAssociations
