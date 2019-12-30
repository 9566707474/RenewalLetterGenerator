namespace RenewalLetterGenerator.Models
{
    /// <summary>
    /// Customer Model
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Unique customer id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Customer title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Customer First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Customer surname
        /// </summary>
        public string Surname { get; set; }
    }
}
