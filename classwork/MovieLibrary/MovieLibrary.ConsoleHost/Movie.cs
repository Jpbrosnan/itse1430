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
        private string _title;
        private string _description;
        private string _genre;
        private string _rating;

        //private int _length;
        //private int _releaseYear = 1900;
        //private bool _isBlackAndWhite;
        
        /// <summary>
        /// Gets or sets the unique indentifier of the movie.
        /// </summary>
        public int Id { get; private set; }

        public const int MinimumReleaseYear = 1900;
        //Calculated Property
        public bool NeedsIntermission
        {
            get { return RunLength >= 150; }
            //set { }
        }

        //Properties - data with functionality

        public string Title
        {
            get { 
                if(String.IsNullOrEmpty(_title))
                    return "";

                return _title;
            }
            set {
                if(value != null)
                    value = value.Trim();
                _title = value;
            }
        }
        public string Description
        {
            get {
                if (String.IsNullOrEmpty(_description))
                    return "";

                return _description; 
            }
            set {
                if (value != null)
                    value = value.Trim();
                _description=value;
            }
        }
        public string Genre
        {
            get {
                if (String.IsNullOrEmpty(_genre))
                    return "";

                return _genre;
            }
            set {
                if (value != null)
                    value = value.Trim();
                _genre=value;
            }
        }
        public string Rating
        {
            get {
                if (String.IsNullOrEmpty(_rating))
                    return "";
                
                return _rating;
            }
            set {
                if (value != null)
                    value = value.Trim();
                _rating=value;
            }
        }
        public int ReleaseYear { get; set; } = MinimumReleaseYear;
        public int RunLength
        {
            get;
            set;
        }
        public bool IsBlackAndWhite
        {
            get;
            set;
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
            if (String.IsNullOrEmpty(_title))
                return "Title is required";

            //var releaseYear = 10;

            //Release Year >= 1900
            //if (this.releaseYear < 1900)
            if (ReleaseYear < MinimumReleaseYear)
                return $"Release Year must be >= {MinimumReleaseYear}";

            //Length >= 0
            if (RunLength < 0)
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