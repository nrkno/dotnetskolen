# Detaljer om oppsett på maskinen din

Dette kurset forutsetter at du har noen verktøy installert på maskinen din. Se gjennom listen under for å sørge for at du har det som trengs.

> Å installere og bruke Git er valgfritt, men er kjekt å ha dersom du ønsker å ha veiledningen, og [løsningsforslag](#se-løsningsforslag), lokalt på maskinen din.

## Verktøy

For å gjennomføre kurset må du ha satt opp følgende:

- [Git (valgfritt)](#Git)
- [.NET SDK](#NET-SDK)
- [Konfigurasjon av NuGet (kun for Windows)](#konfigurere-nuget-kun-for-windows)
- [En IDE](#IDE)
  - [Rider](https://www.jetbrains.com/rider/download)
  - [Visual Studio](https://visualstudio.microsoft.com/vs/community)
  - [Visual Studio Code](https://code.visualstudio.com/download)

### Git

Git er et gratis versjonshåndteringssystem som finnes til alle plattformer. Dersom du ønsker å ha instruksjonene til kurset (dokumentet du leser nå), eller se forventet resultat etter å ha gjennomført hvert av de ulike stegene, på din egen maskin trenger du Git installert. Med Git kan du også lage din egen versjon av dette repoet slik som forklart [her](#sjekke-ut-egen-branch).

Du kan laste ned Git her: [https://git-scm.com/downloads](https://git-scm.com/downloads).

Dersom Git er nytt for deg kan det være nyttig å lese denne artikkelen om hvordan man jobber med endringer i et Git-repo: [https://git-scm.com/book/en/v2/Git-Basics-Recording-Changes-to-the-Repository](https://git-scm.com/book/en/v2/Git-Basics-Recording-Changes-to-the-Repository). Det er forøvrig instruksjoner på [slutten av første steg](#lagre-endringer-i-git-valgfritt) for hvordan du kan lagre endringer du gjør underveis i kurset i Git.

### .NET SDK

Når man installerer .NET har man valget mellom å installere

- .NET runtime - kjøretidsmiljø for .NET-applikasjoner
- .NET SDK - inneholder alt man trenger for å utvikle og kjøre .NET-applikasjoner lokalt, og inkluderer
  - .NET runtime og basebiblioteker (BCL)
  - Kompilatorer
  - .NET CLI - kommandolinjeverktøy for å bygge, kjøre og publisere .NET-applikasjoner

Ettersom du gjennom kurset skal utvikle og kjøre .NET-applikasjoner trenger du .NET SDK installert på maskinen din. Kurset er laget med .NET 6, men de fleste kommandoene fungerer nok med en versjon av .NET Core, og vil trolig være tilgjengelig i fremtidige versjoner også. Du kan undersøke hvilken versjon av .NET du har lokalt (om noen i det hele tatt) ved å kjøre følgende kommando

```bash
$ dotnet --version

6.0.101
```

Dersom du ikke har .NET installert på maskinen din, kan du laste det ned her: [https://dotnet.microsoft.com/download/dotnet](https://dotnet.microsoft.com/download/dotnet)

Som nevnt over inkluderer .NET SDK også .NET CLI som gir oss muligheten til å bygge, kjøre og publisere .NET-applikasjoner. Etter å ha installert .NET CLI kan man kjøre `dotnet`-kommandoer i terminalen. For at kurset skal kunne gjennomføres uavhengig av plattform og IDE skal vi bruke .NET CLI til oppsett av løsningen vår.

Veiledningen forklarer det grunnleggende om kommandoene vi kommer til å bruke i .NET CLI. Dersom du ønsker mer utfyllende informasjon eller oversikt over alle kommandoene kan du lese mer om .NET CLI her: [https://docs.microsoft.com/en-us/dotnet/core/tools/](https://docs.microsoft.com/en-us/dotnet/core/tools/)

### Konfigurere NuGet (kun for Windows)

Som vi skal se nøyere på i [steg 4](#steg-4---pakkehåndtering) bruker man "NuGet"-pakker for å dele kode mellom .NET-prosjekter. NuGet har en offentlig repo med pakker som er tilgjengelig på [https://www.nuget.org/](https://www.nuget.org/). Dersom du ikke har brukt NuGet på Windows-maskinen din før kan det være at du må instruere NuGet til å hente pakker derfra.

Åpne filen `C:/Users/<ditt brukernavn>/AppData/Roaming/NuGet/NuGet.Config`, og lim inn følgende innhold:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
```

### IDE

For å kunne debugge kode, få syntax highlighting og visning av kompileringsfeil, autocomplete, og kodenavigering er det kjekt å ha en IDE. De mest brukte IDE-ene for .NET er oppsummert i tabellen under.

| Navn | Plattform | Lisens | Download |
| - | - | - | - |
| Visual Studio|Windows | Community-versjon er gratis. Øvrige versjoner krever lisens. |[https://visualstudio.microsoft.com/vs/community](https://visualstudio.microsoft.com/vs/community)|
| Visual Studio Code | Kryssplattform | Gratis | [https://code.visualstudio.com/download](https://code.visualstudio.com/download) |
| Rider | Kryssplattform | Gratis i 30 dager. Deretter kreves lisens. | [https://www.jetbrains.com/rider/download](https://www.jetbrains.com/rider/download) |

Velg den IDE-en som passer dine behov.

> Dersom du skal bruke Visual Studio Code, anbefales det å installere pluginen "Ionide".
>
> - Du kan laste ned Ionide her: [https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode)
> - Du kan lese mer om Ionide her: [https://ionide.io/](https://ionide.io/)

> Merk at et vanlig use case for IDE-er er at de også blir brukt til å kompilere og kjøre kode. Instruksjonene i kurset kommer imidlertid til å benytte .NET CLI til dette. Du står selvfølgelig fritt frem til å bygge og kjøre koden ved hjelp av din IDE hvis du ønsker det.

## Lokalt oppsett av koden (valgfritt)

### Klone repo

Dersom du ønsker dette repoet lokalt på din maskin, kan du gjøre det slik:

```bash
$ git clone git@github.com:nrkno/dotnetskolen.git # Last ned repo fra GitHub til din maskin

Cloning into 'dotnetskolen'...
remote: Enumerating objects: 9, done.
remote: Counting objects: 100% (9/9), done.
remote: Compressing objects: 100% (5/5), done.
remote: Total 9 (delta 2), reused 4 (delta 1), pack-reused 0
Receiving objects: 100% (9/9), done.
Resolving deltas: 100% (2/2), done.
```

> Kommandoen over forutsetter at man bruker SSH for autentisering overfor GitHub. For mer informasjon om SSH-autentisering i GitHub se <https://docs.github.com/en/authentication/connecting-to-github-with-ssh>
>
> Dersom man ønsker å klone med HTTPS istedenfor må man kjøre følgende kommando `https://github.com/nrkno/dotnetskolen.git` og oppgi brukernavn og passord.
>
> Ev. kan man bruke [GitHub sin desktopklient](https://desktop.github.com/)

Da skal nå ha `main`-branchen sjekket ut lokalt på din maskin. Det kan du verifisere ved å gå inn i mappen til repoet og liste ut branchene i Git:

```bash
$ cd dotnetskolen # Gå inn i mappen som repoet ligger i lokalt
$ git branch # List ut alle brancher du har sjekket ut lokalt

* main
```

### Sjekke ut egen branch

Før du begynner å kode kan du gjerne lage din egen branch med `git checkout -b <branchnavn>`. På denne måten kan du holde dine endringer adskilt fra koden som ligger i repoet fra før, og det er lettere for kursholder å hjelpe deg dersom du har behov for det.

```bash
$ git checkout -b my-branch

Switched to a new branch 'my-branch'
```

### Sette opp .gitignore

Vanligvis er det en del filer man ikke ønsker å ha inkludert i Git. Dette er noe man fort merker ved etablering av et nytt system. For å fortelle Git hvilke filer man vil ignorere, oppretter man en `.gitignore`-fil i roten av repoet.

GitHub har et eget repo som inneholder `.gitignore`-filer for ulike typer prosjekter: [https://github.com/github/gitignore](https://github.com/github/gitignore). `.gitignore`-filene GitHub har utarbeidet inneholder filtypene det er vanligst å utelate fra Git for de ulike prosjekttypene. Ettersom dette kurset omhandler .NET kan vi bruke `VisualStudio.gitignore` fra repoet deres.

For å sette opp `.gitignore` i ditt lokale repo:

1. Opprett en tekstfil med navn `.gitignore` i roten av repoet
2. Lim inn innholdet i denne filen: [https://github.com/github/gitignore/blob/master/VisualStudio.gitignore](https://github.com/github/gitignore/blob/master/VisualStudio.gitignore)
3. Lagre og commite `.gitignore`-filen.

#### Hvordan commite `.gitignore`

##### Se Git-status

For å vise status i Git, kjør følgende kommando:

```bash
$ git status

On branch my-branch

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        .gitignore

nothing added to commit but untracked files present (use "git add" to track)
```

Over ser vi at Git har oppdaget at `.gitignore` er en ny fil som Git ikke sporer.

##### Legg til .gitignore i Git

For å legge til `.gitignore` i Git slik at Git kan spore ev. endringer i den filen i fremtiden, kjør følgende kommando:

```bash
git add .gitignore
```

For å se status i Git igjen, kjør følgende kommando:

```bash
$ git status

On branch my-branch
Changes to be committed:
  (use "git restore --staged <file>..." to unstage)
        new file:   .gitignore
```

#### Commite i Git

For å lagre nåværende versjon av `.gitignore` i Git, kjør følgende kommando:

```bash
$ git commit -m "La til .gitignore"

[my-branch 478fb9b] La til .gitignore
 1 file changed, 1 insertion(+)
 create mode 100644 .gitignore
```

Nå er innholdet i `.gitignore` lagret i Git. Dersom du nå kjører `git status` på nytt, vil du se at det ikke er noen gjenstående endringer i repoet som Git ikke har fått med seg:

```bash
$ git status

On branch my-branch
nothing to commit, working tree clean
```
