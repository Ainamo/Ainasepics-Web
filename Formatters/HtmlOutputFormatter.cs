using Microsoft.AspNetCore.Mvc.Formatters;
namespace AinasepicsApi.Formatters {
    public class HtmlOutputFormatter : StringOutputFormatter
    {
        public HtmlOutputFormatter()
        {
            SupportedMediaTypes.Add("text/html");
        }
    }
}