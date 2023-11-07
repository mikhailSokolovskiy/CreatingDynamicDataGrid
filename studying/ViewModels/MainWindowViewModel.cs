using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Text;
using System.Windows.Input;
using Avalonia.Controls;
using DynamicData;
using ReactiveUI;
using studying.Models;
using Controls = Avalonia.Controls.Controls;

namespace studying.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    public ObservableCollection<Table> DynamicTable { get; }
    public ReactiveCommand<Unit, Unit> AddNewRow { get; }
    public ReactiveCommand<Unit, Unit> AutoNum { get; }
    public ObservableCollection<MainWindowViewModel> Items { get; } = new ObservableCollection<MainWindowViewModel>();


    public MainWindowViewModel()
    {
        DynamicTable = new ObservableCollection<Table>(GenerateMockPeopleTable());

        AddNewRow = ReactiveCommand.Create(() =>
        {
            DynamicTable.Add(
                new Table()
                {
                    FirstName = (DynamicTable.Count + 1).ToString(),
                    LastName = (DynamicTable.Count + 3).ToString(),
                });
            Items.Add(new MainWindowViewModel());
        });

        AutoNum = ReactiveCommand.Create(() =>
        {
            for (int i = 0; i < 20; i++)
            {
                DynamicTable.Add(
                    new Table()
                    {
                        FirstName = (DynamicTable.Count + 1).ToString(),
                        LastName = (DynamicTable.Count + 3).ToString(),
                    });
                Items.Add(new MainWindowViewModel()); 
            }
        });
    }




    private IEnumerable<Table> GenerateMockPeopleTable()
    {
        return new List<Table>();
    }

    

}


    