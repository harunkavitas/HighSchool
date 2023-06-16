using System.Threading.Tasks;
using HighSchool.Localization;
using HighSchool.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace HighSchool.Blazor.Menus;

public class HighSchoolMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<HighSchoolResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                HighSchoolMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );
        context.Menu.AddItem(
          new ApplicationMenuItem(
        "HighSchool",
        l["Menu:HighSchool"],
        icon: "fa fa-desktop"
       ).AddItem(
        new ApplicationMenuItem(
            "HighSchool.Course",
            l["Menu:Course"],
            url: "/courses"
        )
    )
);
 

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
