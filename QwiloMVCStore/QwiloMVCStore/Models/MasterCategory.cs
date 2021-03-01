namespace QwiloMVCStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterCategory")]
    public partial class MasterCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CategoryID { get; set; }

        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }

        public int Parent { get; set; }
    }
}
