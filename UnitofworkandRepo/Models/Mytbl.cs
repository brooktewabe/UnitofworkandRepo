using System;
using System.Collections.Generic;

namespace UnitofworkandRepo.Models;

public partial class Mytbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Greet { get; set; } = null!;
}
