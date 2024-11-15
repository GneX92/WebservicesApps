using PersonenDaten;
using System.Net.Http.Json;

HttpClient client = new();
Person? p = new();
Person? p2 = new();
Person? p3 = new();

Console.Write( "Vorname: " );

string? vorname = Console.ReadLine();
vorname = vorname?.Trim();

try
{
    p = await client.GetFromJsonAsync<Person>( "https://api.nationalize.io?name=" + vorname );
    p2 = await client.GetFromJsonAsync<Person>( "https://api.genderize.io?name=" + vorname );
    p3 = await client.GetFromJsonAsync<Person>( "https://api.agify.io?name=" + vorname );
}
catch ( AggregateException ex )
{
    foreach ( var item in ex.InnerExceptions )
        Console.WriteLine( item.Message );
}

Console.WriteLine( "Geschätztes Alter: " + p3.Age );
Console.WriteLine( "Geschätztes Geschlecht: " + p2?.Gender + $" mit {p2?.GenderProbability}% Wahrscheinlichkeit" );
Console.WriteLine( "Geschätzte Ethnicity: " + p?.Country? [ 0 ].Country + $" mit {p?.Country? [ 0 ].Probability:F1}% Wahrscheinlichkeit" );

Console.ReadLine();

/*
 * API Links
 * https://api.nationalize.io?name=
 * https://api.genderize.io?name=
 * https://api.agify.io?name=
*/