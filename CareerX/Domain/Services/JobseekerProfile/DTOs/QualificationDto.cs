﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Jobseeker.DTOs
{
    public class QualificationDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
