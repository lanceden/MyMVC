using System.Web.Mvc;

namespace MyMVC
{
    public static class MyExtension
    {
        public static MvcHtmlString Button(this HtmlHelper htmlHelper)
        {
            var buttonStr = "<button>HTML Button</button>";
            return new MvcHtmlString(buttonStr);
        }
    }
}