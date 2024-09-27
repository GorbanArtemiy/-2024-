using System;

namespace Play.Catalog.Service.Entities
{
    public class Pet
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Breed { get; set; }

        public string Habitat { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset AddedDate { get; set; }

    }
}