using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder
{
    public partial class UpdateApplicationPage : Page
    {
        public UpdateApplicationPage()
        {
            InitializeComponent();

            TitleUpDateTextBlock.Text =
                $"- Исправлена ошибка при изменении данных о сотруднике;\n" +
                $"- Исправлена ошибка при добавлении сотрудника;\n" +
                $"- Добавлена капча;\n" +
                $"- Изменён дизайн на более яркий;\n" +
                $"- Добавлена данная страница;\n" +
                $"- Сделан код более читаемый;\n" +
                $"- Улучшина производительность приложения.";
        }
    }
}
