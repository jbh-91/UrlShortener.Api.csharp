
namespace UrlShortener.Api.Utils;

public static class IpAnonymizationService
{
    public static string AnonymizeIp(string ipAddress)
    {
        if (string.IsNullOrEmpty(ipAddress))
            return ipAddress;
        // For IPv4, mask the last octet
        if (ipAddress.Contains('.'))
        {
            var segments = ipAddress.Split('.');
            if (segments.Length == 4)
            {
                segments[3] = "0"; // Mask the last octet
                return string.Join('.', segments);
            }
        }
        // For IPv6, mask the last 80 bits (the last 5 segments)
        else if (ipAddress.Contains(':'))
        {
            var segments = ipAddress.Split(':');
            if (segments.Length >= 8)
            {
                for (int i = 3; i < segments.Length; i++)
                {
                    segments[i] = "0000"; // Mask the last 5 segments
                }
                return string.Join(':', segments);
            }
        }
        // If the format is unrecognized, return it as is
        return ipAddress;
    }
}
