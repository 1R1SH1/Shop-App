using Saving_InfoLog_ClassLibrary;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Shop_Wpf_App_Entity_Framework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InfoLog _log = new();
        private SavingMethod _savingInfoLogs = new();

        public event Action<string> Transaction;

        ShopDBEntities context = new ShopDBEntities();

        public MainWindow()
        {
            InitializeComponent();
            new Access().ShowDialog();
            Transaction += LogRepository_Transaction;
            LoadClients();
            cSelectClient.Items.Refresh();
            infoList.ItemsSource = _log.log;
        }

        private void LogRepository_Transaction(string message)
        {
            _log.AddToLog(message);
            infoList.Items.Refresh();
            _savingInfoLogs.SaveInfoLog(_log.log);
        }

        private void LoadClients()
        {
            context.Client.Load();
            cSelectClient.ItemsSource = context.Client.Local.ToBindingList<Clients>();
            cSelectClient.Items.Refresh();
        }

        private void MenuItem_Buy_OnClick(object sender, RoutedEventArgs e)
        {
            pBuy.IsOpen = true;
        }

        private void MenuItem_Purchases_OnClick(object sender, RoutedEventArgs e)
        {
            new AllView().ShowDialog();
        }

        private void MenuItem_Update_Client_Data_Click(object sender, RoutedEventArgs e)
        {
            pUpdateClient.IsOpen = true;
        }

        private void MenuItem_Add_Client_Click(object sender, RoutedEventArgs e)
        {
            pAddClient.IsOpen = true;
        }

        private void MenuItem_Delete_Client_Click(object sender, RoutedEventArgs e)
        {
            pDeleteClient.IsOpen = true;
        }

        private void MenuItem_Add_Electronic_Product_Click(object sender, RoutedEventArgs e)
        {
            pAddElectronicProduct.IsOpen = true;
        }

        private void MenuItem_Add_Space_Product_Click(object sender, RoutedEventArgs e)
        {
            pAddSpaceProduct.IsOpen = true;
        }

        private void MenuItem_Add_Food_Product_Click(object sender, RoutedEventArgs e)
        {
            pAddFoodProduct.IsOpen = true;
        }

        private void MenuItem_Delete_Electronic_Product_Click(object sender, RoutedEventArgs e)
        {
            pDeleteElectronicProduct.IsOpen = true;
        }

        private void MenuItem_Delete_Space_Product_Click(object sender, RoutedEventArgs e)
        {
            pDeleteSpaceProduct.IsOpen = true;
        }

        private void MenuItem_Delete_Food_Product_Click(object sender, RoutedEventArgs e)
        {
            pDeleteFoodProduct.IsOpen = true;
        }

        private void ClientList_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = (sender as ComboBox).SelectedItem;
            if (item != null)
            {
                ContextMenu cm = this.FindResource("CmButton") as ContextMenu;
                cm.PlacementTarget = sender as Button;
                cm.IsOpen = true;
            }
        }

        private void ProductsList_OnPreviewMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                ContextMenu cm = this.FindResource("CmButton") as ContextMenu;
                cm.PlacementTarget = sender as Button;
                cm.IsOpen = true;
            }
        }

        private void Button_SelectElectronics_Click(object sender, RoutedEventArgs e)
        {
            context.ElectronicsProducts.Load();
            productsList.ItemsSource = context.ElectronicsProducts.Local.ToBindingList<ElectronicsProducts>();
            productsList.Items.Refresh();
        }

        private void Button_SelectSpaceP_Click(object sender, RoutedEventArgs e)
        {
            context.SpaceProducts.Load();
            productsList.ItemsSource = context.SpaceProducts.Local.ToBindingList<SpaceProducts>();
            productsList.Items.Refresh();
        }

        private void Button_SelectFood_Click(object sender, RoutedEventArgs e)
        {
            context.FoodsProducts.Load();
            productsList.ItemsSource = context.FoodsProducts.Local.ToBindingList<FoodsProducts>();
            productsList.Items.Refresh();
        }

        private void Button_BuyIt_Click(object sender, RoutedEventArgs e)
        {
            if (productsList.SelectedItem is ElectronicsProducts)
            {
                var shopN = (productsList.SelectedItem as ElectronicsProducts).ProductName;
                var shopC = (productsList.SelectedItem as ElectronicsProducts).ProductCode;
                var buyer = (cSelectClient.SelectedItem as Clients).E_Mail;

                Purchases purchases = new()
                {
                    ProductName = shopN.ToString(),
                    ProductCode = shopC.ToString(),
                    E_Mail = buyer.ToString()
                };

                context.Purchases.Add(purchases);
                context.SaveChanges();
                Transaction?.Invoke($"Товар {shopN} куплен клиентом {buyer}");
                CleareTextBox();
            }
            if (productsList.SelectedItem is SpaceProducts)
            {
                var shopN = (productsList.SelectedItem as SpaceProducts).ProductName;
                var shopC = (productsList.SelectedItem as SpaceProducts).ProductCode;
                var buyer = (cSelectClient.SelectedItem as Clients).E_Mail;

                Purchases purchases = new()
                {
                    ProductName = shopN.ToString(),
                    ProductCode = shopC.ToString(),
                    E_Mail = buyer.ToString()
                };

                context.Purchases.Add(purchases);
                context.SaveChanges();
                Transaction?.Invoke($"Товар {shopN} куплен клиентом {buyer}");
                CleareTextBox();
            }
            if (productsList.SelectedItem is FoodsProducts)
            {
                var shopN = (productsList.SelectedItem as FoodsProducts).ProductName;
                var shopC = (productsList.SelectedItem as FoodsProducts).ProductCode;
                var buyer = (cSelectClient.SelectedItem as Clients).E_Mail;

                Purchases purchases = new()
                {
                    ProductName = shopN.ToString(),
                    ProductCode = shopC.ToString(),
                    E_Mail = buyer.ToString()
                };

                context.Purchases.Add(purchases);
                context.SaveChanges();
                Transaction?.Invoke($"Товар {shopN} куплен клиентом {buyer}");
                CleareTextBox();
            }
            pBuy.IsOpen = false;
        }

        private void Button_Ok_UpdateClientData(object sender, RoutedEventArgs e)
        {
            var name = (cSelectClient.SelectedItem as Clients).Name;
            Clients client = (from m in context.Client
                              where m.Name == name
                              select m).Single();
            client.Phone = New_Phone_txt.Text;
            context.SaveChanges();
            LoadClients();
            cSelectClient.Items.Refresh();
            Transaction?.Invoke($"№ телефона клиента {name} изменен на '{New_Phone_txt.Text}'");
            CleareTextBox();
            pUpdateClient.IsOpen = false;
        }

        private void Button_Ok_AddClient(object sender, RoutedEventArgs e)
        {
            Clients clients = new()
            {
                Name = Name_txt.Text,
                SurName = SurName_txt.Text,
                Patronymic = Patronymic_txt.Text,
                Phone = Phone_txt.Text,
                E_Mail = E_mail_txt.Text
            };

            context.Client.Add(clients);
            context.SaveChanges();
            LoadClients();
            cSelectClient.Items.Refresh();
            Transaction?.Invoke($"Клиент {Name_txt.Text} {SurName_txt.Text} {Patronymic_txt.Text} добавлен");
            CleareTextBox();
            pAddClient.IsOpen = false;
        }

        private void Button_Ok_DeleteClient(object sender, RoutedEventArgs e)
        {
            var clientName = (cSelectClient.SelectedItem as Clients).Name;
            int Id = (cSelectClient.SelectedItem as Clients).Id;
            var client = context.Client.Where(m => m.Id == Id).Single();
            context.Client.Remove(client);
            context.SaveChanges();
            LoadClients();
            cSelectClient.Items.Refresh();
            Transaction?.Invoke($"Клиент {clientName} удалён");
            CleareTextBox();
            pDeleteClient.IsOpen = false;
        }

        private void Button_Ok_AddElectronicProduct(object sender, RoutedEventArgs e)
        {
            ElectronicsProducts elProducts = new()
            {
                ProductName = ElProductName_txt.Text,
                ProductCode = ElProductNumber_txt.Text
            };

            context.ElectronicsProducts.Add(elProducts);
            context.SaveChanges();
            productsList.Items.Refresh();
            Transaction?.Invoke($"Товар {ElProductName_txt.Text} добавлен");
            CleareTextBox();
            pAddElectronicProduct.IsOpen = false;
        }

        private void Button_Ok_AddSpaceProduct(object sender, RoutedEventArgs e)
        {
            SpaceProducts spProducts = new()
            {
                ProductName = SpProductName_txt.Text,
                ProductCode = SpProductNumber_txt.Text
            };

            context.SpaceProducts.Add(spProducts);
            context.SaveChanges();
            productsList.Items.Refresh();
            Transaction?.Invoke($"Товар {SpProductName_txt.Text} добавлен");
            CleareTextBox();
            pAddSpaceProduct.IsOpen = false;
        }

        private void Button_Ok_AddFoodProduct(object sender, RoutedEventArgs e)
        {
            FoodsProducts foProducts = new()
            {
                ProductName = FoProductName_txt.Text,
                ProductCode = FoProductNumber_txt.Text
            };

            context.FoodsProducts.Add(foProducts);
            context.SaveChanges();
            productsList.Items.Refresh();
            Transaction?.Invoke($"Товар {FoProductName_txt.Text} добавлен");
            CleareTextBox();
            pAddFoodProduct.IsOpen = false;
        }

        private void Button_Ok_DeleteElectronicProduct(object sender, RoutedEventArgs e)
        {
            var pName = (productsList.SelectedItem as ElectronicsProducts).ProductName;
            int Id = (productsList.SelectedItem as ElectronicsProducts).Id;
            var product = context.ElectronicsProducts.Where(p => p.Id == Id).Single();
            context.ElectronicsProducts.Remove(product);
            context.SaveChanges();
            productsList.Items.Refresh();
            Transaction?.Invoke($"Продукт {pName} удалён");
            CleareTextBox();
            pDeleteElectronicProduct.IsOpen = false;
        }

        private void Button_Ok_DeleteSpaceProduct(object sender, RoutedEventArgs e)
        {
            var pName = (productsList.SelectedItem as SpaceProducts).ProductName;
            int Id = (productsList.SelectedItem as SpaceProducts).Id;
            var product = context.SpaceProducts.Where(p => p.Id == Id).Single();
            context.SpaceProducts.Remove(product);
            context.SaveChanges();
            productsList.Items.Refresh();
            Transaction?.Invoke($"Продукт {pName} удалён");
            CleareTextBox();
            pDeleteSpaceProduct.IsOpen = false;
        }

        private void Button_Ok_DeleteFoodProduct(object sender, RoutedEventArgs e)
        {
            var pName = (productsList.SelectedItem as FoodsProducts).ProductName;
            int Id = (productsList.SelectedItem as FoodsProducts).Id;
            var product = context.FoodsProducts.Where(p => p.Id == Id).Single();
            context.FoodsProducts.Remove(product);
            context.SaveChanges();
            productsList.Items.Refresh();
            Transaction?.Invoke($"Продукт {pName} удалён");
            CleareTextBox();
            pDeleteFoodProduct.IsOpen = false;
        }

        private void CleareTextBox()
        {
            Name_txt.Clear();
            SurName_txt.Clear();
            Patronymic_txt.Clear();
            Phone_txt.Clear();
            E_mail_txt.Clear();
            ElProductNumber_txt.Clear();
            ElProductName_txt.Clear();
            SpProductNumber_txt.Clear();
            SpProductName_txt.Clear();
            FoProductNumber_txt.Clear();
            FoProductName_txt.Clear();
            New_Phone_txt.Clear();
        }
    }
}
