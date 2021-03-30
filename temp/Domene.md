# Domene

## Idémyldring

- Finne på domene/bruksområde
  - Trenger ikke være stort. Poenget med kurset er å illustrere oppsett, og kan ikke inneholde alle tenkelige scenarier.
  - Hold det helt enkelt. Det minste som er nødvendig for å illustrere hovedkonseptene ved oppsett av et prosjekt.
  - Kan utvide senere med avanserte caser som database, blob, service bus
  - Ikke fokusér på at det skal følge DDD til punkt og prikke. Det er et helt eget tema.
  - Trenger et domene hvor man har _noe_ domenelogikk slik at vi kan skrive enhetstester.
  - Eksponér GET-operasjoner i webapi, og skriv integrasjonstester
- Sette opp webapi fra bunnen
  - Host
    - Bruk Startup for å enklere kunne skrive integrasjonstester for webapi
  - Configure app
    - Giraffe
  - Configure services
    - Avhengigheter
      - Database, blob, service bus etc.
      - Ikke sikkert vi får dette i domenet i kurset
  - Logging
- Skrive enhetstester
  - Tester for domenelogikk
- Skrive integrasjonstester
  - Vurder å skrive integrasjonstester for webapi: [https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0)

## Domene

- EPG
  - Må være veldig forenklet med disclaimer om at det er kokt ned, og at det ikke gjenspeiler faktisk domenemodell eller - logikk
  - GET /epg - alle kanaler, alle dager
  - GET /epg?dato=2021-03-29 - alle kanaler, gitt dag
  - GET /epg/<kanal> - gitt kanal, alle dager
  - GET /epg/kanal?dato=2021-03-29 - gitt kanal, gitt dag
  - Domenelogikk?
    - Kun programmer med kanal, start- og sluttidspunkt blir inkludert i EPG
    - Kun programmer innenfor gjeldende sendeskjemavindu blir inkludert
  - Hva skal komme først?
    - Domenemodell?
    - Enhetstester for domenelogikk?
    - Oppsett av apiprosjekt?
      - Kan sette opp skall i alle fall
        - Host
          - Startup
            - ConfigureApp og ConfigureServices
    - Skall for integrasjonstester?
      - Definere endepunktene våre
        - Kommer til å feile
    - Lage endepunkt for gitt kanal på gitt dag først. Ev. utvid med andre endepunkter senere.
