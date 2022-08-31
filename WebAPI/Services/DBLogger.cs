using System;

namespace WebAPI.Services
{
  public class DBLogger : ILoggerService
  {
    public void Write(string msg)
    {
      Console.WriteLine($"[DBLogger] - {msg}");
      
    }
  }
}