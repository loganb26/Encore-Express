using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

public class HistoryPopup : Popup
{
    public HistoryPopup()
    {
        Size = new Size(300, 400);
        Color = Colors.White;

        var listView = new ListView
        {
            ItemsSource = new ObservableCollection<Song>(App.PlayHistory),
            ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "songName");
                textCell.SetBinding(TextCell.DetailProperty, "songPath");
                return textCell;
            })
        };

        Content = new StackLayout
        {
            Children = { listView }
        };
    }
}
