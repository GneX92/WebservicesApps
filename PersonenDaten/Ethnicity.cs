using System.Text.Json.Serialization;

namespace PersonenDaten;

public class Ethnicity
{
    private double _prob;

    [JsonPropertyName( "country_id" )]
    public string? Country { get; set; }

    [JsonPropertyName( "probability" )]
    public double Probability
    { get { return _prob; } set { _prob = value * 100; } }
}