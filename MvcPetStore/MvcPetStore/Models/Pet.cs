using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcPetStore.Models
{
    public class Pet
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string PetType { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Breed { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(1, MinimumLength = 1)]
        public string Gender { get; set; }


        [StringLength(300)]
        public string Description { get; set; }


        [StringLength(50)]
        public string Location { get; set; }


        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
    public class PetStoreDBContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
    }
}