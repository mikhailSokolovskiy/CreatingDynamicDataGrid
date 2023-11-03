using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
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
                    DepartmentNumber = 200
                });
           
            
        });

    }

    private IEnumerable<Table> GenerateMockPeopleTable()
    {
        return new List<Table>();
    }
    
    
}