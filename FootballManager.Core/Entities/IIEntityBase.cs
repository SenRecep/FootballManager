﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Core.Entities
{
    public interface IEntityBase
    {
        int id { get; set; }

        DateTime CreateDate { get; set; }
        int CreateUserid { get; set; }

        DateTime? UpdateDate { get; set; }
        int? UpdateUserid { get; set; }

        bool IsActive { get; set; }
    }
}
