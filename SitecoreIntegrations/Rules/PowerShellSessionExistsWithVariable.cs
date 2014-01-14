﻿using Cognifide.PowerShell.PowerShellIntegrations.Host;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Cognifide.PowerShell.SitecoreIntegrations.Rules
{
    public class PowerShellSessionExistsWithVariable<T> : WhenCondition<T> where T : RuleContext
    {
        // Methods
        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");

            if (string.IsNullOrEmpty(PersistentSessionId) || string.IsNullOrEmpty(VariableName) || !ScriptSessionManager.SessionExists(PersistentSessionId))
            {
                return false;
            }
            ScriptSession session = ScriptSessionManager.GetSession(PersistentSessionId);
            return session.GetVariable(VariableName) != null;
        }

        // Properties
        public string PersistentSessionId { get; set; }
        public string VariableName { get; set; }
    }
}