using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sele_SpotifyWebsite_Testing
{

    [TestFixture]
    public class Test_SearchSpotify_Nam
    {
        private IWebDriver dr_Spo_Nam;
        private Test_LoginSpotify_Nam search_Spotify;

        [SetUp]
        public void SetUp()
        {
            search_Spotify = new Test_LoginSpotify_Nam();
            search_Spotify.SetUp(); // Gọi hàm SetUp từ class Test_LoginSpotify_Nam
            dr_Spo_Nam = search_Spotify.dr_Spo_Nam; // Tái sử dụng driver từ class Test_LoginSpotify_Nam
        }

        [Test]
        public void Test_SearchSpotify() 
        {
            search_Spotify.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(1500);
            // điền nội dung vào ô tìm kiếm
            IWebElement search_music = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/div[2]/div/span/div/form/div[2]/input"));
            search_music.Click();
            Thread.Sleep(1000);
            search_music.SendKeys("Love way");
            // chọn ngay mục đầu nếu đúng với lựa chọn của mình
            dr_Spo_Nam.FindElement(By.CssSelector("#searchPage > div > div > section.vKsgiy0W3aHYmZUlwHoQ.QyANtc_r7ff_tqrf5Bvc.Shelf " +
                "> div.iKwGKEfAfW7Rkx2_Ba4E.Z4InHgCs2uhk0MU93y_a.deJGxfMNXUc8uApEGgoQ.nrVisibleCards-2.fJTotRs7ANTq1nrBwlqA")).Click();
            Thread.Sleep(2000);
            // nhấn vào nút play để nghe
            dr_Spo_Nam.FindElement(By.ClassName("Button-sc-qlcn5g-0 dlTJiR")).Click();


        }




        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(4000);
            dr_Spo_Nam.Dispose();

        }

    }
}
