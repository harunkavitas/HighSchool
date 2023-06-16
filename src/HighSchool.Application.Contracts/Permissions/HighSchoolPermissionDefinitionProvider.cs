using HighSchool.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HighSchool.Permissions;

public class HighSchoolPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HighSchoolPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(HighSchoolPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HighSchoolResource>(name);
    }
}
