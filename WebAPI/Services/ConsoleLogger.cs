using System;

namespace WebAPI.Services
{
  public class ConsoleLogger : ILoggerService
  {
    public void Write(string msg)
    {
      Console.WriteLine($"[ConsoleLogger] - {msg}");
      
    }
  }
}