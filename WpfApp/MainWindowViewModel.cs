using System;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace WpfApp
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public readonly string[] Virtues;
        public readonly string[] Vices;

        [ObservableProperty]
        private int _number = 3;

        [ObservableProperty]
        private string? _result;

        public MainWindowViewModel()
        {
            static string[] Parse(string input) =>
                input.Split(Environment.NewLine).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            Vices = Parse(Resources.Vices);
            Virtues = Parse(Resources.Virtues);
        }

        [ICommand]
        public void GenerateVices() => Generate(Vices);

        [ICommand]
        public void GenerateVirtues() => Generate(Virtues);

        public void Generate(string[] set)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _number; i++)
            {
                sb.AppendLine(set[Random.Shared.Next(set.Length)]);
                sb.AppendLine();
            }

            Result = sb.ToString();
        }

        [ICommand]
        public void CopyToClipboard()
        {
            if (_result != null)
                Clipboard.SetText(_result);
        }
    }
}