﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAWProject.Models.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
