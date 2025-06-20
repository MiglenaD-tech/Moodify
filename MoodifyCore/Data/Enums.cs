using Microsoft.Extensions.Localization;

namespace MoodifyCore.Data
{
    public class Enums
    {
        public class UserRole
        {
            private const sbyte AdminValue = 1;
            private const sbyte ClientValue = 2;

            public static readonly sbyte Admin = AdminValue;
            public static readonly sbyte Client = ClientValue;

            public static List<sbyte> All { get; }

            static UserRole()
            {
                All =
                [
                    Admin,
                    Client
                ];
            }

        }

    }
}
