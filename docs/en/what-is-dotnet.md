# What is .NET?

.NET is a platform for developing and running applications, and consists of several things:

- Programming languages ​​- such as C# and F#
- Compilers - programs that compile code written in a .NET programming language to CIL ("common intermediate language")
- CIL ("common intermediate language") - a common low-level language that all .NET code is compiled into
- CLR ("common language runtime") - the runtime environment for .NET programs that translates the instructions defined in CIL into machine code, and runs the machine code
- BCL ("base class library") - a large collection of libraries written by Microsoft providing standard functionality such as data structures (lists, dates, etc.), IO (reading and writing files, network management) and security (encryption, certificates).

![dotnet-architecture](./illustrations/dotnet-architecture.drawio.svg)

## Versions of .NET

Originally, .NET was only available on Windows. This version of .NET is referred to as the .NET Framework. Implementations of the runtime environment were eventually ported to other platforms as well, such as Mono for Linux and Mac, and Xamarin for Android and iOS. Both Mono and Xamarin were originally developed by companies other than Microsoft. In 2016, Microsoft released a new version of .NET, .NET Core, which is an implementation of .NET for all platforms (Windows, Mac, and Linux). .NET Core went through three major versions, in parallel with the .NET Framework, which reached its latest version, 4.8, in 2019. The .NET Framework is no longer being developed, and in 2020, Microsoft released .NET 5, which is the version Microsoft will continue to develop going forward. At the time of writing (2025-01-30), .NET 9 is the latest version of .NET.

To define what is available in the different versions of .NET, Microsoft has created a specification, .NET Standard. .NET Standard has several versions, and the different versions of .NET (.NET Framework, .NET Core, Mono etc.) follow the specification of a given version of .NET Standard. Read more about .NET Standard, and compatibility across .NET versions here: [https://docs.microsoft.com/en-us/dotnet/standard/net-standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## References

- [https://www.mono-project.com/](https://www.mono-project.com/)
- [https://en.wikipedia.org/wiki/.NET_Core](https://en.wikipedia.org/wiki/.NET_Core)
- [https://en.wikipedia.org/wiki/.NET_Framework](https://en.wikipedia.org/wiki/.NET_Framework)
- [https://en.wikipedia.org/wiki/Common_Intermediate_Language](https://en.wikipedia.org/wiki/Common_Intermediate_Language)
- [https://docs.microsoft.com/en-us/dotnet/standard/clr](https://docs.microsoft.com/en-us/dotnet/standard/clr)
- [https://dotnet.microsoft.com/apps/xamarin](https://dotnet.microsoft.com/apps/xamarin)
