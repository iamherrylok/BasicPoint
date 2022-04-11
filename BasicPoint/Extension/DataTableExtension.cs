using System.Data;

public static class DataTableExtension
{
    /// <summary>
    ///     dataTable转CSV
    /// </summary>
    /// <param name="dataTable"></param>
    /// <param name="path"></param>
    public static void ToCSV(this DataTable dataTable, string path, bool isAppend)
    {
        if (!File.Exists(path))
            File.Create(path);

        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            string title = string.Empty;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                title += dataTable.Columns[i].ColumnName;
                if (i < dataTable.Columns.Count - 1)
                    title += ",";
            }
            sw.Write(title);

        }
    }

    /// <summary>
    ///     读取CSV到dataTable
    /// </summary>
    /// <param name="dataTable"></param>
    /// <param name="path"></param>
    public static void FromCSV(this DataTable dataTable, string path)
    {

    }
}