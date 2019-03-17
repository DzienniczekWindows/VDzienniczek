using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VulcanAPI;
using Tizen.Wearable.CircularUI.Forms;

namespace DzienniczekSharp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CirclePage
    {
        public string LoadingText { get; set; }

        public MainPage()
        {
            BindingContext = this;
            LoadingText = "Logging into Vulcan";
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5));

                var account = new VulcanAccount(new LoginConfig("fakelog.cf", "Default", "jan@fakelog.cf", "jan123", false));
                account.InitializeStudents();

                Device.BeginInvokeOnMainThread(() => {                    
                    Navigation.InsertPageBefore(new LuckyNumberPage($"Logged account with {account.Students.Count} students"), Navigation.NavigationStack[0]);
                    Navigation.PopToRootAsync(false);
                });
            });
        }
    }
}