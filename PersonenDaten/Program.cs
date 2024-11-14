using PersonenDaten;
using System.Net.Http.Json;

HttpClient client = new();
Person? p = new();

Console.Write( "Vorname: " );

string? vorname = Console.ReadLine();
vorname = vorname?.Trim();

try
{
    p = await client.GetFromJsonAsync<Person>( "https://api.nationalize.io?name=" + vorname );
    p = await client.GetFromJsonAsync<Person>( "https://api.genderize.io?name=" + vorname );
    p = await client.GetFromJsonAsync<Person>( "https://api.agify.io?name=" + vorname );
}
catch ( AggregateException ex )
{
    foreach ( var item in ex.InnerExceptions )
        Console.WriteLine( item.Message );
}

Console.WriteLine( p );

Console.ReadLine();

/*
 * API Links
 * https://api.nationalize.io?name=
 * https://api.genderize.io?name=
 * https://api.agify.io?name=
*/