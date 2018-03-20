# Dna Framework Auto Uploader
A module that handles automatic uploading of content in a totally agnostic way. The system/device can implement a content manager to provide content to be uploaded, and a content uploader to upload content to a destination, and this module handles all the complexities of automatically uploading the content and keeping track of the content and progress

# Installing Dna Framework Auto Upload

You can install `Dna.Framework.AutoUpload` from your Visual Studio projects `Manage NuGet Packages` dialog and search for `Dna.Framework.AutoUpload`

Alternatively from **Package Manager** you can do `Install-Package Dna.Framework.AutoUpload`

From **.Net CLI** you can do `dotnet add package Dna.Framework.AutoUpload`

From **Paket CLI** you can do `paket add Dna.Framework.AutoUpload`

# Publishing New Package

To publish a new package:

- Update the `Project > Properties > Package > Package Version` 
- Change `Configuration` to `Release`
- Right-click project and select `Pack`
- Go to output folder `bin\Release` and you should see a `Dna.Framework.AutoUpload.x.x.x.nupkg`
- Start a `cmd` in that folder and type: `dotnet nuget push Dna.Framework.AutoUpload.x.x.x.nupkg -k yournugetkey -s https://api.nuget.org/v3/index.json`