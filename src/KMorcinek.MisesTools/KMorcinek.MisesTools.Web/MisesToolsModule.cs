using Nancy;
using Nancy.ModelBinding;

namespace KMorcinek.MisesTools.Web
{
    public class MisesToolsModule : NancyModule
    {
        public MisesToolsModule()
            : base("/api")
        {
            Post["/mutuallinker"] = _ =>
            {
                var text = this.Bind<DataWithText>().Text;

                text = new MutualLinker().AddLinks(text);

                return new
                {
                    text
                };
            };
        }
    }
}