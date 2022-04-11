using System.Data;

string path = @"/Users/iamherrylok/CodingSource/Git/BasicPoint/BasicPoint/Test.csv";
DataTable dataTable = new DataTable();
for (int i = 0; i < 10; i++)
{
    dataTable.Columns.Add(new DataColumn(i.ToString()));
}

dataTable.ToCSV(path, false);