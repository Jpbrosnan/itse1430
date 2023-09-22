/*
 * ITSE 1430
 * Fall 2023
 */
namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Additional remarks to help when using the class.
    /// </remarks>
    public class Movie
    {
        //Fields - data
        /// <summary>Title of movie.</summary>
        private string title = "";
        private string description = "";
        private string genre = "";
        private string rating = "";

        private int length;
        private int releaseYear = 1900;
        private bool isBlackAndWhite;

        //Properties - data with functionality

        public string Title
        {
            get { return title; }
            set {
                title = value;
            }
        }
        public string Description
        {
            get { return description; }
            set {
                description=value;
            }
        }
        public string Genre
        {
            get {
                return genre;
            }
            set {
                genre=value;
            }
        }
        public string Rating
        {
            get {
                return rating;
            }
            set {
                rating=value;
            }
        }
        public int Length
        {
            get {
                return length;
            }
            set {
                length=value;
            }
        }
        public int ReleaseYear
        {
            get {
                return releaseYear;
            }
            set {
                releaseYear=value;
            }
        }
        public bool IsBlackAndWhite
        {
            get {
                return isBlackAndWhite;
            }
            set {
                isBlackAndWhite=value;
            }
        }

        //Methods - functionality

        /// <summary>Download metadata from Internet.</summary>
        /// <remarks>
        /// Searches IMDB and TheTVDB.com.
        /// </remarks>
        private void DownloadMetadata ()
        { }

        /// <summary>Validates the movie instance.</summary>
        /// <returns>Error message if invalid or empty string otherwise.</returns>
        public string Validate () /* Movie this */
        {
            //Title is required
            //if (String.IsNullOrEmpty(this.title))
            if (String.IsNullOrEmpty(title))
                return "Title is required";

            //var releaseYear = 10;

            //Release Year >= 1900
            //if (this.releaseYear < 1900)
            if (ReleaseYear < 1900)
                return "Release Year must be >= 1900";

            //Length >= 0
            if (Length < 0)
                return "Length must be at least 0";

            //TODO: Rating is in a list

            //If ReleaseYear < 1940 then IsBlackAndWhite must be true
            if (ReleaseYear < 1940 && !IsBlackAndWhite)
                return "Movies before 1940 must be black and white";

            //Valid
            return "";
        }
    }
}