﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrate
{
    public class Reservation
    {
        [BsonId]
        public ObjectId MyProperty { get; set; }
        public string ImagePath { get; set; }
        public string Plate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsExit { get; set; }
        public bool IsPayment { get; set; }
        public ReservationDetail ReservationDetail { get; set; }

    }
}