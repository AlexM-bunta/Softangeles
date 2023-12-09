namespace WebAPI;

public static class Utils
{
    public static string GenerateIBAN()
    {
        return string.Format($"RO{Guid.NewGuid().ToString().Replace("-","").ToUpper()}");
    }
}
