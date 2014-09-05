using Nancy;

namespace KMorcinek.MisesTools.Web
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["Index"];
        }
    }
}