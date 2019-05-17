using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAmazon.Pages;

namespace TestAmazon.Assembly
{
    class Pages
    {
        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(WebDriverFacade.getDriver, page);
            return page;
        }
        public static HomePage Home { get { return getPages<HomePage>(); } }
        public static SignInPage SignInPage { get { return getPages<SignInPage>(); } }
        public static SignUpPage SignUpPage { get { return getPages<SignUpPage>(); } }
    }
}
