﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function.WeatherNotification.Models
{
    public class SmsModel
    {
        public string PhoneNumber { get; set; }

        public string MessageBody { get; set; }
    }
}
