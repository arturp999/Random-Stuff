namespace miniProject.Database.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="User" />.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the UID.
        /// </summary>
        [StringLength(80)]
        public string UID { get; set; } = Guid.NewGuid().ToString().Replace("-", "").ToString();

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        [StringLength(255)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        public short State { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate.
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the UpdateDate.
        /// </summary>
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
