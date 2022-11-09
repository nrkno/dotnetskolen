module Tests

open System
open Xunit
open NRK.Dotnetskolen.Domain

[<Theory>]
[<InlineData("abc12")>]
[<InlineData(".,-:!")>]
[<InlineData("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ")>]
let ``isTittelValid valid tittel returns true`` (tittel: string) =
    let isTittelValid = isTittelValid tittel

    Assert.True isTittelValid

[<Theory>]
[<InlineData("abcd")>]
[<InlineData("@$%&/")>]
[<InlineData("abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghija")>]
let ``isTittelValid invalid tittel returns false`` (tittel: string) =
    let isTittelValid = isTittelValid tittel

    Assert.False isTittelValid

[<Theory>]
[<InlineData("NRK1")>]
[<InlineData("NRK2")>]
let ``isKanalValid valid kanal returns true`` (kanal: string) =
    let isKanalValid = isKanalValid kanal

    Assert.True isKanalValid

[<Theory>]
[<InlineData("nrk1")>]
[<InlineData("NRK3")>]
let ``isKanalValid invalid kanal returns false`` (kanal: string) =
    let isKanalValid = isKanalValid kanal

    Assert.False isKanalValid

[<Fact>]
let ``areStartAndSluttidspunktValid start before end returns true`` () =
    let starttidspunkt = DateTimeOffset.Now
    let sluttidspunkt = starttidspunkt.AddMinutes 30.

    let areStartAndSluttidspunktValid = areStartAndSluttidspunktValid starttidspunkt sluttidspunkt

    Assert.True areStartAndSluttidspunktValid

[<Fact>]
let ``areStartAndSluttidspunktValids start after end returns false`` () =
    let starttidspunkt = DateTimeOffset.Now
    let sluttidspunkt = starttidspunkt.AddMinutes -30.

    let areStartAndSluttidspunktValid = areStartAndSluttidspunktValid starttidspunkt sluttidspunkt

    Assert.False areStartAndSluttidspunktValid

[<Fact>]
let ``areStartAndSluttidspunktValid start equals end returns false`` () =
    let starttidspunkt = DateTimeOffset.Now
    let sluttidspunkt = starttidspunkt

    let areStartAndSluttidspunktValid = areStartAndSluttidspunktValid starttidspunkt sluttidspunkt

    Assert.False areStartAndSluttidspunktValid

[<Fact>]
let ``Sending.create valid sending returns Some`` () =
    let now = DateTimeOffset.Now
    let sending = Sending.create "Dagsrevyen" "NRK1" now (now.AddMinutes 30.)

    match sending with
    | Some t ->
        Assert.Equal("Dagsrevyen", Tittel.value t.Tittel)
        Assert.Equal("NRK1", Kanal.value t.Kanal)
        Assert.Equal(now, Sendetidspunkt.starttidspunkt t.Sendetidspunkt)
        Assert.Equal(now.AddMinutes 30., Sendetidspunkt.sluttidspunkt t.Sendetidspunkt)
    | None -> Assert.True false

[<Fact>]
let ``Sending.create invalid sending returns None`` () =
    let now = DateTimeOffset.Now
    let sending = Sending.create "@$%&/" "nrk3" now (now.AddMinutes 30.)

    Assert.True sending.IsNone