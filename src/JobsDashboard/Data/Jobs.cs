using System.Collections.Generic;

namespace JobsDashboard.Data
{
    public class Jobs : List<JobSummary>
    {
        public Jobs(HtmlReader.Reader reader, IConfiguration config)
        {
            foreach(var item in reader.HtmlItems(config.GetValue("path"))) {
                this.Add(new JobSummary(config, new HtmlReader.Reader(item)));
            }
        }
    }
}