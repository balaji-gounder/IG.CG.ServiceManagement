

namespace IG.CG.Core.Domain.Constants.Queries
{
    public class UserQueries
    {
        public static string AllUser = "UserGetAll";
        public static string GetUserById = "UserGet";
        public static string UpsertUser = "UserInsertUpdate";
        public static string DeleteUser = "UserDelete";
        public static string GetUserTypeByUser = "UserGetByUserType";


        public static string AllUserByProductList = "UserWishProductGet";
        public static string UserAddRightsInsert = "UserAddRightsInsert";
        public static string UserAddRightsGetAll = "UserAddRightsGetAll";
        public static string UserAddRightsDelete = "UserAddRightsDelete";

        public static string GetSystemConfigGet = "SystemConfigGet";
    }
}
