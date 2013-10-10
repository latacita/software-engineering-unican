using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pr02_BidirectionalAssociations.PeopleMustBeMarried;

namespace Pr02_BidirectionalAssociations.PeopleMustBeMarried
{
    /// <summary>
    ///     This class represents a man
    /// </summary>
    class Man
    {
        // Inv: name != null
        protected String name;

        /// <summary>
        ///     The name of this man
        /// </summary>
        public String Name {
            get { return name;}
            // Pre: value != null
            set { name = value; }
        } // Name

        // Inv: wife != null implies wife.Husband.Equals(this)
        protected Woman wife;

        /// <summary>
        ///     The woman this man has married
        /// </summary>
        public Woman Wife
        {
            get { return wife; }
            // Note: This operation can leaves several objects in an invalid state
            //       - ((@pre) this).IsValid() implies not ((@pre) this).Wife.IsValid()
            //       - ((@pre) value).IsValid() implies not ((@pre) value).Husband().IsValid()
            //       - (value == null) implies not this.IsValid()            
            set {
                Woman newWife = value;
                Woman oldWife = wife;
                wife = newWife;
                if (oldWife != null) {
                    oldWife.Husband = null;
                } // if
                if ((newWife != null) && ((newWife.Husband == null) || (!newWife.Husband.Equals(this))))
                {
                    newWife.Husband = this;
                } // if
            }
        } // Name

        /// <summary>
        ///     Constructor for the class Man
        /// </summary>
        /// <param name="name">The name of the man to be created</param>
        // Pre: name != null
        public Man(String name) {
            this.name = name;
        } // 

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
        public virtual bool IsValid() {
            return (this.wife != null);
        } // IsValid


    } // Man
}
