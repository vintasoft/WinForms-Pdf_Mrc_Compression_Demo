using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


#if REMOVE_PDF_PLUGIN
#error PdfMrcCompressionDemo project cannot be used without VintaSoft PDF .NET Plug-in.
#endif
#if REMOVE_DOCCLEANUP_PLUGIN
#error PdfMrcCompressionDemo cannot be used without VintaSoft Document Cleanup .NET Plug-in.
#endif

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("VintaSoft PDF MRC Compression Demo")]
[assembly: AssemblyDescription("Shows how to compress PDF documents using MRC compression.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("VintaSoft Ltd.")]
[assembly: AssemblyProduct("VintaSoft Imaging .NET SDK")]
[assembly: AssemblyCopyright("Copyright VintaSoft Ltd. 2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("8823c5c6-b16f-4eed-b739-2bda4d67a938")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("12.4.9.1")]
[assembly: AssemblyFileVersion("12.4.9.1")]
