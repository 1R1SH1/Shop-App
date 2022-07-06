using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Shop_Wpf_App_Entity_Framework
{
    /// <summary>
    /// Логика взаимодействия для AllView.xaml
    /// </summary>
    public partial class AllView : Window
    {
        ShopDBEntities context = new ShopDBEntities();
        public AllView()
        {
            InitializeComponent();
            LoadPurchases();
        }

        private void LoadPurchases()
        {
            context.Purchases.Load();
            gridAllView.ItemsSource = context.Purchases.Local.ToBindingList<Purchases>();
            gridAllView.ItemsSource = context.Purchases.ToList();
        }
    }
}
