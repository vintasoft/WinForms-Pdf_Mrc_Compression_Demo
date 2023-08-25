# VintaSoft WinForms PDF MRC Compression Demo

This C# project uses <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html">VintaSoft Imaging .NET SDK</a> and demonstrates how to compress PDF document using MRC compression:
* Load images from file, acquire images from scanner.
* Store and edit the MRC compression settings for each image.
* Detect the picture regions on the image.
* Save images to a PDF document with MRC compression.


## Screenshot
<img src="vintasoft-pdf-mrc-compression-demo.png" alt="VintaSoft PDF MRC Compression Demo">


## Usage
1. Get the 30 day free evaluation license for <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html" target="_blank">VintaSoft Imaging .NET SDK</a> as described here: <a href="https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html" target="_blank">https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html</a>

2. Update the evaluation license in "CSharp\MainForm.cs" file:
   ```
   Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");
   ```

3. Build the project ("PdfMrcCompressionDemo.Net7.csproj" file) in Visual Studio or using .NET CLI:
   ```
   dotnet build PdfMrcCompressionDemo.Net7.csproj
   ```

4. Run compiled application and try to compress PDF document using MRC compression.


## Documentation
VintaSoft Imaging .NET SDK on-line User Guide and API Reference for .NET developer is available here: https://www.vintasoft.com/docs/vsimaging-dotnet/


## Support
Please visit our <a href="https://myaccount.vintasoft.com/">online support center</a> if you have any question or problem.
