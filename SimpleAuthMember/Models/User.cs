namespace SimpleAuthMember.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public User()
        {
            webpages_Roles = new HashSet<webpages_Roles>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(150)]
        public string DisplayName { get; set; }

        [StringLength(150)]
        public string Country { get; set; }

        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
