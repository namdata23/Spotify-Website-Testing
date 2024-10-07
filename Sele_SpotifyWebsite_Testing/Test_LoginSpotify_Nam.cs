using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit;
using MimeKit;
using NUnit.Framework.Internal;
using System.Numerics;


namespace Sele_SpotifyWebsite_Testing
{
    [TestFixture]
    public class Test_LoginSpotify_Nam
    {
        public IWebDriver dr_Spo_Nam;
        protected WebDriverWait wait;
        [SetUp]
        public void SetUp()
        {
            dr_Spo_Nam = new ChromeDriver();
            dr_Spo_Nam.Manage().Window.Maximize();

            dr_Spo_Nam.Navigate().GoToUrl("https://open.spotify.com/");
            Thread.Sleep(3000);

        }

        public void TurnOffCookie()
        {
            // Đóng thông báo cookie nếu nó xuất hiện
            try
            {
                WebDriverWait wait = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));

                // Tạo hàm chờ để kiểm tra sự hiện diện và nhấp vào nút X
                IWebElement cookieCloseButton = wait.Until(driver =>
                {
                    IWebElement element = driver.FindElement(By.XPath("//*[@id=\"onetrust-close-btn-container\"]/button"));
                    return element.Displayed && element.Enabled ? element : null;
                });

                // Bấm vào nút nếu nó đã sẵn sàng
                cookieCloseButton.Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Thông báo cookie không xuất hiện.");
            }
        }

        [Test]
        public void DangNhapThanhCong_Spotify_Nam()
        {

            TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3500);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3000);
            element.Click();
            Thread.Sleep(2500);

            //Bấm vào nút button đăng nhập 
            dr_Spo_Nam.FindElement(By.CssSelector("[data-testid='login-button']")).Click();
            Thread.Sleep(2000);
            // Điền lần lượt vào ô Email và ô Password đã đăng ký
            dr_Spo_Nam.FindElement(By.Id("login-username")).SendKeys("namitwork23@gmail.com");
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.Id("login-password")).SendKeys("N_am020301");
            Thread.Sleep(2500);
            //Nhấn vào button Đăng nhập
            dr_Spo_Nam.FindElement(By.ClassName("Button-sc-qlcn5g-0")).Click();
            Thread.Sleep(3000);

        }
        
        [Test]
        public void DangNhapSaiMatKhau_Spotify_Nam()
        {
            TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3500);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3500);
            element.Click();
            Thread.Sleep(3000);

            //Bấm vào nút button đăng nhập 
            dr_Spo_Nam.FindElement(By.CssSelector("[data-testid='login-button']")).Click();
            Thread.Sleep(2500);
            // Điền lần lượt vào ô Email đăng ký và ô Password sai
            dr_Spo_Nam.FindElement(By.Id("login-username")).SendKeys("namitwork23@gmail.com");
            dr_Spo_Nam.FindElement(By.Id("login-password")).SendKeys("oyeahh123");
            Thread.Sleep(3000);
            //Nhấn vào button Đăng nhập
            dr_Spo_Nam.FindElement(By.ClassName("Button-sc-qlcn5g-0")).Click();


            // Chờ và kiểm tra thông báo lỗi
            WebDriverWait wait_pass = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            IWebElement errorMessageElement = wait_pass.Until(driver => driver.FindElement(By.CssSelector("#root > div > div > div " +
                                                                                                        "> div > div.sc-gLXSEc.eZHyFP")));

            // Kiểm tra nếu thông báo lỗi xuất hiện
            Assert.IsTrue(errorMessageElement.Displayed, "Thông báo 'Incorrect username or password.'Không xuất hiện khi nhập mật khẩu sai.");

        }

        [Test]
        public void DangNhapSaiEmail_Spotify_Nam()
        {
            TurnOffCookie();                    
            //bấm chuyển đổi qua ngôn ngữ tiếng việt
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3500);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3500);
            element.Click();
            Thread.Sleep(3000);

            //Bấm vào nút button đăng nhập 
            dr_Spo_Nam.FindElement(By.CssSelector("[data-testid='login-button']")).Click();
            Thread.Sleep(2500);
            // Điền lần lượt vào ô Email chưa đăng ký và ô Password đúng
            dr_Spo_Nam.FindElement(By.Id("login-username")).SendKeys("namit123@gmail.com");
            dr_Spo_Nam.FindElement(By.Id("login-password")).SendKeys("N_am232323");
            Thread.Sleep(3000);
            //Nhấn vào button Đăng nhập
            dr_Spo_Nam.FindElement(By.ClassName("Button-sc-qlcn5g-0")).Click();

            // Chờ và kiểm tra thông báo lỗi
            WebDriverWait wait_Email = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            IWebElement errorMessageElement = wait_Email.Until(driver => driver.FindElement(By.CssSelector("#root > div > div > div " +
                                                                                                  "> div > div.sc-gLXSEc.eZHyFP")));

            // Kiểm tra nếu thông báo lỗi xuất hiện
            Assert.IsTrue(errorMessageElement.Displayed, "Thông báo 'Incorrect username or password.'Không xuất hiện khi nhập Email sai.");

        }

        [Test]
        public void DangNhapSaiEmailvsMatKhau_Spotify_Nam()
        {
            TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3500);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3500);
            element.Click();
            Thread.Sleep(3000);

            //Bấm vào nút button đăng nhập 
            dr_Spo_Nam.FindElement(By.CssSelector("[data-testid='login-button']")).Click();
            Thread.Sleep(2500);
            // Điền lần lượt vào ô Email và ô Password chưa đăng ký
            dr_Spo_Nam.FindElement(By.Id("login-username")).SendKeys("namit123@gmail.com");
            dr_Spo_Nam.FindElement(By.Id("login-password")).SendKeys("oyeahh123");
            Thread.Sleep(3000);
            //Nhấn vào button Đăng nhập
            dr_Spo_Nam.FindElement(By.ClassName("Button-sc-qlcn5g-0")).Click();

            // Chờ và kiểm tra thông báo lỗi
            WebDriverWait wait_Email = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            IWebElement errorMessageElement = wait_Email.Until(driver => driver.FindElement(By.CssSelector("#root > div > div > div" +
                                                                                                           " > div > div.sc-gLXSEc.eZHyFP")));

            // Kiểm tra nếu thông báo lỗi xuất hiện
            Assert.IsTrue(errorMessageElement.Displayed, "Thông báo 'Incorrect username or password.'Không xuất hiện khi nhập Email sai.");

        }

        [Test]
        public void DangNhapEmailEmpty_Spotify_Nam()
        {
            TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt vì trang mặc định ngôn ngữ là tiếng anh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3500);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3500);
            element.Click();
            Thread.Sleep(3000);

            //Bấm vào nút button đăng nhập 
            dr_Spo_Nam.FindElement(By.CssSelector("[data-testid='login-button']")).Click();
            Thread.Sleep(2500);

            // Nhập một giá trị tạm thời vào ô email
            IWebElement emailField = dr_Spo_Nam.FindElement(By.Id("login-username"));
            emailField.SendKeys("temp@example.com");
            Thread.Sleep(1000);

            // Xóa từng ký tự trong ô email => để có thể kiểm thử được thông báo lỗi của hệ thống về
            // việc phải điển thông tin tài khoản
            for (int i = 0; i < "temp@example.com".Length; i++)
            {
                emailField.SendKeys(Keys.Backspace);
                Thread.Sleep(100); // Đợi 100ms giữa mỗi lần xóa
            }

            // điền ô mật khẩu 
            dr_Spo_Nam.FindElement(By.Id("login-password")).SendKeys("N_am020302");
            Thread.Sleep(2000);
            //Nhấn vào button Đăng nhập
            dr_Spo_Nam.FindElement(By.ClassName("Button-sc-qlcn5g-0")).Click();

            // Chờ và kiểm tra thông báo lỗi
            WebDriverWait wait_warning = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(3));
            IWebElement errorMessageElement = wait_warning.Until(dr_Spo_Nam => dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/div" +
                                                                                              "/div/div/div[2]/div[1]/div[2]")));

            // Kiểm tra nếu thông báo lỗi xuất hiện
            Assert.IsTrue(errorMessageElement.Displayed, "Thông báo 'Please enter your Spotify username or email address.' Không xuất hiện !.");

        }

        [Test]
        public void DangNhapMatKhauEmpty_Spotify_Nam()
        {
            TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt vì trang mặc định ngôn ngữ là tiếng anh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3500);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3500);
            element.Click();
            Thread.Sleep(3000);

            //Bấm vào nút button đăng nhập 
            dr_Spo_Nam.FindElement(By.CssSelector("[data-testid='login-button']")).Click();
            Thread.Sleep(2500);
            // điền ô Email
            dr_Spo_Nam.FindElement(By.Id("login-username")).SendKeys("namitwork23@gmail.com");
            Thread.Sleep(2000);

            // Nhập một giá trị tạm thời vào ô password
            IWebElement passField = dr_Spo_Nam.FindElement(By.Id("login-password"));
            passField.SendKeys("pass_temp");
            Thread.Sleep(1000);

            // Xóa từng ký tự trong ô password => để có thể kiểm thử được thông báo lỗi của hệ thống về
            // việc phải điển thông tin mật khẩu
            for (int i = 0; i < "pass_temp".Length; i++)
            {
                passField.SendKeys(Keys.Backspace);
                Thread.Sleep(100); // Đợi 100ms giữa mỗi lần xóa
            }

            //Nhấn vào button Đăng nhập
            dr_Spo_Nam.FindElement(By.ClassName("Button-sc-qlcn5g-0")).Click();

            // Chờ và kiểm tra thông báo lỗi
            WebDriverWait wait_warning = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(3));
            IWebElement errorMessageElement = wait_warning.Until(dr_Spo_Nam => dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/div[1]/div[2]/div[3]")));

            // Kiểm tra nếu thông báo lỗi xuất hiện
            Assert.IsTrue(errorMessageElement.Displayed, "Thông báo 'Please enter your password.' Không xuất hiện !.");


        }

        // Tạo hàm xóa cho tài khoản và mật khẩu để kiểm tra thông báo cho 2 ô
        private void ClearField(IWebElement field, string content)
        {
            field.SendKeys(content);
            Thread.Sleep(1000);

            for (int i = 0; i < content.Length; i++)
            {
                field.SendKeys(Keys.Backspace);
                Thread.Sleep(100); // Đợi 100ms giữa mỗi lần xóa
            }
        }

        [Test]
        public void DangNhapEmailvsMatKhauEmpty_Spotify_Nam()
        {
            TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt vì trang mặc định ngôn ngữ là tiếng anh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3500);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3500);
            element.Click();
            Thread.Sleep(2500);

            //Bấm vào nút button đăng nhập 
            dr_Spo_Nam.FindElement(By.CssSelector("[data-testid='login-button']")).Click();
            Thread.Sleep(2500);
            // Xóa nội dung cả hai trường Email và Password
            IWebElement emailField = dr_Spo_Nam.FindElement(By.Id("login-username"));
            IWebElement passField = dr_Spo_Nam.FindElement(By.Id("login-password"));
            ClearField(emailField, "temp@example.com"); 
            ClearField(passField, "pass_temp");

            //Nhấn vào button Đăng nhập
            dr_Spo_Nam.FindElement(By.ClassName("Button-sc-qlcn5g-0")).Click();
            // kiểm tra thông báo lỗi
            IWebElement errorMessageElement1 = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"username-error\"]"));
            Assert.AreEqual("Please enter your Spotify username or email address.", errorMessageElement1.Text);

            

            IWebElement errorMessageElement2 = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"password-error\"]"));
            Assert.AreEqual("Please enter your password.", errorMessageElement2.Text);




        }



       
        [Test]
        public void KiemTraQuenMatKhau_Spotify_Nam()
        {
            TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt vì trang mặc định ngôn ngữ là tiếng anh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3000);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3000);
            element.Click();
            Thread.Sleep(2500);

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

            //Điền thông tin password mới
            dr_Spo_Nam.FindElement(By.Name("new_password")).SendKeys("N_am050501");
            Thread.Sleep(2500);
            // Xác nhận lại password mới nhập
            dr_Spo_Nam.FindElement(By.CssSelector("#confirm_password")).SendKeys("N_am050501");
            Thread.Sleep(2500);
            //nhấn nút tạo password
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div/main/section/div/form/button")).Click();
            Thread.Sleep(2500);
            // Click bắt đầu nghe nhạc để vào lại trang
            dr_Spo_Nam.FindElement(By.CssSelector("a[data-encore-id='buttonPrimary']")).Click();


        }





        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(2500);
            dr_Spo_Nam.Dispose();

        }

    }
}
