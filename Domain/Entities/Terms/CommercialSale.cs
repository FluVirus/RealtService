﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Terms;

public class CommercialSale: CommercialTerm
{
    public decimal Price { get; set; }
}
