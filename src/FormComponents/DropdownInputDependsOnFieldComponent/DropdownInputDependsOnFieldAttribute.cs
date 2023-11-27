﻿using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Xperience.DependingFieldComponents.FormComponents.DropdownInputDependsOnFieldComponent
{
    public class DropdownInputDependsOnFieldAttribute : FormComponentAttribute, IDependsOnPropertyProperties
    {
        public string? DependsOn { get; set; }


        public string? ExpectedValue { get; set; }
    }
}
