using System;
using System.Collections.Generic;

namespace SoftwareDesign.Pr02.ObserverPattern
{
    /// <summary>
    ///     This class represents a user in the Dicotiledonea social network
    /// </summary>
    class User
    {
        // Inv: (name != null)
        protected String name = "";
        
        /// <summary>
        ///     Name of the user
        /// </summary>
        public String Name {
            get {return name;}
            set {name = value;}
        } // Name

        protected ICollection<Post> userline = new LinkedList<Post>();

        /// <summary>
        ///     Constructs a new user using as name the value passed as a parameter
        /// </summary>
        /// <param name="name">The name of the user to be created</param>
        public User(String name) {
            this.name = name;
        } // User constructor

        public virtual void addPost(String text) {
            userline.Add(new Post(text));
        } // addPost

        public virtual bool containsPost(String text)
        {
            IEnumerator<Post> it = userline.GetEnumerator();

            it.Reset();
            
            bool found = false;

            while ((!found) && (it.MoveNext())) {

                found = it.Current.Text.Equals(text);
            } // while

            return found;

        } // getUserline

     } // User
} // SoftwareDesign.Pr02.ObserverPattern
