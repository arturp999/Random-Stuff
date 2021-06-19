using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace miniProject.DTO
{
    public class CreateUserDTO
    {

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

    }
}

