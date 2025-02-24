# 📜 Details about setup on your computer

This course assumes that you have some tools installed on your computer. Please review the list below to make sure you have what you need.

> Installing and using Git is optional, but is nice to have if you want to have the guide, and [solution suggestions](https://github.com/nrkno/dotnetskolen/blob/main/README_EN.md#see-solution-suggestions), locally on your computer.

## 🛠️ Tools

To complete the course you must have set up the following:

- [.NET SDK](#NET-SDK)
- [Configuring NuGet (Windows only)](#configuring-nuget-windows-only)
- [An IDE](#IDE)
  - [Rider](https://www.jetbrains.com/rider/download)
  - [Visual Studio](https://visualstudio.microsoft.com/vs/community)
  - [Visual Studio Code](https://code.visualstudio.com/download)
- [Git (optional)](#Git)

### .NET SDK

When installing .NET you have the choice between installing

- .NET runtime - runtime environment for .NET applications
- .NET SDK - contains everything you need to develop and run .NET applications locally, and includes
  - .NET runtime and base libraries (BCL)
  - Compilers
  - .NET CLI - command line tool for building, running, and publishing .NET applications

As you will be developing and running .NET applications throughout the course, you will need the .NET SDK installed on your computer. The course is written in .NET 9, but most of the commands will probably work with an older version of .NET Core, and will likely be available in future versions as well. You can check which version of .NET you have locally (if any) by running the following command

```bash
dotnet --version
```

```bash
9.0.102
```

If you do not have .NET installed on your computer, you can download it here: [https://dotnet.microsoft.com/download/dotnet](https://dotnet.microsoft.com/download/dotnet)

As mentioned above, the .NET SDK also includes the .NET CLI, which gives us the ability to build, run, and publish .NET applications. After installing the .NET CLI, you can run `dotnet` commands in the terminal. In order for the course to work idenpenant of platform and IDE, we will use the .NET CLI to set up our solution.

The tutorial explains the basics of the commands we will use in the .NET CLI. If you would like more detailed information or an overview of all the commands, you can read more about the .NET CLI here: [https://docs.microsoft.com/en-us/dotnet/core/tools/](https://docs.microsoft.com/en-us/dotnet/core/tools/)

### Configuring NuGet (Windows only)

In .NET, you use "NuGet" packages to share code between projects. NuGet has a public repo of packages available at [https://www.nuget.org/](https://www.nuget.org/). If you haven't used NuGet on your Windows machine before, you may need to instruct NuGet to fetch packages from there.

Open the file `C:/Users/<your username>/AppData/Roaming/NuGet/NuGet.Config`, and paste the following content:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
```

### IDE

To be able to debug code, get syntax highlighting and display of compilation errors, autocomplete, and code navigation, it is nice to have an IDE. The most commonly used IDEs for .NET are summarized in the table below.

| Name | Platform | License | Download |
| - | - | - | - |
| Visual Studio|Windows | Community version is free. Other versions require a license. |[https://visualstudio.microsoft.com/vs/community](https://visualstudio.microsoft.com/vs/community)|
| Visual Studio Code | Cross-platform | Free | [https://code.visualstudio.com/download](https://code.visualstudio.com/download) |
| Rider | Cross-platform | Free for 30 days. After that, a license is required. | [https://www.jetbrains.com/rider/download](https://www.jetbrains.com/rider/download) |

Choose the IDE that suits your needs.

> If you are going to use Visual Studio Code, it is recommended to install the plugin "Ionide".
>
> - You can download Ionide here: [https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode)
> - You can read more about Ionide here: [https://ionide.io/](https://ionide.io/)

> Note that a common use case for IDEs is that they are also used to compile and run code. However, the instructions in the course will use the .NET CLI for this. You are of course free to build and run the code using your IDE if you wish.

### Git

Git is a free version control system available for all platforms. If you want to have the instructions for the course (the document you are reading now), or see the expected result after completing each of the different steps, on your own computer, you need Git installed. With Git you can also create your own version of this repo as explained [here](#check-out-your-branch).

You can download Git here: [https://git-scm.com/downloads](https://git-scm.com/downloads).

If you are new to Git, it may be helpful to read this article on how to work with changes in a Git repo: [https://git-scm.com/book/en/v2/Git-Basics-Recording-Changes-to-the-Repository](https://git-scm.com/book/en/v2/Git-Basics-Recording-Changes-to-the-Repository). There are also instructions at the end of the first step](https://github.com/nrkno/dotnetskolen/blob/main/README_EN.md#save-changes-to-git-optional) on how to save changes you make during the course in Git.

## 💻 Local setup of the code (optional)

### Clone repo

If you want this repo locally on your computer, you can fork this repo to your own user by following this guide: <https://docs.github.com/en/get-started/quickstart/fork-a-repo>. Then you can clone it, like this:

```bash
git clone git@github.com:<your username>/dotnetskolen.git # Download the repo from GitHub to your computer
```

```bash
Cloning into 'dotnet school'...
remote: Enumerating objects: 9, done.
remote: Counting objects: 100% (9/9), done.
remote: Compressing objects: 100% (5/5), done.
remote: Total 9 (delta 2), reused 4 (delta 1), pack-reused 0
Receiving objects: 100% (9/9), done.
Resolving participation: 100% (2/2), done.
```

> The command above assumes that you are using SSH to authenticate with GitHub. For more information about SSH authentication in GitHub, see <https://docs.github.com/en/authentication/connecting-to-github-with-ssh>
>
> If you want to clone with HTTPS instead, you must run the command above with this URL instead: `https://github.com/<your username>/dotnetskolen.git`, and enter your username and password.
>
> You can also use [GitHub's desktop client](https://desktop.github.com/)

You should now have the `main` branch checked out locally on your computer. You can verify this by going into the repo folder and listing the branches in Git:

```bash
cd dotnetskolen # Go into the folder where the repo is located locally
git branch # List all branches you have checked out locally
```

```bash
* main
```

### Check out your own branch

Before you start coding, you may want to create your own branch with `git checkout -b <branchname>`. This way you can keep your changes separate from the code already in the repo, and it will be easier for the instructor to help you.

```bash
git checkout -b my-branch
```

```bash
Switched to a new branch 'my-branch'
```

### Setting up .gitignore

There are usually some files that you don't want included in Git. This is something you quickly notice when setting up a new system. To tell Git which files you want to ignore, you can create a `.gitignore` file in the root of the repo.

GitHub has its own repo that contains `.gitignore` files for different types of projects: [https://github.com/github/gitignore](https://github.com/github/gitignore). The `.gitignore` files that GitHub has prepared contain the file types that are most commonly excluded from Git for the different project types. Since this course is about .NET, we can use `VisualStudio.gitignore` from their repo.

To set up `.gitignore` in your local repo:

1. Create a text file named `.gitignore` in the root of the repo
2. Paste the content of this file: [https://github.com/github/gitignore/blob/master/VisualStudio.gitignore](https://github.com/github/gitignore/blob/master/VisualStudio.gitignore)
3. Save and commit the `.gitignore` file.

#### How to commit `.gitignore`

##### View Git status

To view the status in Git, run the following command:

```bash
git status
```

```bash
On branch my-branch

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        .gitignore

nothing added to commit but untracked files present (use "git add" to track)
```

We see above that Git has detected `.gitignore` as a new file that Git is not tracking.

##### Add .gitignore to Git

To add `.gitignore` to Git in order for Git to track any changes made in that file in the future, run the following command:

```bash
git add .gitignore
```

To see the status in Git again, run the following command:

```bash
git status
```

```bash
On branch my-branch
Changes to be committed:
  (use "git restore --staged <file>..." to unstage)
        new file: .gitignore
```

#### Commit in Git

To save the current version of `.gitignore` in Git, run the following command:

```bash
git commit -m "Add .gitignore"
```

```bash
[my-branch 478fb9b] Added .gitignore
 1 file changed, 1 insertion(+)
 create mode 100644 .gitignore
```

The content of `.gitignore` is now stored in Git. If you now run `git status` again, you will see no remaining changes in the repo that Git has not picked up:

```bash
git status
```

```bash
On branch my-branch
nothing to commit, working tree clean
```
