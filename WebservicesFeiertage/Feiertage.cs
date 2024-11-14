using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebservicesFeiertage;

public class RootObject
{
    public string? Status { get; set; }
    public List<Feiertage> Feiertage { get; set; }
}

public class Feiertage
{
    public string? Date { get; set; }
    public string? Fname { get; set; }
}