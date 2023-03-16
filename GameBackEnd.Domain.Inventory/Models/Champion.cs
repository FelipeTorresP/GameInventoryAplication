using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd.Domain.Inventory.Models
{
    public class Champion
    {
#pragma warning disable CS8618 // Non-nullable property 'Id' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Id { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Id' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Description { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Attributes' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public ChampionAttributes Attributes { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Attributes' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public int Stats { get; set; }
        public int Level { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'UserId' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string UserId { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'UserId' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.


    }
}
