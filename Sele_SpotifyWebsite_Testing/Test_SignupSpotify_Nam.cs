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
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3000);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3000);
            element.Click();
            Thread.Sleep(2000);
            //Bấm vào nút button đăng ký
            dr_Spo_Nam.FindElement(By.ClassName("glbdel")).Click();
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
            Thread.Sleep(2000);

            dr_Spo_Nam.FindElement(By.Id("username")).SendKeys("namitwork23gmail.com");
            dr_Spo_Nam.FindElement(By.ClassName("VsdHm")).Click();
            Thread.Sleep(2000);
            IWebElement warnEmail2 = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/main/main/section/div/form/div/div/div/div[2]/div[1]"));
            Assert.AreEqual("This email is invalid. Make sure it's written like example@email.com", warnEmail2.Text);

        }

        [Test]  
        public void DangKyThanhCong()
        {
            
            signupTest.TurnOffCookie();
            //bấm chuyển đổi qua ngôn ngữ tiếng việt vì trang mặc định ngôn ngữ là tiếng anh
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[2]/div[2]/button")).Click();
            Thread.Sleep(3000);
            IWebElement element = dr_Spo_Nam.FindElement(By.Id("vi"));
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3000);
            element.Click();
            Thread.Sleep(2000);
            //Bấm vào nút button đăng ký
            dr_Spo_Nam.FindElement(By.ClassName("glbdel"))
                                                  .Click();
            Thread.Sleep(2500);

            //điền thông tin email chưa dùng vào ô đăng ký của trang web
            dr_Spo_Nam.FindElement(By.Id("username")).SendKeys("zaachcafe@gmail.com");
            Thread.Sleep(2000);
            //nhấn nút Next
            dr_Spo_Nam.FindElement(By.ClassName("VsdHm")).Click();
            Thread.Sleep(2500);
            //điền vào ô tạo mật khẩu cho tài khoản
            dr_Spo_Nam.FindElement(By.Name("new-password")).SendKeys("cafe234455");
            Thread.Sleep(2000);
            // nhấn Next để tiếp tục
            dr_Spo_Nam.FindElement(By.ClassName("VsdHm")).Click();
            //điền vào ô đặt tên trong hồ sơ của mình
            Thread.Sleep(2500);
            dr_Spo_Nam.FindElement(By.CssSelector("input[id='displayName']")).SendKeys("caslos");
            //điền vào ô ngày sinh, chọn tháng, điền vào ô năm sinh
            Thread.Sleep(2500);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/main/main/section/div/form/div[1]/div[2]/div/section/div[3]/div[2]/div[2]/div/input[1]")).SendKeys("5");
            Thread.Sleep(2500);
            // Tìm dropdown tháng
            IWebElement monthDropdown = dr_Spo_Nam.FindElement(By.Id("month"));
            monthDropdown.Click();
            // Mở danh sách dropdown 
            ((IJavaScriptExecutor)dr_Spo_Nam).ExecuteScript("arguments[0].scrollIntoView(true);", monthDropdown);
            // Tạo đối tượng SelectElement để thao tác
           SelectElement selectMonth = new SelectElement(monthDropdown);
            Thread.Sleep(2000); 
            // Lấy giá trị value tương ứng với tháng 
            selectMonth.SelectByValue("4");

            Thread.Sleep(2500);
            // điền năm
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[1]/main/main/section/div/form/div[1]/div[2]/div/section/div[3]/div[2]/div[2]/div/input[2]")).SendKeys("2001");
            Thread.Sleep(2500);
            // chọn giới tính
            dr_Spo_Nam.FindElement(By.ClassName("jRuGOG")).Click();
            Thread.Sleep(2500);
            // nhấn Next để tiếp tục
            dr_Spo_Nam.FindElement(By.ClassName("VsdHm")).Click();
            Thread.Sleep(2500);
            // Click vào điều kiện mà người dùng muốn 
            dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"__next\"]/main/main/section/div/form/div[1]/div[2]/div/section/div[4]/div[1]/div/div/label/span[1]")).Click();
            Thread.Sleep(1500);
            // Nhấn vào nút Đăng ký
          //  dr_Spo_Nam.FindElement(By.CssSelector("#__next > main > main > section > div > form > div.sc-blcnQh.gXAYSM > button")).Click();

        }


        [TearDown]
        public void TearDown()
        {
           Thread.Sleep(4000);
           dr_Spo_Nam.Dispose(); // giúp đóng trình duyệt sau mỗi lần trường hợp kiểm thử hoành thành

        }

    }
}
