using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr02_BidirectionalAssociations.MormonMarriageStyle
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

        // Inv: (wifes != null) and (wifes.forAll(w : Wife | w.))
        protected ISet<Woman> wifes;

        /// <summary>
        ///     Constructor for the class Man
        /// </summary>
        /// <param name="name">The name of the man to be created</param>
        // Pre: name != null
        public Man(String name) {
            this.name = name;
            this.wifes = new HashSet<Woman>();
        } // Man(String name)

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
        ///     Adds a new wife to the Mormon's harem
        /// </summary>
        /// <param name="wife">The wife to be added to the harem</param>
        // Pre: wife != null
        public void AddWife(Woman wife) {
           
            this.wifes.Add(wife);
            if ((wife.Husband == null) || (!wife.Husband.Equals(this)))
            {
                wife.Husband = this;
            } // if
        } // 

        /// <summary>
        ///     The man gets divorced from the wife passed as a parameter
        /// </summary>
        /// <param name="wife">The woman to be divorced</param>
        // Pre: wife != null
        public void RemoveWife(Woman wife)
        {
            this.wifes.Remove(wife);
            wife.Husband = null;
        } // removeWife

        /// <summary>
        ///     Returns true if the woman passed as a parameter is in the Mormon's harem
        /// </summary>
        /// <param name="wife">The woman to be found</param>
        /// <returns>True if the woman is in the harem, otherwise false</returns>
        // Pre: wife != null
        public bool HasMarried(Woman wife)
        {
            return wifes.Contains(wife);
        } // isInHarem

        /// <summary>
        ///     Returns an appropriate hash code for this object
        /// </summary>
        public override int GetHashCode()
        {
            return name.GetHashCode();
        } // GetHashCode
        
    } // Man
}
