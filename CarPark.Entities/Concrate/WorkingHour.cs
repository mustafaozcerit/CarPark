﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrate
{
   public class WorkingHour
    {
        public ICollection<Translation> Translation { get; set; }
    }
}
