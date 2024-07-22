using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "YuSheng OrchardCore Workflow Cmd Scripting",
    Author = "spike",
    Website = "",
    Version = "0.0.4"
)]

[assembly: Feature(
    Id = "YuSheng.OrchardCore.Workflow.Cmd.Scripting",
    Name = "YuSheng OrchardCore Workflow Cmd Scripting",
    Description = "Provides cmd scripting ",
    Dependencies = new[] { "OrchardCore.Workflows" },
    Category = "Workflows"
)]
