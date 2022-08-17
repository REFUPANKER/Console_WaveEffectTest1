using System;
using System.Threading.Tasks;

WaveManager waveManager = new WaveManager();
waveManager.Run();

public class WaveManager : FastConsoleCommands
{

    // table size : 9x9 
    string[,] table = new string[,]{
        {"[]","[]","[]","[]","[]","[]","[]","[]","[]"},
        {"[]","[]","[]","[]","[]","[]","[]","[]","[]"},
        {"[]","[]","[]","[]","[]","[]","[]","[]","[]"},
        {"[]","[]","[]","[]","[]","[]","[]","[]","[]"},
        {"[]","[]","[]","[]","[]","[]","[]","[]","[]"},
        {"[]","[]","[]","[]","[]","[]","[]","[]","[]"},
        {"[]","[]","[]","[]","[]","[]","[]","[]","[]"},
        {"[]","[]","[]","[]","[]","[]","[]","[]","[]"},
        {"[]","[]","[]","[]","[]","[]","[]","[]","[]"},
    };

    public int TableRowCount
    {
        get
        {
            return table.GetLength(0);
        }
        set { }
    }

    public int TableColumnCount
    {
        get
        {
            return table.GetLength(1);
        }
        set { }
    }
    public void Run()
    {
        cwl("App Running...");
        cwl("Table Rows:" + TableRowCount);
        cwl("Table Columns:" + TableColumnCount);
        CreateWave();
    }
    private void CreateWave()
    {
        cwl("Wave creating ...");
        Thread.Sleep(1000);
        clear();
        try
        {
            for (int i = 0; i < TableRowCount; i++)
            {
                table[i, i] = "██";
                for (int j = 0; j < i; j++)
                {
                    table[i, j] = "██";
                    table[i - 1, j] = "[]";
                }
                for (int j = 0; j < i; j++)
                {
                    table[j, i] = "██";
                    table[j, i - 1] = "[]";
                }
                cwl("=======================");
                Thread.Sleep(100);
                ShowTable();
            }
            for (int j = 0; j < TableRowCount; j++)
            {
                table[TableRowCount-1 , j] = "[]";
            }
            for (int j = 0; j < TableRowCount; j++)
            {
                table[j, TableRowCount-1] = "[]";
            }
            cwl("=======================");
            Thread.Sleep(100);
            ShowTable();
        }
        catch (System.Exception excp){
            cwl(excp.ToString());
         }
    }
    private void ShowTable()
    {
        for (int i = 0; i < TableRowCount; i++)
        {
            for (int j = 0; j < TableColumnCount; j++)
            {
                cw(table[i, j]);
            }
            cwl("");
        }
    }
}

public class FastConsoleCommands
{
    public void cwl(object msg)
    {
        Console.WriteLine(msg);
    }
    public void cw(object msg)
    {
        Console.Write(msg);
    }
    public object creadLn()
    {
        return Console.ReadLine();
    }
    public void clear()
    {
        Console.Clear();
    }
}
