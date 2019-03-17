using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DzienniczekSharp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LuckyNumberPage : CirclePage
    {
        public string LuckyNumber { get; set; }

		public LuckyNumberPage(string luckynumber)
        {
            BindingContext = this;
            LuckyNumber = luckynumber;
			InitializeComponent();
		}
	}
}