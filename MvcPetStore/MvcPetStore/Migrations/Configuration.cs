namespace MvcPetStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MvcPetStore.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcPetStore.Models.PetStoreDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcPetStore.Models.PetStoreDBContext context)
            {
            context.Pets.AddOrUpdate(i => i.PetType,
                new Pet
                {
                    PetType = "Dog",
                    Breed = "Siberian Husky",
                    Gender = "F",
                    Description = "The Siberian Husky has an affectionate, gentle, and friendly disposition. They are alert and eager to please. They are highly intelligent and have an independent spirit, which can sometimes be a challenge to their owner. This versatile breed gets along very well with children and other medium sized dogs.",
                    Location = "Louisville, Kentucky",
                    Price = 799.00M,
                }
                );
        }
    }
}
