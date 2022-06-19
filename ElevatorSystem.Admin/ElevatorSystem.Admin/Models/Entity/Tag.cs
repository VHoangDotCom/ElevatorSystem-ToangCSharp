using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElevatorSystem.Admin.Models.Entity
{
    public class Tag
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter Title !")]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
       /* [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM-dd-yyyy}")]*/
        [DataType(DataType.Date)]
        public Nullable<DateTime> CreatedAt { get; set; }

       /* [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM-dd-yyyy}")]*/
        [DataType(DataType.Date)]
        public Nullable<DateTime> ModifiedAt { get; set; }

        /*[DatabaseGenerated(DatabaseGeneratedOption.Computed)]*/
      /*  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM-dd-yyyy}")]*/
        [DataType(DataType.Date)]
       /* [Column(TypeName = "datetime2")]*/
        public Nullable<DateTime> PublishedAt { get; set; }

        public ICollection<Blog> Blogs { get; set; }
        public Tag()
        {
            this.Title = "";
            this.Description = "";
            this.IsPublished = true;
            this.CreatedAt = DateTime.Now;

            this.Blogs = new HashSet<Blog>();
        }
    }
}