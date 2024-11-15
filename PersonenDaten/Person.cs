using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonenDaten;

public class Person
{
    private double _prob;

    [JsonPropertyName( "name" )]
    public string? Vorname { get; set; }

    [JsonPropertyName( "age" )]
    public int Age { get; set; }

    [JsonPropertyName( "gender" )]
    public string? Gender { get; set; }

    [JsonPropertyName( "probability" )]
    public double GenderProbability
    { get { return _prob; } set { _prob = value * 100; } }

    [JsonPropertyName( "country" )]
    public List<Ethnicity>? Country { get; set; }

    public override string ToString()
    {
        return $"Geschätztes Alter: {Age}\n" +
               $"Geschlecht: {Gender} mit {GenderProbability}% Wahrscheinlichkeit\n" +
               $"Ethnicity: {Country? [ 0 ].Country} mit {Country? [ 0 ].Probability}% Wahrscheinlichkeit";
    }
}