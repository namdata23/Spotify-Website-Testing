using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Sele_SpotifyWebsite_Testing
{


    [TestFixture]
    public class Test_AccountInfoManager_Nam
    {
        private IWebDriver dr_Spo_Nam;
        private Test_LoginSpotify_Nam accManager;

        [SetUp]
        public void SetUp()
        {
            accManager = new Test_LoginSpotify_Nam();
            accManager.SetUp(); // Gọi hàm SetUp từ class Test_LoginSpotify_Nam
            dr_Spo_Nam = accManager.dr_Spo_Nam; // Tái sử dụng driver từ class Test_LoginSpotify_Nam
        }

          [Test]
         public void EditProfile()
        {
          
            accManager.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);
            // nhấn vào biểu tượng avatar 
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.wp7mZFPzV7Qmo51F0NA_ > div.VUXMMFKWudUWE1kIXZoS.rwdnt1SmeRC_lhLVfIzg > button.Button-sc-1dqy6lx-0.kTFJuL.encore-text-body-medium-bold.KAq2kDjXj2VS4eXrFL4i")).Click();
            Thread.Sleep(2000);
            // Hồ sơ (Profile)
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[20]/div/div/ul/li[2]")).Click();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.ClassName("wCkmVGEQh3je1hrbsFBY")).Click();
            Thread.Sleep(2000);
            // kịch bản 1: Đổi tên lại tài khoản người dùng
            IWebElement rename = dr_Spo_Nam.FindElement(By.Id("user-edit-name"));
            rename.Click();
            Thread.Sleep(2000);
            rename.Clear();
            rename.SendKeys("Nam IT");
            Thread.Sleep(2000);
            // nhấn nút Lưu
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[3]/button")).Click();
            Thread.Sleep(2000);

            // kịch bản 2 : cập nhật ảnh đại diện
            dr_Spo_Nam.FindElement(By.ClassName("wCkmVGEQh3je1hrbsFBY")).Click();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[1]/div/div[2]")).Click();
            Thread.Sleep(2000);

            // click vào chọn ảnh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[1]/div/div[2]/button[1]/span")).Click();
            Thread.Sleep(5000);

            // Dùng AutoIt để mở file explorer
            Process.Start(@"D:\Sele_SpotifyWebsite_Testing\FolderPic_Autoit\filepic.exe");
            Thread.Sleep(8000);

            // Nhấn lưu
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[3]/button")).Click();

            Thread.Sleep(3000);     
            // kịch bản 3 : Xóa ảnh mới đổi và cập nhật lại ảnh ban đầu
            dr_Spo_Nam.FindElement(By.ClassName("wCkmVGEQh3je1hrbsFBY")).Click();
            Thread.Sleep(2500);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[1]/div/div[2]")).Click();
            Thread.Sleep(3000);

            // click xóa ảnh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[1]/div/div[2]/button[2]/span")).Click();
            Thread.Sleep(2500);

            // click chọn lại ảnh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[1]/div/div[2]/button[1]/span")).Click();
            Thread.Sleep(5000);

            // Thực hiện lại autoit để mở file explorer
            Process.Start(@"D:\Sele_SpotifyWebsite_Testing\FolderPic_Autoit\filepic2.exe");
            Thread.Sleep(9000);

            // Nhấn lưu
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[3]/button")).Click();

        }

        [Test]
        public void NotifiChangeAvatar ()
        {
            accManager.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);
            // nhấn vào biểu tượng avatar 
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.wp7mZFPzV7Qmo51F0NA_ > div.VUXMMFKWudUWE1kIXZoS.rwdnt1SmeRC_lhLVfIzg > button.Button-sc-1dqy6lx-0.kTFJuL.encore-text-body-medium-bold.KAq2kDjXj2VS4eXrFL4i")).Click();
            Thread.Sleep(2000);
            // Hồ sơ (Profile)
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[20]/div/div/ul/li[2]")).Click();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.ClassName("wCkmVGEQh3je1hrbsFBY")).Click();
            Thread.Sleep(2000);

            //kịch bản 1 : Chọn ảnh không phù hợp với loại ảnh (chỉ dùng ảnh PNG hoặc JPG )
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[1]/div/div[2]")).Click();
            Thread.Sleep(2000);
            // click vào chọn ảnh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[1]/div/div[2]/button[1]/span")).Click();
            Thread.Sleep(5000);
            // Dùng AutoIt để mở file explorer
            Process.Start(@"D:\Sele_SpotifyWebsite_Testing\FolderPic_Autoit\wrongtype.exe");
            Thread.Sleep(8000);
            // Chờ cảnh báo xuất hiện
            WebDriverWait wait = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(5));
            IWebElement warningMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[22]/div/div/div/div[2]/div")));

            // In ra nội dung của warningMessage.Text để kiểm tra
           // Console.WriteLine("Thông báo thực tế: " + warningMessage.Text);

            // Thông báo mong đợi
            string expectedMessage = "Tệp bạn chọn không được hỗ trợ. Vui lòng chọn tệp JPG hoặc PNG.";

            // Sử dụng Assert.AreEqual để so sánh thông báo thực tế với thông báo mong đợi
            Assert.AreEqual(expectedMessage, warningMessage.Text, "Cảnh báo không khớp với thông báo mong đợi.");

            // kịch bản 2 : Chọn ảnh không đủ kích thước yêu cầu của hệ thống tối thiểu 300*300
            Thread.Sleep(2500);
            // click vào chọn ảnh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/form/div[1]/div/div[2]/button[1]/span")).Click();
            Thread.Sleep(5000);
            // Dùng AutoIt để mở file explorer
            Process.Start(@"D:\Sele_SpotifyWebsite_Testing\FolderPic_Autoit\wrongsize.exe");
            Thread.Sleep(8000);
            // Chờ cảnh báo xuất hiện
            WebDriverWait wait2 = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(5));
            IWebElement warningMessage2 = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[22]/div/div/div/div[2]/div")));
            // Thông báo mong đợi
            string expectedMessage2 = "Hình ảnh quá nhỏ. Hình ảnh phải có kích thước tối thiểu 300x300.";

            // Sử dụng Assert.AreEqual để so sánh thông báo thực tế với thông báo mong đợi
            Assert.AreEqual(expectedMessage2, warningMessage2.Text, "Cảnh báo không khớp với thông báo mong đợi.");


        }
        [Test]  
        public void TestChangeUserLanguage()
        {
            accManager.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);
            // nhấn vào biểu tượng avatar 
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.wp7mZFPzV7Qmo51F0NA_ > div.VUXMMFKWudUWE1kIXZoS.rwdnt1SmeRC_lhLVfIzg > button.Button-sc-1dqy6lx-0.kTFJuL.encore-text-body-medium-bold.KAq2kDjXj2VS4eXrFL4i")).Click() ;
            //Cài đặt
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[20]/div/div/ul/li[4]")).Click();
            Thread.Sleep(2000);
            //click vào phần chọn ngôn ngữ

            // Đổi sang Tiếng Anh
            dr_Spo_Nam.FindElement(By.Id("desktop.settings.selectLanguage")).Click();
            Thread.Sleep(2000);

            IWebElement englishOption = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"desktop.settings.selectLanguage\"]/option[2]"));
            if (englishOption.Displayed && englishOption.Enabled)
            {
                englishOption.Click();
            }
            
            WebDriverWait wait = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            IWebElement reloadButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("[data-encore-id='buttonSecondary']")));
            reloadButton.Click();
            Thread.Sleep(3000);
            
            // Đổi sang Tiếng Đức
            dr_Spo_Nam.FindElement(By.Id("desktop.settings.selectLanguage")).Click();
            Thread.Sleep(2000);

            IWebElement germanOption = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"desktop.settings.selectLanguage\"]/option[17]"));
            if (germanOption.Displayed && germanOption.Enabled)
            {
                germanOption.Click();
            }

            WebDriverWait wait2 = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            IWebElement reloadButton2 = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("[data-encore-id='buttonSecondary']")));
            reloadButton2.Click();
            Thread.Sleep(3000);

            // Đổi về Tiếng Việt
            dr_Spo_Nam.FindElement(By.Id("desktop.settings.selectLanguage")).Click();
            Thread.Sleep(2000);

            IWebElement vietnameseOption = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"desktop.settings.selectLanguage\"]/option[71]"));
            if (vietnameseOption.Displayed && vietnameseOption.Enabled)
            {
                vietnameseOption.Click();
            }

            WebDriverWait wait3 = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            IWebElement reloadButton3 = wait3.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("[data-encore-id='buttonSecondary']")));
            reloadButton3.Click();
            


        }
        [Test]
        public void AccountSection()
        {
            
            accManager.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);
            //nhấn vào avatar
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.wp7mZFPzV7Qmo51F0NA_ > div.VUXMMFKWudUWE1kIXZoS.rwdnt1SmeRC_lhLVfIzg > button.Button-sc-1dqy6lx-0.kTFJuL.encore-text-body-medium-bold.KAq2kDjXj2VS4eXrFL4i")).Click();
            Thread.Sleep(2000);

            // Lấy ra window handle của trang hiện tại (trang cũ)
            string originalWindow = dr_Spo_Nam.CurrentWindowHandle;

            // Nhấn button Tài khoản
            dr_Spo_Nam.FindElement(By.XPath("//*[@id='context-menu']/div/ul/li[1]/button")).Click();

            Thread.Sleep(2000); // Chờ một chút để trang mới được mở

            // Lấy tất cả các window handles sau khi trang mới mở
            var allWindows = dr_Spo_Nam.WindowHandles;

            // Chuyển qua window mới (cửa sổ mới mở sau khi nhấn nút Tài khoản)
            foreach (string window in allWindows)
            {
                if (window != originalWindow)
                {
                    dr_Spo_Nam.SwitchTo().Window(window);
                    break;
                }
            }

            // Đóng trang cũ
            dr_Spo_Nam.SwitchTo().Window(originalWindow).Close();

            // Chuyển lại sang cửa sổ mới
            dr_Spo_Nam.SwitchTo().Window(allWindows[allWindows.Count - 1]);
            Thread.Sleep(2000);
            // Chờ và tìm phần tử "Chỉnh sửa hồ sơ" bằng LinkText
            dr_Spo_Nam.FindElement(By.LinkText("Chỉnh sửa hồ sơ")).Click();

            Thread.Sleep(2500);
            // chọn ô thay đổi giới tính
            // Tìm phần tử dropdown
            IWebElement genderDropdown = dr_Spo_Nam.FindElement(By.ClassName("Select-sc-3qvhho-0"));

            // Sử dụng Select để chọn giá trị
            SelectElement selectGender = new SelectElement(genderDropdown);

            // Chọn giới tính "Nam"
            selectGender.SelectByValue("FEMALE");
            Thread.Sleep(1000);
            // điền ngày sinh
            // Tìm phần tử input và xóa dữ liệu cũ
            IWebElement inputDay = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div[2]/article/section/form/section/div[5]/div[2]/div[1]/input"));
            inputDay.Clear(); // Xóa dữ liệu cũ

            // Nhập giá trị mới
            inputDay.SendKeys("15");

            Thread.Sleep(2500);

            // Tìm dropdown tháng
            IWebElement monthDropdown = dr_Spo_Nam.FindElement(By.Id("dob-month"));
            monthDropdown.Click();

            // Mở danh sách dropdown
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", monthDropdown);

            // Tạo đối tượng SelectElement để thao tác
            SelectElement selectMonth = new SelectElement(monthDropdown);
            Thread.Sleep(2000);

            // Lấy giá trị value tương ứng với tháng 5
            selectMonth.SelectByValue("may");

            Thread.Sleep(2000);
            // điền năm
            IWebElement inputYear = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div[2]/article/section/form/section/div[5]/div[2]/div[3]/input"));
            inputYear.Clear(); // Xóa dữ liệu cũ

            // Nhập giá trị mới
            inputYear.SendKeys("1999");

            Thread.Sleep(2000);

            //kiểm tra xem nó có đổi được bằng cách bấm lưu và nếu không thích đổi thì bấm Hủy
            //Và trở về trang giao diện của phần tài khoản
              dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/article/section/form/div/button")).Click();
           // dr_Spo_Nam.FindElement(By.LinkText("Hủy")).Click();
           
        }

        [Test]
        public void Notifi_ChangeNewPassword()
        {
            accManager.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);
            //nhấn vào avatar
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.wp7mZFPzV7Qmo51F0NA_ > div.VUXMMFKWudUWE1kIXZoS.rwdnt1SmeRC_lhLVfIzg > button.Button-sc-1dqy6lx-0.kTFJuL.encore-text-body-medium-bold.KAq2kDjXj2VS4eXrFL4i")).Click();
            Thread.Sleep(2000);

            // Lấy ra window handle của trang hiện tại (trang cũ)
            string originalWindow = dr_Spo_Nam.CurrentWindowHandle;

            // Nhấn button Tài khoản
            dr_Spo_Nam.FindElement(By.XPath("//*[@id='context-menu']/div/ul/li[1]/button")).Click();

            Thread.Sleep(2000); // Chờ một chút để trang mới được mở

            // Lấy tất cả các window handles sau khi trang mới mở
            var allWindows = dr_Spo_Nam.WindowHandles;

            // Chuyển qua window mới (cửa sổ mới mở sau khi nhấn nút Tài khoản)
            foreach (string window in allWindows)
            {
                if (window != originalWindow)
                {
                    dr_Spo_Nam.SwitchTo().Window(window);
                    break;
                }
            }

            // Đóng trang cũ
            dr_Spo_Nam.SwitchTo().Window(originalWindow).Close();

            // Chuyển lại sang cửa sổ mới
            dr_Spo_Nam.SwitchTo().Window(allWindows[allWindows.Count - 1]);
            Thread.Sleep(2000);
            // Click vào phần đổi mật khẩu
            dr_Spo_Nam.FindElement(By.LinkText("Đổi mật khẩu")).Click();
            Thread.Sleep(2000);

            //Kịch bản 1 : Kiểm tra các thông báo ở mục đổi mật khẩu
            
            // điền mật khẩu hiện tại
            IWebElement password_now = dr_Spo_Nam.FindElement(By.Name("old_password"));
            password_now.Click();
            Thread.Sleep(1500);
            password_now.SendKeys("N_am020305");
            Thread.Sleep(2000);
            //điển mật khẩu mới
            IWebElement password_new = dr_Spo_Nam.FindElement(By.Id("new_password"));
            password_new.Click();
            Thread.Sleep(1500);
            password_new.SendKeys("N_am020303");
            Thread.Sleep(2000);
            // điền ô xác nhận
            IWebElement confirm_password = dr_Spo_Nam.FindElement(By.CssSelector("#new_password_confirmation"));
            confirm_password.Click();
            Thread.Sleep(1500);
            confirm_password.SendKeys("N_am020303");
            Thread.Sleep(2000);
            // nhấn nút cài đặt mật khẩu mới
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div[2]/article/section/form/div[4]/button")).Click();
            
           
            //1.Thông báo cho người dùng về mật khẩu trước đây người dùng đã dùng rồi không thể dùng lại nữa ,
            // Nên hệ thống yêu cầu đặt tên mới

            // Chờ cảnh báo xuất hiện
            WebDriverWait wait = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(3));
            IWebElement warningMessage1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/article/section/form/div[2]/div[4]")));

            // Thông báo mong đợi của kiểm thử viên
            string expectedMessage1 = "Chọn mật khẩu mà bạn chưa từng dùng trước đây.";

            // Sử dụng Assert.AreEqual để so sánh thông báo thực tế với thông báo mong đợi
            Assert.AreEqual(expectedMessage1, warningMessage1.Text, "Cảnh báo không khớp với thông báo mong đợi.");
            Thread.Sleep(2000);

            //2.Thông báo cho người dùng nhập ở phần xác nhận mật khẩu không trùng khớp
            confirm_password.Clear();
            Thread.Sleep(1000);
            confirm_password.SendKeys("N_am020301");
            Thread.Sleep(2000);
            // nhấn nút cài đặt mật khẩu mới
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div[2]/article/section/form/div[4]/button")).Click();

            WebDriverWait wait2 = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(3));
            IWebElement warningMessage2 = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div[2]/article/section/form/div[3]/div[3]")));

            string expectedMessage2 = "Vui lòng xác minh mật khẩu của bạn.";
            Assert.AreEqual(expectedMessage2, warningMessage2.Text, "Cảnh báo không khớp với thông báo mong đợi.");
            Thread.Sleep(2000);

            // 3.Điền sai mật khẩu hiện tại để kiểm tra thông báo của hệ thống
            password_now.Clear();
            Thread.Sleep(1000);
            password_now.SendKeys("N_am020306");
            Thread.Sleep(2000);
            confirm_password.Clear();
            Thread.Sleep(1000);
            confirm_password.SendKeys("N_am020303");
            Thread.Sleep(2000);
            // nhấn nút cài đặt mật khẩu mới
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div[2]/article/section/form/div[4]/button")).Click();


            WebDriverWait wait3 = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(3));
            IWebElement warningMessage3 = wait3.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div[2]/article/section/form/div[1]/div[3]")));

            string expectedMessage3 = "Rất tiếc, mật khẩu không chính xác";
            Assert.AreEqual(expectedMessage3, warningMessage3.Text, "Cảnh báo không khớp với thông báo mong đợi.");
          

        }

        [Test]

        public void ChangePassSuccess()
        {
            accManager.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);
            //nhấn vào avatar
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.wp7mZFPzV7Qmo51F0NA_ > div.VUXMMFKWudUWE1kIXZoS.rwdnt1SmeRC_lhLVfIzg > button.Button-sc-1dqy6lx-0.kTFJuL.encore-text-body-medium-bold.KAq2kDjXj2VS4eXrFL4i")).Click();
            Thread.Sleep(2000);

            // Lấy ra window handle của trang hiện tại (trang cũ)
            string originalWindow = dr_Spo_Nam.CurrentWindowHandle;

            // Nhấn button Tài khoản
            dr_Spo_Nam.FindElement(By.XPath("//*[@id='context-menu']/div/ul/li[1]/button")).Click();

            Thread.Sleep(2000); // Chờ một chút để trang mới được mở

            // Lấy tất cả các window handles sau khi trang mới mở
            var allWindows = dr_Spo_Nam.WindowHandles;

            // Chuyển qua window mới (cửa sổ mới mở sau khi nhấn nút Tài khoản)
            foreach (string window in allWindows)
            {
                if (window != originalWindow)
                {
                    dr_Spo_Nam.SwitchTo().Window(window);
                    break;
                }
            }

            // Đóng trang cũ
            dr_Spo_Nam.SwitchTo().Window(originalWindow).Close();

            // Chuyển lại sang cửa sổ mới
            dr_Spo_Nam.SwitchTo().Window(allWindows[allWindows.Count - 1]);
            Thread.Sleep(2000);
            // Click vào phần đổi mật khẩu
            dr_Spo_Nam.FindElement(By.LinkText("Đổi mật khẩu")).Click();
            Thread.Sleep(2000);

            // điền mật khẩu hiện tại
            IWebElement password_now = dr_Spo_Nam.FindElement(By.Name("old_password"));
            password_now.Click();
            Thread.Sleep(1500);
            password_now.SendKeys("N_am020305");
            Thread.Sleep(2000);
            //điển mật khẩu mới
            IWebElement password_new = dr_Spo_Nam.FindElement(By.Id("new_password"));
            password_new.Click();
            Thread.Sleep(1500);
            password_new.SendKeys("N_am020301");
            Thread.Sleep(2000);
            // điền ô xác nhận
            IWebElement confirm_password = dr_Spo_Nam.FindElement(By.CssSelector("#new_password_confirmation"));
            confirm_password.Click();
            Thread.Sleep(1500);
            confirm_password.SendKeys("N_am020301");
            Thread.Sleep(2000);
            // nhấn nút cài đặt mật khẩu mới
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div[2]/article/section/form/div[4]/button")).Click();


        }

        [Test]
        public void RestorePlaylists()
        {
            accManager.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);
            //nhấn vào avatar
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.wp7mZFPzV7Qmo51F0NA_ > div.VUXMMFKWudUWE1kIXZoS.rwdnt1SmeRC_lhLVfIzg > button.Button-sc-1dqy6lx-0.kTFJuL.encore-text-body-medium-bold.KAq2kDjXj2VS4eXrFL4i")).Click();
            Thread.Sleep(2000);

            // Lấy ra window handle của trang hiện tại (trang cũ)
            string originalWindow = dr_Spo_Nam.CurrentWindowHandle;

            // Nhấn button Tài khoản
            dr_Spo_Nam.FindElement(By.XPath("//*[@id='context-menu']/div/ul/li[1]/button")).Click();

            Thread.Sleep(2000); // Chờ một chút để trang mới được mở

            // Lấy tất cả các window handles sau khi trang mới mở
            var allWindows = dr_Spo_Nam.WindowHandles;

            // Chuyển qua window mới (cửa sổ mới mở sau khi nhấn nút Tài khoản)
            foreach (string window in allWindows)
            {
                if (window != originalWindow)
                {
                    dr_Spo_Nam.SwitchTo().Window(window);
                    break;
                }
            }

            // Đóng trang cũ
            dr_Spo_Nam.SwitchTo().Window(originalWindow).Close();

            // Chuyển lại sang cửa sổ mới
            dr_Spo_Nam.SwitchTo().Window(allWindows[allWindows.Count - 1]);
            Thread.Sleep(2000);
            // click vào khôi phục danh sách
            dr_Spo_Nam.FindElement(By.LinkText("Khôi phục danh sách phát")).Click();
            Thread.Sleep(1500);
            //chọn mục nào muốn khôi phục
            dr_Spo_Nam.FindElement(By.CssSelector("button[data-testid='playlist-restore']")).Click();
            Thread.Sleep(1500);
            //click vào biểu tưởng Spotify để về trang chủ để xem nó được khôi phục hay chưa
            dr_Spo_Nam.FindElement(By.ClassName("mh-header-primary")).Click();
            Thread.Sleep(2000);

        }



        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(4000);
            dr_Spo_Nam.Dispose(); // giúp đóng trình duyệt sau mỗi lần trường hợp kiểm thử hoành thành

        }

    }
}
