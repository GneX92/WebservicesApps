using System.Net.Http.Json;
using WebservicesFeiertage;

List<(int, string, string)> stateSet = new()
{
    (1, "BW", "Baden - Württemberg"),
    (2, "BY", "Bayern"),
    (3, "BE", "Berlin"),
    (4, "BB", "Brandenburg"),
    (5, "HB", "Bremen"),
    (6, "HH", "Hamburg"),
    (7, "HE", "Hessen"),
    (8, "MV", "Mecklenburg - Vorpommern"),
    (9, "NI", "Niedersachsen"),
    (10, "NW", "Nordrhein - Westfalen"),
    (11, "RP", "Rheinland - Pfalz"),
    (12, "SL", "Saarland"),
    (13, "SN", "Sachsen"),
    (14, "ST", "Sachsen - Anhalt"),
    (15, "SH", "Schleswig - Holstein"),
    (16, "TH", "Thüringen")
};

Console.Write( "Jahr: " );
int inputYear = int.Parse( Console.ReadLine() );

foreach ( var state in stateSet )
    Console.WriteLine( $"<{state.Item1}> {state.Item3}" );

Console.Write( "\nBundesland(Nr): " );
int inputState = int.Parse( Console.ReadLine() );

HttpClient client = new();

RootObject? root = await client.GetFromJsonAsync<RootObject>
( "https://get.api-feiertage.de?years=" + inputYear + "&states=" + stateSet.Where( x => x.Item1 == inputYear ).Select( p => p.Item2.ToLower() ) );

foreach ( var item in root.Feiertage )
    Console.WriteLine( item.Fname + " " + item.Date );

Console.ReadLine();