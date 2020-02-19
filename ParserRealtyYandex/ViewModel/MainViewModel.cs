using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParserRealtyYandex.Core;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParserRealtyYandex.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
       
        ParserWorker<string[]> worker;
        public MainViewModel(IParser<string[]> parser,IParserSettings settings)
        {
           
            worker = new ParserWorker<string[]>(parser,settings);
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        private ICommand _start;

        private ICommand books;
        public ICommand Start_Click => _start ?? (_start = new RelayCommand(() => { worker.Start();}));
            }
}