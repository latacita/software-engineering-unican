using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr02_BidirectionalAssociations.TotalPolygamy
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
            // Pre: value != null
            set { name = value; }
        } // Name

        // Inv: (husbands != null) and husbands.forAll(h : Man | h.HasMarried(this)) 
        protected ISet<Man> husbands;

        /// <summary>
        ///     Constructor for the class Woman
        /// </summary>
        /// <param name="name">Ther name of the woman to be created</param>
        // Pre: name != null
        public Woman(String name) {
            this.name  = name;
            this.husbands = new HashSet<Man>();
        } // Woman

        /// <summary>
        ///     Adds a new husband to the woman's harem
        /// </summary>
        /// <param name="husband">The new husband for this lucky woman</param>
        // Pre: husband != null
        public void AddHusband(Man husband)
        {
            husbands.Add(husband);
            if (!husband.HasMarried(this))
            {
                husband.AddWife(this);
            } // if
        } // AddHusband

        /// <summary>
        ///     Divorces a husband from this wife
        /// </summary>
        /// <param name="husband">The husband to be divorced</param>
        // Pre: (husband != null) and (this.hasMarried(husband))
        public void RemoveHusband(Man husband)
        {
            husbands.Remove(husband);
            if (husband.HasMarried(this))
            {
                husband.RemoveWife(this);
            } // if
        } // RemoveHusband

        /// <summary>
        ///     Checks whether this woman has married the man passed as a parameter
        /// </summary>
        /// <param name="husband">A man</param>
        /// <returns>True if the woman has married the man passed as a parameter, 
        ///          otherwise it returns false</returns>
        public bool HasMarried(Man husband)
        {
            return husbands.Contains(husband);
        } // HasMarried
        
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
        ///     Returns an appropriate hash code for this
        /// </summary>
        /// <returns> A hash value for this object</returns>
        public override int GetHashCode()
        {
            return name.GetHashCode();
        } // GetHashCode
        
    } // Woman
} // Pr02_BidirectionalAssociations.TotalPolygamy
