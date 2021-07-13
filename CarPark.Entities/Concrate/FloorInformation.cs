﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrate
{
   public class FloorInformation
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int Number { get; set; }
        public ICollection<SlotInformation> Slots { get; set; }
    }
}