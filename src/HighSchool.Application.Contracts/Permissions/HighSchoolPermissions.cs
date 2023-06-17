namespace HighSchool.Permissions;

public static class HighSchoolPermissions
{
    public const string GroupName = "HighSchool";

    public static class Courses
    {
        public const string Default = GroupName + ".Courses";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Teachers
    {
        public const string Default = GroupName + ".Teachers";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
