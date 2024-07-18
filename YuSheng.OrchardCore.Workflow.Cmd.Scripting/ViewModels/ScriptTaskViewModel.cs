using System.ComponentModel.DataAnnotations;

namespace YuSheng.OrchardCore.Workflow.Cmd.Scripting.ViewModels
{
    public class ScriptTaskViewModel
    {
        [Required]
        public string CmdFilePath { get; set; }

    }
}
