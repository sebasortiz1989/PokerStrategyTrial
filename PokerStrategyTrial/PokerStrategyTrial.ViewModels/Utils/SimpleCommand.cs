using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PokerStrategyTrial.ViewModels.Utils;

public class SimpleCommand : INotifyPropertyChanged, ICommand
{
    private readonly Func<Task> target;
    private bool canExecute;

    public SimpleCommand(Func<Task> target, bool canExecute)
    {
        this.target = target;
        CanExecute(canExecute);
    }

    public void Execute(object? parameter)
    {
        if (!canExecute) return;

        InvokeTarget(target, parameter);
    }

    public bool CanExecute(object? parameter)
    {
        if (parameter is not bool canExecuteBool) return false;

        canExecute = canExecuteBool;
        CanExecuteChanged?.Invoke(canExecute, EventArgs.Empty);
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(canExecute)));
        return canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    private static Task InvokeTarget(Delegate target, object? parameter)
    {
        switch (target)
        {
            case Action action:
                action();
                return Task.CompletedTask;
            case Action<object> action:
                if (parameter != null)
                    action(parameter);
                return Task.CompletedTask;
            case Func<Task> func:
                return func();
            case Func<object, Task> func:
                return parameter != null ? func(parameter) : Task.CompletedTask;
            default:
                throw new InvalidCastException("Unexpected target type: " + target.GetType());
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}