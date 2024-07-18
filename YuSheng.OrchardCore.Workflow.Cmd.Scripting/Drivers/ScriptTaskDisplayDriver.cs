using OrchardCore.Workflows.Display;
using OrchardCore.Workflows.Models;
using YuSheng.OrchardCore.Workflow.Cmd.Scripting.Activities;
using YuSheng.OrchardCore.Workflow.Cmd.Scripting.ViewModels;

namespace YuSheng.OrchardCore.Workflow.Cmd.Scripting.Drivers
{
    public class ScriptTaskDisplayDriver : ActivityDisplayDriver<CmdScriptTask, ScriptTaskViewModel>
    {
        protected override void EditActivity(CmdScriptTask source, ScriptTaskViewModel model)
        {
            model.CmdFilePath = source.CmdFilePath.ToString();
        }

        protected override void UpdateActivity(ScriptTaskViewModel model, CmdScriptTask activity)
        {
            activity.CmdFilePath = new WorkflowExpression<string>(model.CmdFilePath);
        }
    }
}
