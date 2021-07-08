# JobsDashboard

Displays a list of active jobs

## Data

Expect a list of items that looks like this:

### api

```json
{
    "title": "",
    "description": "",
    "company": ""
}
```

### .NET class

```c#
public class JobSummary {
    public string Title;
    public string Description;
    public string Company;
}
```

### Dependencies

* <https://github.com/jobs-io/data>
