namespace Common.Enums
{
    public enum UserRoleEnum
    {
        Student = 0,
        Admin = 1,
        QAManager = 2,
        QACoordinator = 3,
    }

    public class UserRoles
    {
        public const string Student = "Student";

        public const string Admin = "Admin";

        public const string QAManager = "QualityAssuranceManager";

        public const string QACoordinator = "QualityAssuranceCoordinator";
    }
}