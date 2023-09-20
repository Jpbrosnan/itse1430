/*
 * ITSE 1430
 * Fall 2023
 */
namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Paragraphs of descriptions.
    /// </remarks>
    public class Movie
    {
        //Fields - data
        /// <summary>Title of movie.</summary>
        public string title = "";
        public string description = "";
        public string genre = "";
        public string rating = "";

        public int length;
        public int releaseYear = 1900;
        public bool isBlackAndWhite;

        /// <summary>
        /// Download metadata from internet.
        /// </summary>
        /// <remarks>
        /// Additional Info Large Amount.
        /// </remarks>
        void DownloadMetadata ()
        {

        }
        /// <summary>
        /// Validates the movie instance.
        /// </summary>
        /// <returns>
        /// Error message if invalid or empty string if valid
        /// </returns>
        public string Validate ()
        {
            //Title is required
            //REelease Year >= 1900
            //Length >= 0
            //Rating is in the list
            //If release year < 1940 than isblackandwhite must be true
            if (String.IsNullOrEmpty(title))
                return "Title is required!";
            if (releaseYear < 1900)
                return "release year must be greater than 1900";
            if (length < 0)
                return "length must be greater than or equal to 0";
            if (releaseYear < 1940 && !isBlackAndWhite)
                return "Movies before 1940 must be black and white";

            return "";
        }

    }
}