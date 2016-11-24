using System;
using System.Windows;
using KeyGen;
using Prism.Commands;
using PropertyChanged;

namespace KeyGenProgram
{
    [ImplementPropertyChanged]
    class ViewModel
    {
        public DelegateCommand GenerateComand { get; set; }

        public ViewModel()
        { 
            Key = "Hello World";
            GenerateComand = new DelegateCommand(GenerateValidKey);
        }

        public string Key { get; set; }

        private async void GenerateValidKey()
        {
            Key = await KeyGenerator.GenerateAsync();
            MessageBox.Show("New key generated " + Key);
        }

    }
}
