using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sele_SpotifyWebsite_Testing
{
    [TestFixture]
    public class Test_SignupSpotify_Nam
    {
        private IWebDriver dr_Spo_Nam;
        private Test_LoginSpotify_Nam signupTest;

        [SetUp]
        public void SetUp()
        {
            signupTest = new Test_LoginSpotify_Nam();
            signupTest.SetUp(); // Gọi hàm SetUp từ class Test_LoginSpotify_Nam
            dr_Spo_Nam = signupTest.dr_Spo_Nam; // Tái sử dụng driver từ class Test_LoginSpotify_Nam
        }

        [Test]
        public void Notifi_DangKyTaiKhoan()
        {
            signupTest.TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt vì trang mặc định ngôn ngữ là tiếng anh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[1]/nav/div[2]/div[2]/div[2]/button")).Click();
            Thread.Sleep(3000);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3000);
            element.Click();
            Thread.Sleep(2000);
            //Bấm vào nút button đăng ký
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.jEMA2gVoLgPQqAFrPhFw > header > div.hV9v6y_uYwdAsoiOHpzk.contentSpacing " +
                                                  "> div.rwdnt1SmeRC_lhLVfIzg > div.LKFFk88SIRC9QKKUWR5u > button.Button-sc-1dqy6lx-0.glbdel.encore-text-body-medium-bold.sibxBMlr_oxWTfBrEz2G"))
                                                  .Click();
            Thread.Sleep(2000);

            // Điền email vào -> Kịch bản 1 : Kiểm tra điền email đã đăng ký rồi để kiểm tra thông báo
            dr_Spo_Nam.FindElement(By.Id("username")).SendKeys("namitwork23@gmail.com");
            //nhấn nút Next
            dr_Spo_Nam.FindElement(By.ClassName("VsdHm")).Click();
            Thread.Sleep(2000);
            IWebElement warnEmail1 = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/main/main/section/div/form/div/div/div/div[2]/div[1]"));
            Assert.AreEqual("This address is already linked to an existing account. To continue, log in.", warnEmail1.Text);


            // Kịch bản 2 : Điền không đúng trường email và kiểm tra thông báo
            IWebElement emailField = dr_Spo_Nam.FindElement(By.Id("username")); // xóa nội dung trước để kiểm thử kịch bản 2
            emailField.SendKeys(Keys.Control + "a");
            emailField.SendKeys(Keys.Delete);
            Thread.Sleep(1000);

            dr_Spo_Nam.FindElement(By.Id("username")).SendKeys("namitwork23gmail.com");
            dr_Spo_Nam.FindElement(By.ClassName("VsdHm")).Click();
            Thread.Sleep(2000);
            IWebElement warnEmail2 = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/main/main/section/div/form/div/div/div/div[2]/div[1]"));
            Assert.AreEqual("This email is invalid. Make sure it's written like example@email.com", warnEmail2.Text);


        }
        [Test]
        public void DangKyThanhCong()
        {

        }


        [TearDown]
        public void TearDown()
        {
          //  Thread.Sleep(4000);
          //  dr_Spo_Nam.Dispose(); // giúp đóng trình duyệt sau mỗi lần trường hợp kiểm thử hoành thành

        }

    }
}
