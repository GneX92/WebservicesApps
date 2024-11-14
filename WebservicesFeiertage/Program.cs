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

int inputYear;

while ( true )
{
    Console.Clear();
    Console.Write( "Jahr: " );
    inputYear = int.Parse( Console.ReadLine() );

    if ( inputYear > DateTime.Now.Year + 2 || inputYear < DateTime.Now.Year )
    {
        Console.WriteLine( $"Ungültiges Jahr. Bitte Jahr von {DateTime.Now.Year} - {DateTime.Now.Year + 2} auswählen" );
        Console.ReadLine();
        continue;
    }

    break;
}

int inputState;

while ( true )
{
    Console.Clear();

    foreach ( var state in stateSet )
        Console.WriteLine( $"<{state.Item1}> {state.Item3}" );

    Console.Write( "\nBundesland(Nr): " );
    inputState = int.Parse( Console.ReadLine() );

    if ( inputState < 1 || inputState > 16 )
    {
        Console.WriteLine( $"Ungültiges Bundesland. Bitte gültiges Bundesland angeben" );
        Console.ReadLine();
        continue;
    }

    break;
}

HttpClient client = new();

var stateTag = stateSet.Where( x => x.Item1 == inputState );

string stateString = "";

foreach ( var item in stateTag )
    stateString += item.Item2;

RootObject? root = await client.GetFromJsonAsync<RootObject>
( "https://get.api-feiertage.de?years=" + inputYear + "&states=" + stateString.ToLower() );

Console.Clear();

foreach ( var item in root.Feiertage )
    Console.WriteLine( item.Fname + " " + item.Date );

Console.ReadLine();