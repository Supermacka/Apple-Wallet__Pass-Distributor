using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppleWallet.Console;

public static class RequestHandler
{
    private static readonly HttpClient Client = new HttpClient();
    
    public static byte[] GetPass()
    {
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.apple.pkpass"));

        // var stringTask = Client.GetStringAsync("https://localhost:7161/Pass");
        var response = Client.GetAsync(string.Format("https://localhost:7161/Pass")).Result;
        if (!response.IsSuccessStatusCode) return Array.Empty<byte>(); // Return null instead?
        
        var result = response.Content.ReadAsStringAsync().Result.Replace("\"", string.Empty);
        var mybytearray = Convert.FromBase64String(result);

        return mybytearray;
    }
}