﻿using System.Management.Automation;
using System.Web;

namespace Spe.Commands.Session
{
    [Cmdlet(VerbsLifecycle.Restart, "Application", SupportsShouldProcess = true)]
    public class RestartApplication : BaseCommand
    {
        protected override void BeginProcessing()
        {
            if (ShouldProcess("Application", "Restart"))
            {
                HttpRuntime.UnloadAppDomain();
            }
        }
    }
}