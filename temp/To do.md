# To do

- ~~kanskje i innledende presentasjon si noe om oppsettet, hvordan filstrukturen kommer til å bli og hva som skal være på de ulike stedene , forklare om domenet~~
- ~~ hva er et prosjekt ~~
- ~~si noe om språket f#. lede til en f# cheat sheet/guide noe sted~~
- ~~avsnitt Se løsningsforslag - man tror kanskje at man nå har gjort steg 1, kanskje flytte til etter steg 1? ~~
- ~~ si noe om forskjellen på enhetstester og integrasjonstester? ~~
- ~~ Test.fs er første fila man ser, bør man si noe om koden inni? ikke gitt at man ser at det er en test som er inni kanskje? ~~
- ~~ git - lagre og commit - kanskje si noe om commit /add hva man skal gjøre? ~~
- ~~ tipse om å commite etter hvert steg? ~~
- ~~ steg 5: kanksje man kunne printe ut en verdi av type Sending fra domenet i program.fs så man ser at man har laget noe? ~~
- steg 6
  - ~~ funksjoner skal være pascalCase så feks liten i i IsTitleValid? ~~
  - ~~ Endre implementasjon av IsDateValid til å være funksjonell ~~
  - ~~ under sendetidspunkt så er det et avsnitt om at man må legge til System, men den tror jeg kom med da vi lagde prosjektene? ~~
- ~~ man trenger noe sertifikatgreier satt opp for at https://localhost:5001/ping skal funke? eller jeg får ihvertfall advarsler om at det ikke er gyldig sertifikat http://localhost:5000 funker da. (mulig rider og kanskje visual studio også setter opp noe greier automagisk?, jeg bruker vscode) ~~
- ~~ i kodeeksempelet for httpHandlers så tror jeg module NRK.Dotnetskolen.Api.HttpHandlers  bare skal være HttpHandlers? ~~
- ~~ Fikse navn på tester til å være uten understrek ~~
- ~~ Skrive om integrasjonstester til å være funksjonelle ~~
- Oppdatere veiledningen for steg 10 nå som testene er funksjonelle
- Skrive om option og pattern matching i steg 10
- skrive to ord om >=> ?

```txt
si noe om språket f#. lede til en f# cheat sheet/guide noe sted

git - lagre og commit - kanskje si noe om commit /add hva man skal gjøre?

avsnitt Se løsningsforslag - man tror kanskje at man nå har gjort steg 1,kanskje flytte til etter steg 1?

tipse om å commite etter hvert steg?

Test.fs er første fila man ser, bør man si noe om koden inni? ikke gitt at man ser at det er en test som er inni kanskje?

si noe om forskjellen på enhetstester og integrasjonstester? 

(kanskje i innledende presentasjon si noe om oppsettet, hvordan filstrukturen kommer til å bli og hva som skal være på de ulike stedene. hva er et prosjekt, forklare om domenet)

steg 5: kanksje man kunne printe ut en verdi av type Sending fra domenet i program.fs så man ser at man har laget noe?

UTGÅR
Domain.fs: kanskje like enkelt å skrive module NRK.Dotnetskolen.Domain  øverst i stedet for 
namespace NRK.Dotnetskolen
module Domain =
så slipper man innrykk?

steg 6
funksjoner skal være pascalCase så feks liten i i IsTitleValid?
under sendetidspunkt så er det et avsnitt om at man må legge til System, men den tror jeg kom med da vi lagde prosjektene?
```

```f#
module Tests
open System
open Xunit
open Microsoft.AspNetCore.Hosting
open NRK.Dotnetskolen.Api
open System.IO
open Microsoft.AspNetCore.TestHost
let createHost () =
    WebHostBuilder()
        .UseContentRoot(Directory.GetCurrentDirectory()) 
        .UseEnvironment("Test")
        .Configure(Program.configureApp)
        .ConfigureServices(Program.configureServices)
[<Fact>]
let getEpg_Today_Returns200OK () =
    use server = new TestServer(createHost()) 
    use client = server.CreateClient()
    let todayAsString = DateTimeOffset.Now.ToString "yyyy-MM-dd"
    let url = sprintf "/epg/%s" todayAsString
    let response = client.GetAsync(url) |> Async.AwaitTask |> Async.RunSynchronously
    response.EnsureSuccessStatusCode() |> ignore
```

```txt
skrive to ord om >=> ?

man trenger noe sertifikatgreier satt opp for at https://localhost:5001/ping skal funke? eller jeg får ihvertfall advarsler om at det ikke er gyldig sertifikat http://localhost:5000 funker da. (mulig rider og kanskje visual studio også setter opp noe greier automagisk?, jeg bruker vscode)

i kodeeksempelet for httpHandlers så tror jeg module NRK.Dotnetskolen.Api.HttpHandlers  bare skal være HttpHandlers?

jeg ville prøvd å unngå mutable date og byref verider, kanskje bruke option?
let isDateValid (dateAsString : string) : Option<DateTime> =
	let isValid, date = DateTime.TryParseExact(dateAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None)
	if isValid then Some date else None
let epgHandler (dateAsString : string) : HttpHandler =
	fun (next : HttpFunc) (ctx : HttpContext) ->
		match isDateValid dateAsString with
		| Some date -> (text dateAsString) next ctx
		| None -> RequestErrors.badRequest (text "Invalid date") (Some >> Task.FromResult) ctx
```

```f#
let isDateValid (dateAsString : string) : Option<DateTime> =
	let isValid, date = DateTime.TryParseExact(dateAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None)
	if isValid then Some date else None
let epgHandler (dateAsString : string) : HttpHandler =
	fun (next : HttpFunc) (ctx : HttpContext) ->
		match isDateValid dateAsString with
		| Some date -> (text dateAsString) next ctx
		| None -> RequestErrors.badRequest (text "Invalid date") (Some >> Task.FromResult) ctx
```
