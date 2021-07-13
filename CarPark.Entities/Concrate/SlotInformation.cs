using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrate
{
   public class SlotInformation
    {
        [BsonId]
        public ObjectId MyProperty { get; set; }
        public ICollection<Translation> Translation { get; set; }
    }
}
