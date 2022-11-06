using ShoppoingAppTask.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppoingAppTask.Helpers
{
    [ContentProperty("Text")]
    public class TransTxtExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Text.Localize() ?? string.Empty;
        }
    }
}
