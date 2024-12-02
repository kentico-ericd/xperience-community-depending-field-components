using XperienceCommunity.DependingFieldComponents.VisibilityConditions;

namespace XperienceCommunity.DependingFieldComponents.FormComponents;

/// <summary>
/// Contains common form component properties used within the <see cref="DependingFieldVisibilityCondition"/>
/// </summary>
public interface IDependsOnPropertyProperties
{
    /// <summary>
    /// The name of the property that determines whether the component is visible.
    /// </summary>
    public string? DependsOn { get; set; }


    /// <summary>
    /// The value of the property specified by <see cref="DependsOn"/> which will reveal the depending property.
    /// </summary>
    public string? ExpectedValue { get; set; }
}
