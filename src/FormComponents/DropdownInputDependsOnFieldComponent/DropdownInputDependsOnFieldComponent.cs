using CMS.Core;

using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

using XperienceCommunity.DependingFieldComponents;
using XperienceCommunity.DependingFieldComponents.FormComponents.DropdownInputDependsOnFieldComponent;
using XperienceCommunity.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(
    DependingFieldComponentsConstants.DROPDOWNINPUT_IDENTIFIER,
    typeof(DropdownInputDependsOnFieldComponent),
    DependingFieldComponentsConstants.DROPDOWNINPUT_FIELDDESCRIPTION)]
namespace XperienceCommunity.DependingFieldComponents.FormComponents.DropdownInputDependsOnFieldComponent;

/// <summary>
/// A form component which can be configured to appear based on the value of another field.
/// </summary>
[ComponentAttribute(typeof(DropdownInputDependsOnFieldAttribute))]
public class DropdownInputDependsOnFieldComponent(ILocalizationService localizationService) :
    FormComponent<DropdownInputDependsOnFieldProperties, DropDownClientProperties, string>
{
    public override string ClientComponentName => "@kentico/xperience-admin-base/DropDownSelector";


    public override string GetValue()
    {
        string value = base.GetValue();
        var options = GetOptions();

        return options?.FirstOrDefault(o => o.Value == value)?.Value ?? string.Empty;
    }


    protected override void ConfigureComponent()
    {
        DependingFieldVisibilityCondition.Configure(this);

        base.ConfigureComponent();
    }


    protected override async Task ConfigureClientProperties(DropDownClientProperties clientProperties)
    {
        clientProperties.Placeholder = !string.IsNullOrEmpty(Properties.Placeholder) ?
            localizationService.LocalizeString(Properties.Placeholder) : localizationService.GetString("base.forms.dropdown.placeholder");
        clientProperties.Options = GetOptions();

        await base.ConfigureClientProperties(clientProperties);
    }


    private IEnumerable<DropDownOptionItem> GetOptions()
    {
        if (Properties.OptionsItems != null)
        {
            return Properties.OptionsItems;
        }

        return KeyValueOptionsParser.ParseDataSource(
            Properties.Options ?? string.Empty,
            (value, text) => new DropDownOptionItem { Value = value, Text = localizationService.LocalizeString(text) }
        );
    }


    internal string GetSelectedValue() => base.GetValue();
}
