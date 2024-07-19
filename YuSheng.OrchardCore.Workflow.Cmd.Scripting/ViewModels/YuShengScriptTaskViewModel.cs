using System.ComponentModel.DataAnnotations;

namespace YuSheng.OrchardCore.Workflow.Cmd.Scripting.ViewModels
{
    public class YuShengScriptTaskViewModel
    {
        [Required]
        public string CmdFilePath { get; set; }

    }
}
