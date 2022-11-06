using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppoingAppTask.Helpers
{
    public static class NavigationExtension
    {
        static bool working;

        public static async Task PushOnceAsync(this INavigation navigation, Page page)
        {
            if (working)
                return;
            working = true;
            if (!navigation.NavigationStack.Contains(page))
            {
                await navigation.PushAsync(page);
            }
            working = false;
        }

        public static async Task<Page> PopOnceAsync(this INavigation navigation)
        {
            if (!working && navigation.NavigationStack.Count > 1)
            {
                working = true;
                var page = await navigation.PopAsync();
                working = false;
                return page;
            }
            return null;
        }
    }
}
