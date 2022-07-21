using System.Reflection;
using System.Runtime.InteropServices;
using SFramework.Core.Aspects.Postsharp.ExceptionAspects;
using SFramework.Core.Aspects.Postsharp.LogAspects;
using SFramework.Core.Aspects.Postsharp.PerformanceAspects;
using SFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

[assembly: AssemblyTitle("SFramework.Northwind.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("SFramework.Northwind.Business")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "SFramework.Northwind.Business.Concrete.Managers.*", AspectPriority = 1)]
[assembly: LogAspect(typeof(FileLogger), AttributeTargetTypes = "SFramework.Northwind.Business.Concrete.Managers.*", AspectPriority = 1)]
[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "SFramework.Northwind.Business.Concrete.Managers.*", AspectPriority = 1)]
[assembly: PerformanceCounterAspect(4, AttributeTargetTypes = "SFramework.Northwind.Business.Concrete.Managers.*", AspectPriority = 1)]

[assembly: ComVisible(false)]

[assembly: Guid("7ded3106-f64e-46bc-a8d6-4a1ca0c586d5")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
