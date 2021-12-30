using Nancy;
using Nancy.ModelBinding;

namespace TestNancyKestrel
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", r => "Nancy running on ASP.NET Core LineZero");
            Get("/{name}", r => "simple route：" + r.name);
            Get("/404", r => HttpStatusCode.NotFound);
            Get("route/{blah}", r => "param=" + r.blah);//由URL路由取得參數

            //https://blog.darkthread.net/blog/nancyfx/
            //http://localhost:5144/concat?A%=jojo&B=dio
            Get("concat", (p) =>
            {
                //Query, Form是dynamic，取屬性時可寫成Query.A或Query["A"]
                //Query.Blah傳回型別為DynamicDictionaryValue, 有HasValue及Value
                return string.Format("{0} {1}",
                    Request.Query.A.Value ?? Request.Form.A.Value ?? string.Empty,
                    Request.Query["B"].Value ?? Request.Form["B"].Value ?? string.Empty);
            });
            Post("concat", (p) =>
            {
                //Query, Form是dynamic，取屬性時可寫成Query.A或Query["A"]
                //Query.Blah傳回型別為DynamicDictionaryValue, 有HasValue及Value
                return string.Format("{0} {1}",
                    Request.Query.A.Value ?? Request.Form.A.Value ?? string.Empty,
                    Request.Query["B"].Value ?? Request.Form["B"].Value ?? string.Empty);
            });

            Post("concatByModel", (p) =>
            {
                var param = this.Bind<ConcatParams>();
                return string.Format("{0} {1}", param.As, param.Bs);
            });

            Post("concatByJson", (p) =>
            {
                var param = this.Bind<ConcatParams>();
                return Response.AsJson(new
                {
                    Resullt = string.Format("{0} {1}", param.As, param.Bs)
                });
            });
        }
    }
}
