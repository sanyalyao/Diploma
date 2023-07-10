using BussinesObject.UI.Models.EnumObjects;

namespace BussinesObject.UI.Helpers
{
    public class GroupHelper
    {
        public static int GetAccessTypes(accessTypes accessTypes)
        {
            switch (accessTypes)
            {
                case accessTypes.Public:
                    {
                        return 0;
                    }
                default:
                    {
                        return 1;
                    }
            }
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
