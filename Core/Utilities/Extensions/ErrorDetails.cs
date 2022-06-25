using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace Core.Utilities.Extensions
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
