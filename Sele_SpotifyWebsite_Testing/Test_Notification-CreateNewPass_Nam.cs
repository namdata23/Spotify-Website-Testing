using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sele_SpotifyWebsite_Testing
{
    [TestFixture]
    public class Test_Notification_CreateNewPass_Nam
    {
        private IWebDriver dr_Spo_Nam;
        private Test_LoginSpotify_Nam check_noti;

        [SetUp]
        public void SetUp()
        {
            check_noti = new Test_LoginSpotify_Nam();
            check_noti.SetUp(); // Gọi hàm SetUp từ class Test_LoginSpotify_Nam
            dr_Spo_Nam = check_noti.dr_Spo_Nam; // Tái sử dụng driver từ class Test_LoginSpotify_Nam
        }


        public void RedirectToPasswordCreation()
        {
            check_noti.TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt vì trang mặc định ngôn ngữ là tiếng anh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3000);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3000);
            element.Click();
            Thread.Sleep(3000);

            //Bấm vào nút button đăng nhập 
            dr_Spo_Nam.FindElement(By.CssSelector("[data-testid='login-button']")).Click();
            Thread.Sleep(2500);
            //Click vào đường link" Forgot your password ?"
            dr_Spo_Nam.FindElement(By.LinkText("Forgot your password?")).Click();
            Thread.Sleep(4000);
            // Điền vào ô Email để xác nhận lấy lại mật khẩu 
            dr_Spo_Nam.FindElement(By.Id("email_or_username")).SendKeys("namitwork23@gmail.com");
            Thread.Sleep(2500);
            // Nhấn ô Send link để gửi
            dr_Spo_Nam.FindElement(By.CssSelector("button[data-encore-id='buttonPrimary']")).Click();

            // Kiểm tra xem có thông báo việc gửi mail cho người dùng hay không
            WebDriverWait wait_success = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            IWebElement MessageElement = wait_success.Until(driver => driver.FindElement(By.XPath("/html/body/div[1]/div/main/section/div/p")));

            // Kiểm tra nếu thông báo lỗi xuất hiện
            Assert.IsTrue(MessageElement.Displayed, "Thông báo 'We've sent you an email. Follow the instructions to access your Spotify account.' Không xuất hiện !.");

            // Mở tab mới 
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("window.open();");

            // tab cũ
            string currentTab = dr_Spo_Nam.CurrentWindowHandle;

            // Chuyển đến tab mới
            var tabs = dr_Spo_Nam.WindowHandles;
            dr_Spo_Nam.SwitchTo().Window(tabs[tabs.Count - 1]);



            // Đóng tab cũ
            dr_Spo_Nam.SwitchTo().Window(currentTab);
            dr_Spo_Nam.Close(); // Đóng tab cũ

            // Chuyển lại sang tab mới sau khi đóng tab cũ
            dr_Spo_Nam.SwitchTo().Window(tabs[tabs.Count - 1]);
            // Điều hướng đến đường link cần thiết

            dr_Spo_Nam.Navigate().GoToUrl("");
            Thread.Sleep(3500);

        }


        [Test]
        public void Test_Notification_CreateNewPass() 
        {
            RedirectToPasswordCreation();

            ////Kịch bản 1: Điền không đủ 10 ký tự
            dr_Spo_Nam.FindElement(By.Name("new_password")).SendKeys("N_am02030");
            Thread.Sleep(2000);
            //điền ô xác nhận lại mật khẩu
            dr_Spo_Nam.FindElement(By.CssSelector("#confirm_password")).SendKeys("N_am02030");
            Thread.Sleep(2500);
            //nhấn nút tạo password
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/main/section/div/form/button")).Click();
            // Kiểm tra thông báo cảnh báo cho mật khẩu không đủ 10 ký tự
            IWebElement errorMsg1 = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/main/section/div/form/div[1]/div[2]/ul/li[1]"));
            Assert.AreEqual("10 characters\r\nNot met", errorMsg1.Text);
            Thread.Sleep(2500);

            //  Kịch bản 2: Mật khẩu chỉ có số, không có chữ cái
            dr_Spo_Nam.FindElement(By.Name("new_password")).Clear(); // Xóa nội dung trước
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.Name("new_password")).SendKeys("1234567890"); // Mật khẩu chỉ có số
            dr_Spo_Nam.FindElement(By.CssSelector("#confirm_password")).Clear();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.CssSelector("#confirm_password")).SendKeys("1234567890"); // Điền vào ô xác nhận lại mật khẩu
            Thread.Sleep(2500);
            //nhấn nút tạo password
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/main/section/div/form/button")).Click();

            IWebElement errorMsg2 = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/main/section/div/form/div[1]/div[2]/ul/li[2]"));
            Assert.AreEqual("1 letter\r\nNot met", errorMsg2.Text);
            Thread.Sleep(2500);

            // Kịch bản 3: Mật khẩu chỉ có chữ, không có số hoặc ký tự đặc biệt
            dr_Spo_Nam.FindElement(By.Name("new_password")).Clear(); // Xóa nội dung trước
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.Name("new_password")).SendKeys("abcdefghij"); // Mật khẩu chỉ có chữ
            dr_Spo_Nam.FindElement(By.CssSelector("#confirm_password")).Clear();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.CssSelector("#confirm_password")).SendKeys("abcdefghij"); // Điền vào ô xác nhận lại mật khẩu
            Thread.Sleep(2500);
            //nhấn nút tạo password
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/main/section/div/form/button")).Click();

            IWebElement errorMsg3 = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/main/section/div/form/div[1]/div[2]/ul/li[3]"));
            Assert.AreEqual("1 number or special character (example: # ? ! &)\r\nNot met", errorMsg3.Text);

            ////Kịch bản 4 : Đồng bộ giữa nội dung điền ô mật khẩu và ô xác nhận có trùng khớp
            dr_Spo_Nam.FindElement(By.Name("new_password")).Clear(); // Xóa nội dung trước
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.Name("new_password")).SendKeys("N_am020305");
            dr_Spo_Nam.FindElement(By.CssSelector("#confirm_password")).Clear();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.CssSelector("#confirm_password")).SendKeys("N_am020306"); // Điền vào ô xác nhận lại mật khẩu khác nội dung ô password
            //nhấn nút tạo password
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/main/section/div/form/button")).Click();

            IWebElement errorMsg4 = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"__next\"]/div/main/section/div/form/div[2]/div[2]"));
            Assert.AreEqual("Please verify your password.", errorMsg4.Text);


        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(4000);
            dr_Spo_Nam.Dispose(); // giúp đóng trình duyệt sau mỗi lần trường hợp kiểm thử hoành thành

        }

    }
}
