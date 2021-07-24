using System;
using System.IO;

namespace JobsDashboard.Console
{
    public class Config {
        public readonly string dataSource;
        public readonly string source;

        public Config(string[] args)
        {
            foreach(var arg in args) {
                if (arg.StartsWith("-ds:"))
                    this.dataSource = arg.Substring(4);
                if(arg.StartsWith("-s:"))
                    this.source = arg.Substring(3);
            }   
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Config(args);
            System.Console.WriteLine(config.dataSource);
            System.Console.WriteLine(config.source);
        }
    }
}
