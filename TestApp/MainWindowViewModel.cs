

using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace TestApp
{
  public class MainWindowViewModel : BindableBase
  {
    public Setting ProgramSetting { get; set; }

    public ICommand OnCloseCommand { get; set; }

    public MainWindowViewModel()
    {
      ProgramSetting = GetSetting();
      ProgramSetting.IsModified = false;

      OnCloseCommand = new DelegateCommand(SaveSetting);
    }
    private Setting GetSetting()
    {
      //using (var streamReader = new StreamReader("Setting/Setting.csv"))
      //{
      //  var csvHelper = new CsvReader(streamReader, CultureInfo.InvariantCulture);
      //  var settings = csvHelper.GetRecords<Setting>();
      //  return settings.FirstOrDefault();
      //}


      using (StreamReader r = new StreamReader("Setting/Setting.json"))
      {
        string json = r.ReadToEnd();
        var setting = JsonConvert.DeserializeObject<Setting>(json);
        return setting;
      }

    }

    private void SaveSetting()
    {
      //var records = new List<Setting>
      //{
      //    ProgramSetting
      //};

      //using (var writer = new StreamWriter("Setting/Setting.csv"))
      //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
      //{
      //  csv.WriteRecords(records);
      //}

      if (MessageBox.Show("May co muon save ko", "Ask Save", MessageBoxButton.YesNo) == MessageBoxResult.No)
        return;

      using (StreamWriter file = File.CreateText("Setting/Setting.json"))
      {
        JsonSerializer serializer = new JsonSerializer();
        //serialize object directly into file stream
        serializer.Serialize(file,ProgramSetting);
        ProgramSetting.IsModified = false;
        MessageBox.Show("Saved!");
      }
    }
  }
}
