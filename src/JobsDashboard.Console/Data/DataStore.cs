using System.Collections.Generic;
using System.IO;
using System.Linq;
using JobsDashboard.Data;
using Newtonsoft.Json;

namespace JobsDashboard.Console.Data {
    public class DataStore : IDataStore {
        private IDictionary<string, string> data;
        private readonly string filePath;
        public DataStore (string filePath) {
            this.filePath = filePath;
            this.data = JsonConvert.DeserializeObject<IDictionary<string, string>> (File.ReadAllText (filePath));
        }
        public void CreateJobs (IDictionary<string, string> data) {
            this.data.Add(data.Keys.First(), data.Values.First());
            File.WriteAllText(filePath, JsonConvert.SerializeObject(this.data));
        }

        public bool Exists (string source) {
            return this.data.ContainsKey(source);
        }

        public string GetJobs (string source) {
            throw new System.NotImplementedException ();
        }
    }
}