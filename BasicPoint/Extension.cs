public static class ExtensionService
{
    public static int ToInt(this string str)
    {
        int init = 0;
        int.TryParse(str, out init);
        return init;
    }

    public static float ToFloat(this string str)
    {

    }

    public static double ToDouble(this string str)
    {
        double init = 0d;
        double.TryParse(str, out init);
        return init;
    }

}