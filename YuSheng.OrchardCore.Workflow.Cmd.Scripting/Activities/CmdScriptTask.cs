using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using OrchardCore.Workflows.Abstractions.Models;
using OrchardCore.Workflows.Activities;
using OrchardCore.Workflows.Models;
using OrchardCore.Workflows.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SimpleExec;

namespace YuSheng.OrchardCore.Workflow.Cmd.Scripting.Activities
{
    public class CmdScriptTask : TaskActivity
    {
        private readonly IWorkflowScriptEvaluator _scriptEvaluator;
        private readonly IStringLocalizer S;
        private readonly IHtmlHelper _htmlHelper;
        private readonly IWorkflowExpressionEvaluator _expressionEvaluator;
        public CmdScriptTask(IWorkflowScriptEvaluator scriptEvaluator,
            IWorkflowExpressionEvaluator expressionEvaluator,
            IHtmlHelper htmlHelper,
            IStringLocalizer<CmdScriptTask> localizer)
        {
            _scriptEvaluator = scriptEvaluator;
            _expressionEvaluator = expressionEvaluator;
            S = localizer;
            _htmlHelper = htmlHelper;

        }

        public override string Name => nameof(CmdScriptTask);

        public override LocalizedString DisplayText => S["Cmd Script Task"];

        public override LocalizedString Category => S["Script"];

        public WorkflowExpression<string> CmdFilePath
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext, ActivityContext activityContext)
        {
            return Outcomes(S["Success"], S["Failed"]);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext, ActivityContext activityContext)
        {

            var cmdFilePath = await _expressionEvaluator.EvaluateAsync(CmdFilePath, workflowContext, null);

            if (!string.IsNullOrEmpty(cmdFilePath))
            {
                string code = "";
                bool isSuccess = true;
                try
                {
                    var (standardOutput1, standardError1) = await Command.ReadAsync(cmdFilePath);
                    if(string.IsNullOrEmpty(standardError1))
                    {
                        code = standardOutput1;
                    }
                    else
                    {
                        isSuccess = false;
                        code = standardError1;
                    }
                }
                catch (Exception ex)
                {
                    code = ex.Message;
                    isSuccess = false;
                }

                workflowContext.Output["CmdScript"] = _htmlHelper.Raw(_htmlHelper.Encode(code)) ;
                if (isSuccess) 
                {
                    return Outcomes("Success");
                }
                else
                {
                    return Outcomes("Failed");
                }
            }
            else
            {
                workflowContext.Output["CmdScript"] = "cmd File Path is null";
                return Outcomes("Failed");
            }

            
        }
    }
}
