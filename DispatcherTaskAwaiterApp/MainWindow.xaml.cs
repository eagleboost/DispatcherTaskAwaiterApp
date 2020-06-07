namespace DispatcherTaskAwaiterApp
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Input;
  using System.Windows.Threading;

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    private readonly Dispatcher _dispatcher; 
    
    public MainWindow()
    {
      InitializeComponent();
      
      _dispatcher = Dispatcher.CurrentDispatcher;
    }

    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      Log("GUI thread: " + Thread.CurrentThread.ManagedThreadId.ToString());
      
      await Task.Run(async () =>
      {
        Log("Execute task on worker thread: " + Thread.CurrentThread.ManagedThreadId.ToString());
        await ExecuteAsync();
      });
    }

    private async Task ExecuteAsync()
    {
      await Task.Delay(100).ConfigureAwait(false);
      await Task.Delay(100).ConfigureAwait(_dispatcher);
      Log("Use 'ConfigureAwait(_dispatcher)' to continue task on GUI thread: " + Thread.CurrentThread.ManagedThreadId.ToString());
    }

    private void Log(string log)
    {
      if (_dispatcher.CheckAccess())
      {
        ListBox.Items.Add(log);
      }
      else
      {
        _dispatcher.BeginInvoke((Action)(() => Log(log)));
      }
    }
  }
}