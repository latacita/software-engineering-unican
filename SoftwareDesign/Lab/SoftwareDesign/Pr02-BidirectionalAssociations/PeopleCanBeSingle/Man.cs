using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr02_BidirectionalAssociations.PeopleCanBeSingle
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
        ///     The woman this man has married, in case he is married.
        ///     If not married, its value is null
        /// </summary>
        public Woman Wife
        {
            get { return wife; }
            set {
                Woman newWife = value;
                Woman oldWife = wife;

                this.wife = newWife;
                if (oldWife != null) {
                    oldWife.Husband = null;
                } // if
                if ((newWife != null) && ((newWife.Husband == null) || (!newWife.Husband.Equals(this)))) {
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
        
    } // Man
}
