
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using DomainClasses.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace DomainClasses.Entities
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual string FirstName { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual string LastName { get; set; }
        public virtual string AvatarPath { get; set; }
        [InverseProperty("UsersFavorite")]
        public virtual ICollection<Product> ProductsFavorite { get; set; }
        public virtual UserRegisterType RegisterType { get; set; }
        public virtual string Address { get; set; }
        public virtual string IP { get; set; }
        public virtual bool IsBaned { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Product> LikedProducts { get; set; }
        public virtual ICollection<Comment> LikedComments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual byte[] RowVersion { get; set; }

    }

}
