# 💡 Tips and tricks

- Several people have reported that their IDEs are showing compilation errors in the editor after adding new dependencies or creating new modules. If the project builds successfully, either using the IDE's built-in build function or by running `dotnet build`, but such errors are still showing in the editor, reloading the solution may help:
  - Rider - right-click on the "Solution" node (`Dotnetskolen`), and select `Reload projects`
  - Visual Studio - right-click on the current project, select `Unload project`. Right-click on the current project again, and select `Reload project`.
  - Visual Studio Code - close the editor, run `dotnet clean` followed by `dotnet build` from the terminal, and reopen the application
