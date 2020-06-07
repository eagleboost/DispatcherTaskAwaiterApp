namespace DispatcherTaskAwaiterApp
{
  using System;
  using System.Runtime.CompilerServices;
  using System.Threading.Tasks;
  using System.Windows.Threading;

  public readonly struct DispatchTaskAwaiter : ICriticalNotifyCompletion
  {
    private readonly DispatchTaskAwaiterHelper _helper;

    public DispatchTaskAwaiter(Task task, Dispatcher dispatcher)
    {
      _helper = new DispatchTaskAwaiterHelper(task, dispatcher);
    }
    
    public DispatchTaskAwaiter GetAwaiter()
    {
      return this;
    }
    
    public bool IsCompleted
    {
      get { return _helper.IsCompleted; }
    }
      
    public void OnCompleted(Action continuation)
    {
      throw new NotImplementedException();
    }

    public void UnsafeOnCompleted(Action continuation)
    {
      _helper.UnsafeOnCompleted(continuation);
    }

    public void GetResult()
    {
      _helper.GetResult();
    }
  }
}