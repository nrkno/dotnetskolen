# 💡 Tips og triks

- Flere har meldt om at de har slitt med at IDE-ene deres viser kompileringsfeil i editoren etter de har lagt til nye avhengigheter eller opprettet nye moduler. Dersom prosjektet bygger vellykket, enten ved hjelp av IDE-en sin innebygde byggfunksjon eller ved å kjøre `dotnet build`, men slike feil fortsatt vises i editoren, kan det hjelpe å laste løsningen på nytt:
  - Rider - høyreklikk på "Solution"-noden (`Dotnetskolen`), og velg `Reload projects`
  - Visual Studio - høyreklikk på det aktuelle prosjektet, velg `Unload project`. Høyreklikk på det aktuelle prosjektet på nytt, og velg `Reload project`.
  - Visual Studio Code - lukke editoren, kjøre `dotnet clean` etterfulgt av `dotnet build` fra terminalen, og åpne programmet på nytt
