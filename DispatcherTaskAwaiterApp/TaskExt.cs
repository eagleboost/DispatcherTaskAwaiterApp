namespace DispatcherTaskAwaiterApp
{
  using System.Threading.Tasks;
  using System.Windows.Threading;

  public static class TaskExt
  {
    public static DispatchTaskAwaiter ConfigureAwait(this Task task, Dispatcher dispatcher)
    {
      return new DispatchTaskAwaiter(task, dispatcher);
    }
    
    public static DispatchTaskAwaiter<T> ConfigureAwait<T>(this Task<T> task, Dispatcher dispatcher)
    {
      return new DispatchTaskAwaiter<T>(task, dispatcher);
    }
  }
}