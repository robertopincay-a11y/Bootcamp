using System;
using System.Collections.Generic;

namespace AdventureWorks.Domain.Database.SqlServer.Entities;

public partial class Cantidad
{
    public int? ProductCategoryId { get; set; }

    public int? Cantidad1 { get; set; }
}
