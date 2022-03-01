using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppleWallet.Library;
using Newtonsoft.Json;

namespace AppleWallet.Console;

public static class RequestHandler
{
    private static readonly HttpClient Client = new HttpClient();
    
    /// <summary>
    /// Creates a connection to the .pkpass API and returns its GET endpoint
    /// </summary>
    /// <returns>byte[]</returns>
    public static byte[] GetPass()
    {
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.apple.pkpass"));
        
        var response = Client.GetAsync("https://localhost:7161/Passes/1/ALV").Result;
        if (!response.IsSuccessStatusCode) return Array.Empty<byte>(); // Return null instead?
        
        var result = response.Content.ReadAsByteArrayAsync().Result;

        return result;
    }
}