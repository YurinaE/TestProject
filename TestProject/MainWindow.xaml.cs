using MediatR;
using System.Windows;
using System.Windows.Controls;
using TestProject.Application;
using TestProject.Data.Models;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMediator _mediator;
        private readonly IParseService _parseService;
        public MainWindow(IMediator mediator, IParseService parseService)
        {
            _mediator = mediator;
            _parseService = parseService;

            InitializeComponent();

            DataOperation();
        }

        private async void DataOperation()
        {
            var message = _parseService.ParseMessage();
            if (message is null)
                return;

            List<MessageData> messageDataList = new();
            messageDataList.Add(message);
            messageGrid.ItemsSource = messageDataList;

            await _mediator.Send(new InsertMessageDataQuery(message));
        }
    }
}