using CMS.Core;
using CMS.Core.Internal;

using Kentico.Xperience.Admin.Base.Forms;
using Kentico.Xperience.Admin.Base.Forms.Internal;

using XperienceCommunity.DependingFieldComponents;
using XperienceCommunity.DependingFieldComponents.FormComponents.DateTimeInputDependsOnFieldComponent;
using XperienceCommunity.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(
    DependingFieldComponentsConstants.DATETIMEINPUT_IDENTIFIER,
    typeof(DateTimeInputDependsOnFieldComponent),
    DependingFieldComponentsConstants.DATETIMEINPUT_FIELDDESCRIPTION)]
namespace XperienceCommunity.DependingFieldComponents.FormComponents.DateTimeInputDependsOnFieldComponent;

/// <summary>
/// A form component which can be configured to appear based on the value of another field.
/// </summary>
[ComponentAttribute(typeof(DateTimeInputDependsOnFieldAttribute))]
public class DateTimeInputDependsOnFieldComponent(ILocalizationService localizationService, IDateTimeNowService dateTimeService) :
    DateTimeInputComponentBase<DependsOnPropertyProperties, DateTimeInputClientProperties, DateTime?>(localizationService, dateTimeService)
{
    public override string ClientComponentName => "@kentico/xperience-admin-base/DateTimeInput";


    protected override void ConfigureComponent()
    {
        DependingFieldVisibilityCondition.Configure(this);

        base.ConfigureComponent();
    }
}
