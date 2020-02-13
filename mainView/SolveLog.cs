using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mainView
{
  public class LogItem
  {
    public string key;
    public string report;

    // playArea
    public int? x;
    public int? y;
    public TCell? old;
    public TCell? @new;

    // descriptor
    public int? padStartOld;
    public int? padStartNew;

    public int? padEndOld;
    public int? padEndNew;

    public bool? isVertical;
    public int? rowSize;
    public int? row;
    public int? position;
    public int? value;
  }

  public sealed class SolveLog
  {
    static SolveLog instance = null;
    static readonly object padlock = new object();

    public static SolveLog Instance
    {
      get
      {
        lock (padlock)
        {
          if (instance == null)
          {
            instance = new SolveLog();
          }
          return instance;
        }
      }
    }

    int changes;
    List<LogItem> log = new List<LogItem>();

    public void ResetChangesCounter()
    {
      changes = 0;
    }

    public void ClearLog()
    {
      log.Clear();
    }

    public int Changes { get { return changes; } }

    void WriteToLog(string line)
    {
      //Console.WriteLine(line);
    }

    internal void LogPA(string key, TCell @old, TCell @new, int x, int y)
    {
      var logItem = new LogItem { key = key, old = @old, @new = @new, x = x, y = y };
      logItem.report = $"PA:{key} Cell:{@old} -> {@new}";
      log.Add(logItem);

      WriteToLog(logItem.report);

      changes++;
    }

    internal void LogDPadStart(string key, int padStartOld, int padStartNew)
    {
      var logItem = new LogItem { key = key, padStartOld = padStartOld, padStartNew = padStartNew };
      logItem.report = $"Descr:{key} padStart:{padStartOld} -> {padStartNew}";
      log.Add(logItem);

      WriteToLog(logItem.report);

      changes++;
    }

    internal void LogDPadEnd(string key, int padEndOld, int padEndNew)
    {
      var logItem = new LogItem { key = key, padEndOld = padEndOld, padEndNew = padEndNew };
      logItem.report = $"Descr:{key} padEnd:{padEndOld} -> {padEndNew}";
      log.Add(logItem);

      WriteToLog(logItem.report);

      changes++;
    }

  }
}
