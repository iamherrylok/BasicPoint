public static class ExtensionService
{
    static ExtensionService()
    {

    }
    public static int ToInt(this string str)
    {
        int init = 0;
        int.TryParse(str, out init);
        return init;
    }

    public static float ToFloat(this string str)
    {
        float init = 0f;
        float.TryParse(str, out init);
        return init;
    }

    public static double ToDouble(this string str)
    {
        double init = 0d;
        double.TryParse(str, out init);
        return init;
    }

    public static bool ToBoolean(this string str)
    {
        bool init = false;
        bool.TryParse(str, out init);
        return init;
    }

}