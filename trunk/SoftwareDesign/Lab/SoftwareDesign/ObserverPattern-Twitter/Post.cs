using System;

namespace SoftwareDesign.Pr02.ObserverPattern
{
    /// <summary>
    ///     This class represents a simple post in the Dicotiledonea social network
    /// </summary>
    class Post
    {
        // Inv: text != null
        protected String text = "";

        /// <summary>
        ///     The text contained in a post
        /// </summary>
        public String Text {
            get { return text;}
            set { text = value;}
        } // Text

        public Post(String text) {
            this.text = text;
        } // Post constructor

    } // Post
} // 
