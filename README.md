# Handling ItemTapped event in ListView

ListView supports binding the [TapCommand](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~TapCommand.html) property with the item taped action from view model, where you can write navigation or any other action code in the execution. When defining the command, [ItemTappedEventArgs](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ItemTappedEventArgs.html) will be passed as command parameter which has item information in execution.

You can define the command parameter for `TapCommand` using [TappedCommandParameter](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~TapCommandParameter.html), where you can get the element reference passed in view model.

```
<syncfusion:SfListView x:Name="listView" 
                    TapCommand="{Binding TapCommand}"
                    ItemsSource="{Binding BookInfoCollection}"/>
```
```
//ViewModel.cs

public class BookInfoRepository : INotifyPropertyChanged
{
    private Command tapCommand;

    public Command TapCommand
    {
        get { return tapCommand; }
        protected set { tapCommand = value; }
    }

    public BookInfoRepository()
    {
        tapCommand = new Command(OnItemTapped);
    }

    ///<summary>
    ///To display tapped item content
    ///</summary>
    public void OnItemTapped(object obj)
    {
        var eventArgs = obj as Syncfusion.ListView.XForms.ItemTappedEventArgs;
        var bookName = (eventArgs.ItemData as BookInfo).BookName;
        var bookDescription = (eventArgs.ItemData as BookInfo).BookDescription;
        var display = Application.Current.MainPage.DisplayAlert(bookName, "Description:" + bookDescription, "Ok");
    }
}
```
To know more about MVVM in ListView, please refer our documentation [here](https://help.syncfusion.com/xamarin/sflistview/mvvm)
