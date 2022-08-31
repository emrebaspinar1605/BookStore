using System;
namespace WebAPI.Services
{
  public interface ILoggerService
  {
    public void Write(string msg);
  }
}