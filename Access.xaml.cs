using System;
using System.Windows;

namespace Shop_Wpf_App_Entity_Framework
{
    /// <summary>
    /// Логика взаимодействия для Access.xaml
    /// </summary>
    public partial class Access : Window
    {
        private ShopDBEntities context = new ShopDBEntities();
        public Access()
        {
            InitializeComponent();
        }

        private void btnGetAccess(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var user in context.Access)
                {
                    if (user.UserName.Replace(" ", "") == txtUsername.Text && user.Password.Replace(" ", "") == txtPassword.Password)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверное Имя или Пароль.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
