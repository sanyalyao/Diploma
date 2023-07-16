using BussinesObject.UI.Models.EnumObjects;

namespace BussinesObject.UI.Helpers
{
    public class GroupHelper
    {
        public static int GetAccessTypes(AccessTypes accessTypes)
        {
            return (int)accessTypes;
        }

        public static int GetAccessTypes(string accessTypes)
        {
            switch (accessTypes)
            {
                case "Public":
                    {
                        return 0;
                    }
                default:
                    {
                        return 1;
                    }
            }
        }
    }
}
