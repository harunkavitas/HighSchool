using HighSchool.Localization;
using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HighSchool.Permissions;

public class HighSchoolPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        
        var highSchoolGroup = context.AddGroup(HighSchoolPermissions.GroupName, L("Permission:HighSchool"));

        var coursesPermission = highSchoolGroup.AddPermission(HighSchoolPermissions.Courses.Default, L("Permission:Courses"));
        coursesPermission.AddChild(HighSchoolPermissions.Courses.Create, L("Permission:Courses.Create"));
        coursesPermission.AddChild(HighSchoolPermissions.Courses.Edit, L("Permission:Courses.Edit"));
        coursesPermission.AddChild(HighSchoolPermissions.Courses.Delete, L("Permission:Courses.Delete"));

        var teachersPermission = highSchoolGroup.AddPermission(
     HighSchoolPermissions.Teachers.Default, L("Permission:Teachers"));
        teachersPermission.AddChild(
            HighSchoolPermissions.Teachers.Create, L("Permission:Teachers.Create"));
        teachersPermission.AddChild(
            HighSchoolPermissions.Teachers.Edit, L("Permission:Teachers.Edit"));
        teachersPermission.AddChild(
            HighSchoolPermissions.Teachers.Delete, L("Permission:Teachers.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HighSchoolResource>(name);
    }
}



    
