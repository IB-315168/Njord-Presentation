using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.Implementations
{
    public class UserHttpClient
    {
        private readonly HttpClient client;

        public UserHttpClient(HttpClient client)
        {
            this.client = client;
        }
    }
}
