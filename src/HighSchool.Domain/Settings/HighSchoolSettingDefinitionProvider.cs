using Volo.Abp.Settings;

namespace HighSchool.Settings;

public class HighSchoolSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HighSchoolSettings.MySetting1));
    }
}
