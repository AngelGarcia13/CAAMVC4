namespace SimpleAuthMember.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class route
    {
        public route()
        {
            webpages_Roles = new HashSet<webpages_Roles>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Action { get; set; }

        [StringLength(200)]
        public string Controller { get; set; }

        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
