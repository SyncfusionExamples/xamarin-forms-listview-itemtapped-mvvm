using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM
{
    public class BookInfoRepository : INotifyPropertyChanged
    {
        private ObservableCollection<BookInfo> bookInfoCollection;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<BookInfo> BookInfoCollection
        {
            get { return bookInfoCollection; }
            set
            {
                this.bookInfoCollection = value;
                this.OnPropertyChanged("BookInfoCollection");
            }
        }

        private Command tapCommand;

        public Command TapCommand
        {
            get { return tapCommand; }
            protected set { tapCommand = value; }
        }

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public BookInfoRepository()
        {
            GenerateNewBookInfo();
            tapCommand = new Command(OnItemTapped);
        }

        private void GenerateNewBookInfo()
        {
            BookInfoCollection = new ObservableCollection<BookInfo>();
            BookInfoCollection.Add(new BookInfo() { BookName = "Machine Learning Using C#", BookDescription = "You’ll learn several different approaches to applying machine learning" });
            BookInfoCollection.Add(new BookInfo() { BookName = "Object-Oriented Programming in C#", BookDescription = "Object-oriented programming is the de facto programming paradigm" });
            BookInfoCollection.Add(new BookInfo() { BookName = "C# Code Contracts", BookDescription = "Code Contracts provide a way to convey code assumptions" });
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
}
