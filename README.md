# Dotnetskolen

Velkommen til Dotnetskolen!

Dette er en workshop hvor du blir tatt gjennom prosessen av å sette opp et .NET-prosjekt fra bunnen av, steg for steg. Målet er å vise hvordan man kan utføre oppgaver som er vanlige i etableringsfasen av et system, som:

- Opprette prosjekter og mappestruktur
- Sette opp pakkehåndtering
- Sette opp tester
- Sette opp bygg og deploy

Som et eksempel på en applikasjon skal vi lage et web-API med tilhørende enhets- og integrasjonstester.

For å unngå å være spesifikk for en gitt IDE eller plattform bruker workshopen .NET CLI som er et kommandolinjeverktøy som gir deg muligheten til å utvikle, bygge, kjøre og publisere .NET-applikasjoner. 

Du kan lese mer om .NET CLI her: [https://docs.microsoft.com/en-us/dotnet/core/tools/](https://docs.microsoft.com/en-us/dotnet/core/tools/)

For å komme i gang kan du lese [forutsetningene](#Forutsetninger) under, og utføre [steg 0](#steg-0---last-ned-koden).

## Forutsetninger

Det forutsettes at du har noen verktøy installert på maskinen din for å kunne gjennomføre stegene i workshopen. Verktøyene er oppsummert i listen under, og du finner et lite avsnitt om hvordan du kan installere hver av dem i de følgende seksjonene.

- [Git](#Git)
- [GitHub-bruker](#GitHub-bruker)
- [.NET SDK](#NET-SDK)
- [En IDE](#IDE)
  - [Rider](https://www.jetbrains.com/rider/download)
  - [Visual Studio](https://visualstudio.microsoft.com/vs/community)
  - [Visual Studio Code](https://code.visualstudio.com/download)

### Git

For å klone dette repoet til din egen maskin trenger du Git installert. Git er også nyttig for å f.eks. kunne se andre versjoner av dette repoet, og lage din egen branch.

Git kan lastes ned for alle plattformer her: [https://git-scm.com/downloads](https://git-scm.com/downloads).

### GitHub-bruker

Du er også avhengig av å ha en bruker på GitHub for å kunne laste ned dette repoet. Dersom du ikke har bruker på GitHub kan du følge denne guiden på Confluence: [https://confluence.nrk.no/display/PLAT/Tilgang+til+Github](https://confluence.nrk.no/display/PLAT/Tilgang+til+Github)

### .NET SDK

Ettersom du skal kjøre .NET-applikasjoner og bruke .NET CLI for å opprette prosjektene som inngår i løsningen trenger du .NET SDK installert på maskinen din. Workshopen er laget med .NET 5, men de fleste kommandoene fungerer nok med lavere versjoner av .NET også. Du kan undersøke hvilken versjon av .NET du har lokalt (om noen i det hele tatt) ved å kjøre følgende kommando

``` bash
$ dotnet --version

5.0.103
```

Dersom du ikke har .NET installert på maskinen din, kan du laste det ned her: [https://dotnet.microsoft.com/download/dotnet/5.0](https://dotnet.microsoft.com/download/dotnet/5.0)

### IDE

For å få syntax highlighting, autocomplete, og kodenaviering er det kjekt å ha en IDE. De mest brukte IDE-ene for .NET er oppsummert i tabellen under.

| Navn | Plattform | Lisens | Download |
| - | - | - | - |
| Rider | Kryssplattform | Gratis i 30 dager. Deretter kreves lisens. | [https://www.jetbrains.com/rider/download](https://www.jetbrains.com/rider/download) |
| Visual Studio|Windows | Community-versjon er gratis. Øvrige versjoner krever lisens. |[https://visualstudio.microsoft.com/vs/community](https://visualstudio.microsoft.com/vs/community)|
| Visual Studio Code | Kryssplattform | Gratis | [https://code.visualstudio.com/download](https://code.visualstudio.com/download) |

Velg den IDE-en som passer dine behov.

> Merk at et vanlig use case for IDE-er er at de også blir brukt til å kompilere og kjøre kode. Denne workshopen kommer imidlertid til å benytte .NET CLI til dette.

## Steg 0 - Gjøre klart for koding

### Klone repo

Klon dette repoet med følgende kommando

``` bash
$ git clone git@github.com:nrkno/dotnetskolen.git # Last ned repo fra GitHub til din maskin

Cloning into 'dotnetskolen'...
remote: Enumerating objects: 9, done.
remote: Counting objects: 100% (9/9), done.
remote: Compressing objects: 100% (5/5), done.
remote: Total 9 (delta 2), reused 4 (delta 1), pack-reused 0
Receiving objects: 100% (9/9), done.
Resolving deltas: 100% (2/2), done.
```

Da skal nå ha `main`-branchen sjekket ut lokalt på din maskin. Det kan du verifisere ved å kjøre følgende kommandoer

``` bash
$ cd dotnetskolen # Gå inn i mappen som repoet ligger i lokalt
$ git branch # List ut alle brancher du har sjekket ut lokalt

* main
```

### Sjekke ut egen branch

Før du begynner å kode kan du gjerne lage din egen branch med `git checkout -b <branchnavn>`. På denne måten kan du holde dine endringer adskilt fra koden som ligger i repoet fra før.

``` bash
$ git checkout -b my-branch

Switched to a new branch 'my-branch'
```

### Sette opp .gitignore

Vanligvis er det en del filer man ikke ønsker å ha inkludert i Git. Dette er noe man fort merker ved etablering av et nytt system. For å fortelle Git hvilke filer man vil ignorere, oppretter man en `.gitignore`-fil i roten av repoet. GitHub har et eget repo som inneholder `.gitignore`-filer for ulike typer prosjekter: [https://github.com/github/gitignore](https://github.com/github/gitignore). `.gitignore`-filene GitHub har utarbeidet inneholder de vanligste filene man ønsker å ignorere. Ettersom denne workshopen gjelder .NET kan vi bruke `VisualStudio.gitignore` fra repoet deres.

Opprett `.gitignore` i roten av repoet, og lim inn innholdet i denne filen: [https://github.com/github/gitignore/blob/master/VisualStudio.gitignore](https://github.com/github/gitignore/blob/master/VisualStudio.gitignore)

## Se "fasit"

Dersom du ønsker å se hvordan det er forventet at tilstanden til repoet ser ut etter å ha utført de ulike stegene i workshopen, kan du sjekke ut branchen med korresponderende navn som seksjonen du ønsker å se på. F.eks. hvis du vil se hvordan repoet ser ut etter "Steg 1 - Opprette API", kan du sjekke ut branchen `step-1` slik:

``` bash
$ git checkout step-1

Switched to branch 'step-1'
```
