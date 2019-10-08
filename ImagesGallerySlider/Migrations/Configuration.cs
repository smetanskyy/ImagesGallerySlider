namespace ImagesGallerySlider.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ImagesGallerySlider.Entities.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ImagesGallerySlider.Entities.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            #region Seed Categories
            context.Categories.AddOrUpdate(c => c.IdCategory,
                new Entities.Category
                {
                    IdCategory = 1,
                    NameOfCategory = "Pets"
                });

            context.Categories.AddOrUpdate(c => c.IdCategory,
                new Entities.Category
                {
                    IdCategory = 2,
                    NameOfCategory = "Nature"
                });
            #endregion

            #region Seed Photos
            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 1,
                    FileName = "dog1.jpg",
                    Сaption = "Dog1",
                    IdCategory = 1
                });
            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 2,
                    FileName = "dog2.jpg",
                    Сaption = "Dog2",
                    IdCategory = 1
                });
            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 3,
                    FileName = "dog3.jpg",
                    Сaption = "Dog3",
                    IdCategory = 1
                });

            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 4,
                    FileName = "cat1.jpg",
                    Сaption = "Cat1",
                    IdCategory = 1
                });
            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 5,
                    FileName = "cat2.jpg",
                    Сaption = "Cat2",
                    IdCategory = 1
                });
            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 6,
                    FileName = "cat3.jpg",
                    Сaption = "Cat3",
                    IdCategory = 1
                });

            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 7,
                    FileName = "nature1.jpg",
                    Сaption = "Nature1",
                    IdCategory = 2
                });
            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 8,
                    FileName = "nature2.jpg",
                    Сaption = "Nature2",
                    IdCategory = 2
                });
            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 9,
                    FileName = "nature3.jpg",
                    Сaption = "Nature3",
                    IdCategory = 2
                });
            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 10,
                    FileName = "nature4.jpg",
                    Сaption = "Nature4",
                    IdCategory = 2
                });
            context.Photos.AddOrUpdate(c => c.Id,
                new Entities.Photo
                {
                    Id = 11,
                    FileName = "nature5.jpg",
                    Сaption = "Nature5",
                    IdCategory = 2
                });
            #endregion
        }
    }
}
