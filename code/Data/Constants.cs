using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class Constants
    {
        //public class ObjectType
        //{
        //    public static JavaScripts = new Guid("");
        //    public Guid JavaScriptTestObject = new Guid("");
        //    public Guid JavaScriptAssociatedObjectTest = new Guid("");

        //}

        public class Javascripts
        {
            public static Guid ObjectTypeGuid = new Guid("E901E306-F2AA-4688-9D85-479975F13504");
            public class Fields
            {
                public static Guid Text = new Guid("E4E44FEE-0980-4EA5-B0D1-530157CAD962");
                public static Guid Disabled = new Guid("CAC16D0A-17A6-4987-9B7D-5EAE41237728");
                public static Guid ViewMode = new Guid("1C8C7600-FE10-47EC-BC9C-DE580ED43038");
            }

            public static class Choices
            {
                public static class ViewMode
                {
                    public static Guid EditOnly = new Guid("3B6F0BCA-3707-42DE-BE68-A331F1096371");
                    public static Guid ViewOnly = new Guid("FA7D20D5-49E3-412B-BBEF-1400490A323B");
                }
            }
        }

        public class JavaScriptTestObject
        {
            public Guid ObjectType = new Guid("36A1E2D5-138A-4FAB-9EE4-13C686EB56B4");
        }

        public class JavaScriptAssociatedObjectTest
        {
            public Guid ObjectType = new Guid("D4DD7489-4667-4272-959C-77DA81B6F0E0");
        }
    }
}
