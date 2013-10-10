using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pr02_BidirectionalAssociations.TotalPolygamy
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
            // Pre: name != null
            set { name = value; }
        } // Name

        // Inv: (wifes != null) and wifes.forAll(w : Woman | w.hasMarried(this)) 
        protected ISet<Woman> wifes;

        /// <summary>
        ///     Constructor for the class Man
        /// </summary>
        /// <param name="name">Ther name of the man to be created</param>
        // Pre: name != null
        public Man(String name) {
            this.name  = name;
            this.wifes = new HashSet<Woman>();
        } // Man

        /// <summary>
        ///     Adds a new wife to the man's harem
        /// </summary>
        /// <param name="wife">The new wife for this lucky man</param>
        // Pre: wife != null
        public void AddWife(Woman wife)
        {
            wifes.Add(wife);
            if (!wife.HasMarried(this)) {
                wife.AddHusband(this);
            } // if
        } // AddWife

        /// <summary>
        ///     Divorces a wife from this man
        /// </summary>
        /// <param name="wife">The wife to be divorced</param>
        // Pre: (wife != null) and (this.hasMarried(wife))
        public void RemoveWife(Woman wife)
        {
            wifes.Remove(wife);
            if (wife.HasMarried(this))
            {
                wife.RemoveHusband(this);
            } // if
        } // RemoveWife

        /// <summary>
        ///     Checks whether this man has married the woman passed as a parameter
        /// </summary>
        /// <param name="wife">A woman</param>
        /// <returns>Turn if the man has married the woman passed as a parameter, 
        ///          otherwise it returns false</returns>
        public bool HasMarried(Woman wife)
        {
            return wifes.Contains(wife);
        } // HasMarried

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
        ///     Returns an appropriate hash code for this
        /// </summary>
        /// <returns> A hash value for this object</returns>
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

    } // Man
}
