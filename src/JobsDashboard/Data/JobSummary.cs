namespace JobsDashboard.Data
{
    public class JobSummary
    {
        public readonly string Title;
        public readonly string Description;
        public readonly string Company;

        public JobSummary(IConfiguration config, HtmlReader.Reader reader)
        {
            this.Title = reader.Html(config.GetValue("title"));
            this.Description = reader.Html(config.GetValue("description"));
            this.Company = reader.Html(config.GetValue("company"));
        }
    }
}