using OpenQA.Selenium;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sele_SpotifyWebsite_Testing
{
    [TestFixture]
    public class Test_LogoutSpotify_Nam

    {
        private IWebDriver dr_Spo_Nam;
        private Test_LoginSpotify_Nam loginTest;

        [SetUp]
        public void SetUp()
        {
            loginTest = new Test_LoginSpotify_Nam();
            loginTest.SetUp(); // Gọi hàm SetUp từ class Test_LoginSpotify_Nam
            dr_Spo_Nam = loginTest.dr_Spo_Nam; // Tái sử dụng driver từ class Test_LoginSpotify_Nam
        }

        [Test]
        public void DangXuatTaiKhoan()
        {
            
            loginTest.DangNhapThanhCong_Spotify_Nam(); // Gọi hàm đăng nhập từ class Test_LoginSpotify_Nam
           
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div.Root.centered-layout > div.ZQftYELq0aOsg6tPbVbV > div.jEMA2gVoLgPQqAFrPhFw > header > div.hV9v6y_uYwdAsoiOHpzk.contentSpacing > div.rwdnt1SmeRC_lhLVfIzg > button.Button-sc-1dqy6lx-0.kTFJuL.encore-text-body-medium-bold.encore-over-media-set.SFgYidQmrqrFEVh65Zrg")).Click();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"context-menu\"]/div/ul/li[5]")).Click();
            Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(4000);
            dr_Spo_Nam.Dispose();

        }


    }
}
