using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
        }


        public string Username { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public bool IsActive { get; set; }
        public string DeactiveReson { get; set; }

        public DateTimeOffset? LastLoggedIn { get; set; }

        /// <summary>
        /// every time the user changes his Password,
        /// or an admin changes his Roles or stat/IsActive,
        /// create a new `SerialNumber` GUID and store it in the DB.
        /// </summary>
        public string SerialNumber { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }

        public string Mobile { get; set; }
        public DateTime? BirthDate { get; set; }

        public Guid CityId { get; set; }
        public virtual City City { get; set; }

        public string Address { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Image { get; set; }

    }
}