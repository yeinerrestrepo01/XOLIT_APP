using Microsoft.AspNetCore;

namespace XOLIT.Productos.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
       WebHost.CreateDefaultBuilder(args)
           .UseStartup<Startup>()
           .UseKestrel(options =>
           {
               options.Limits.MaxRequestBodySize = null;
           }).Build();
    }
}