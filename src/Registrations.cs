﻿using CMS;

using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent;

[assembly: AssemblyDiscoverable]
[assembly: RegisterFormComponent(TextInputDependsOnFieldComponent.IDENTIFIER, typeof(TextInputDependsOnFieldComponent), "Text input with field dependancy")]
namespace Xperience.DependingFieldComponents
{
    internal class Registrations
    {
    }
}
