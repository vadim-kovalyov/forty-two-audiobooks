using System.Collections.ObjectModel;
using FizzWare.NBuilder;

namespace FortyTwoAudiobooks.Core.Tests.Extensions
{
    public static class NBuilderExtensions
    {
        public static ObservableCollection<T> BuildObservable<T>(this IListBuilder<T> buildable)
        {
            return new ObservableCollection<T>(buildable.Build());
        }
    }
}
