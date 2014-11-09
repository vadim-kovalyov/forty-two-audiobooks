using System;
using System.Collections.ObjectModel;
using FortyTwoAudiobooks.DataAccess;
using FortyTwoAudiobooks.Model;
using Microsoft.Practices.ServiceLocation;

namespace FortyTwoAudiobooks.Core.Config
{
    public class Seeds
    {
        public static void Configure()
        {
            var repository = ServiceLocator.Current.GetInstance<IBookRepository>();

            var books = new ObservableCollection<Book>();
            books.Add(new Book() { AccountName = "runtime one", Title = "Maecenas praesent accumsan bibendum" });
            books.Add(new Book()
            {
                AccountName = "runtime two",
                Title = "Dictumst eleifend facilisi faucibus",
                LastPlayed = DateTime.Now
            });
            books.Add(new Book()
            {
                AccountName = "another runtime",
                Title = "Eleifend facilisi faucibus",
                LastPlayed = DateTime.Now.AddDays(-1)
            });
            books.Add(new Book() { AccountName = "runtime three", Title = "Habitant inceptos interdum lobortis" });
            books.Add(new Book() { AccountName = "runtime four", Title = "Nascetur pharetra placerat pulvinar" });
            books.Add(new Book() { AccountName = "runtime five", Title = "Maecenas praesent accumsan bibendum" });
            books.Add(new Book() { AccountName = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime seven", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime seven", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime seven", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime seven", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime seven", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime seven", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime seven", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime six", Title = "Dictumst eleifend facilisi faucibus" });
            //books.Add(new Book() { AccountName = "runtime aloot", Title = "Dictumst eleifend facilisi faucibus" });

            repository.SaveBooksAsync(books).Wait();
        }
    }
}
