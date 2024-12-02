using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateTask();
        }

        void AddMessage (string message)
        {
            int CurrentThread = Thread.CurrentThread.ManagedThreadId;
            this.Dispatcher.Invoke(() =>
            {
                Messages.Content +=
                    $"Mensaje: {message}, " +
                    $"Hilo Actual: {Thread.CurrentThread.ManagedThreadId}\n";
            });
        }

        void CreateTask() 
        {
            Task T;
            // Que es un delegado? Es un apuntador a funciones
            var Code = new Action(ShowMesage);
            T = new Task(Code);
            Task T2 = new Task(delegate
			{
				MessageBox.Show("Ejecutando una tarea en un metodo anonimo");
			}
            );
            Task T3A = new Task(ShowMesage);
            Task T3 = new Task(
                () => ShowMesage());

            //EXPRESION Lambda:
            //(paremetros de entrada) => Expresion

            Task T4 = new Task(()=> MessageBox.Show("Ejecutando la tarea 4"));

            Task T5 = new Task(() => 
                {
                    DateTime CurrentDate = DateTime.Today;
					DateTime StartDate = CurrentDate.AddDays(30);
                    MessageBox.Show($"Tarea 5. Fecha Calculada: {StartDate}");
				});

            Task T6 = new Task((message) =>
            MessageBox.Show(message.ToString()), "Expresion lambda con parametros.");

            Task T7 = new Task(() => AddMessage("Ejecutando la tarea."));
            T7.Start();
            AddMessage("En el hilo principal");

		}

		
        void ShowMesage()
        {
            MessageBox.Show("Ejecutando el metodo ShowMessage");
		}

       
}
}