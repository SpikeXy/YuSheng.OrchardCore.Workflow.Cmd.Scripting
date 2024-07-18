using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.Workflows.Helpers;
using YuSheng.OrchardCore.Workflow.Cmd.Scripting.Activities;
using YuSheng.OrchardCore.Workflow.Cmd.Scripting.Drivers;

namespace YuSheng.OrchardCore.Workflow.Cmd.Scripting
{
    [Feature("OrchardCore.Workflows")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            services.AddActivity<CmdScriptTask, ScriptTaskDisplayDriver>(); ;


        }
    }
}
