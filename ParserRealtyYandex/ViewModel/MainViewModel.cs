using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParserRealtyYandex.Core;
using ParserRealtyYandex.Core.RealtyYandex;
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
       
        ParserWorker<Building> worker;
        public MainViewModel(IParser<Building> parser,IParserSettings settings)
        {
           
            worker = new ParserWorker<Building>(parser,settings);
            worker.Start();


        }
        private ICommand _start;


        public ICommand Start_Click => _start ?? (_start = new RelayCommand(() => { worker.Start();}));
            }
}