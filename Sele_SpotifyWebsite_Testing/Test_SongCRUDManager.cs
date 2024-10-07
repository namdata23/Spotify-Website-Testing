using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sele_SpotifyWebsite_Testing
{

    [TestFixture]
    public class Test_SongCRUDManager
    {
        private IWebDriver dr_Spo_Nam;
        private Test_LoginSpotify_Nam crud_song;

        [SetUp]
        public void SetUp()
        {
            crud_song = new Test_LoginSpotify_Nam();
            crud_song.SetUp(); // Gọi hàm SetUp từ class Test_LoginSpotify_Nam
            dr_Spo_Nam = crud_song.dr_Spo_Nam; // Tái sử dụng driver từ class Test_LoginSpotify_Nam
        }

        [Test]
        public void Test_CRUDSongofPlaylist()
        {
            crud_song.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[11]/div/div/div/div/button")).Click();


            // Tìm phần tử trong thanh tìm kiếm (ví dụ một bài hát hoặc nút tạo danh sách phát)
            IWebElement libraryElement = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[1]/div[1]/header/div"));

            // Khởi tạo đối tượng Actions
            Actions actions = new Actions(dr_Spo_Nam);
            Thread.Sleep(1500);
            // Thực hiện chuột phải lên phần tử trong thanh tìm kiếm
            actions.ContextClick(libraryElement).Perform();
            Thread.Sleep(2000);
            //chọn tạo danh sách phát
            dr_Spo_Nam.FindElement(By.CssSelector("#context-menu > ul > li:nth-child(1) > button")).Click();
            Thread.Sleep(1500);

            //Kịch bản 1: Kiểm tra chức năng xóa danh sách phát     
            IWebElement more_Button = dr_Spo_Nam.FindElement(By.CssSelector("button[data-testid='more-button']"));
            more_Button.Click();
            Thread.Sleep(1500);
            //kiểm thử nút xóa danh sách phát
            dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"context-menu\"]/ul/li[4]/button")).Click();
            Thread.Sleep(1500);
            // TH1: kiểm tra nút hủy khi hiển thông báo xác nhận người dùng
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/div/button[1]")).Click();
            Thread.Sleep(1800);
            //TH2: kiểm tra nút "xác nhận" hủy trong thông báo 
            more_Button.Click();
            Thread.Sleep(1500);
            dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"context-menu\"]/ul/li[4]/button")).Click();
            Thread.Sleep(1500);
            //click chuột  xóa
            dr_Spo_Nam.FindElement(By.CssSelector("button[aria-label='Xóa Danh sách phát của tôi #3?']")).Click();
            Thread.Sleep(1500);

           // Kịch bản 2: Sửa thông tin bên trong danh sách phát nhạc
            actions.ContextClick(libraryElement).Perform();
            Thread.Sleep(2000);
            //chọn tạo danh sách phát
            dr_Spo_Nam.FindElement(By.CssSelector("#context-menu > ul > li:nth-child(1) > button")).Click();
            Thread.Sleep(1500);

            IWebElement more_Button_KB2 = dr_Spo_Nam.FindElement(By.CssSelector("button[data-testid='more-button']"));
            more_Button_KB2.Click();
            Thread.Sleep(1500);

            // chọn sửa thông tin
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[20]/div/ul/li[3]/button")).Click();
            Thread.Sleep(1500);
            // Phần điền thông tin 
            IWebElement playlistNameInput = dr_Spo_Nam.FindElement(By.CssSelector("input[data-testid='playlist-edit-details-name-input']"));
            // Xóa nội dung cũ
            playlistNameInput.Click();
            playlistNameInput.Clear();
            Thread.Sleep(1500);
            // Điền tên mới cho danh sách phát
            playlistNameInput.SendKeys("Old's sSongs");
            Thread.Sleep(1500);
            //Lưu
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[22]/div/div/div/div[2]/div[4]/button")).Click();
            Thread.Sleep(1500);

            //Kịch bản 3: Tìm và kiểm tra thêm bài hát vào danh sách phát sau đó xóa bài 
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[2]/nav/div/div[1]/div[2]/div[2]/div/div[2]/ul/div/div[2]/li[2]/div/div[1]")).Click();
            Thread.Sleep(1500);
            //Click vào ô tìm kiếm
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[2]/div[3]/div/section/div/div/input")).SendKeys("where are");
            Thread.Sleep(1500);
            //chọn ô thêm
            dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[2]/div[3]/div/div/div[1]/div/div[2]/div[1]/div/div[4]/button")).Click();
            Thread.Sleep(1500);
            //xóa nội dung trước 
            dr_Spo_Nam.FindElement(By.CssSelector("button.JzyZE2R09wq7xtjECDeR")).Click();
            Thread.Sleep(1500);
            // tìm bài hát tiếp
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[2]/div[3]/div/section/div/div/input")).SendKeys("alone");
            Thread.Sleep(1500);
            dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[2]/div[3]/div/div/div[1]/div/div[2]/div[1]/div/div[4]/button")).Click();
            Thread.Sleep(1500);
            // thêm bài nữa
            dr_Spo_Nam.FindElement(By.CssSelector("button.JzyZE2R09wq7xtjECDeR")).Click();
            Thread.Sleep(1500);
            // tìm bài hát tiếp
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[2]/div[3]/div/section/div/div/input")).SendKeys("glime");
            Thread.Sleep(1500);
            dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[2]/div[3]/div/div/div[1]/div/div[2]/div[1]/div/div[4]/button")).Click();
            Thread.Sleep(1500);
            // thêm bài nữa
            dr_Spo_Nam.FindElement(By.CssSelector("button.JzyZE2R09wq7xtjECDeR")).Click();
            Thread.Sleep(1500);
            // tìm bài hát tiếp
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[2]/div[3]/div/section/div/div/input")).SendKeys("cold");
            Thread.Sleep(1500);
            dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[2]/div[3]/div/div/div[1]/div/div[2]/div[1]/div/div[4]/button")).Click();
            Thread.Sleep(1500);

            // xóa bài hát ra khỏi danh sách
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[2]/div[3]/div/div[1]/div[2]/div[2]/div[3]/div/div[5]/button[2]")).Click();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[21]/div/ul/li[2]/button")).Click();
            // Thread.Sleep(1500);
            // bấm chọn nghe nhạc 
            // Tạo đối tượng Actions

            // Tìm phần tử số thứ tự của bài hát (ví dụ bài số 3)
            IWebElement songNumber = dr_Spo_Nam.FindElement(By.XPath("//span[contains(text(),'3')]"));

            // Di chuột vào số thứ tự bài hát để hiển thị nút phát
            Actions action_Play = new Actions(dr_Spo_Nam);
            action_Play.MoveToElement(songNumber).Perform();

            // Chờ cho nút phát nhạc xuất hiện sau khi di chuột
            WebDriverWait wait = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            IWebElement playButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@aria-label='Phát Cold Water (feat. Justin Bieber & MØ) của Major Lazer, Justin Bieber, MØ']")));

            // Click vào nút phát nhạc
            playButton.Click();
            Thread.Sleep(5000);

            //kiểm tra tắt nút nghe và sau đó bấm lại nghe 
            IWebElement listen_Button = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/footer/div/div[3]/div/div[3]/button"));
            listen_Button.Click(); // click để tắt
            Thread.Sleep(1500);
            listen_Button.Click(); // bấm lần nữa để nghe
            Thread.Sleep(1500);
            //kiểm tra nút nghe kéo lên xuống
            // Tìm phần tử điều khiển thanh âm lượng (progress bar)
            IWebElement volumeSlider = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[3]/footer/div/div[3]/div/div[3]/div/div/div"));

            // Khởi tạo đối tượng Actions để thao tác kéo và thả
            Actions scroll_action = new Actions(dr_Spo_Nam);

            // Kéo thanh âm lượng xuống một khúc (ví dụ kéo sang trái một đoạn)
            scroll_action.ClickAndHold(volumeSlider)
                   .MoveByOffset(-30, 0)  // Kéo sang trái (giảm âm lượng)
                   .Release()  // Nhả chuột
                   .Perform();

            Thread.Sleep(1700);

            // Kéo thanh âm lượng lên lại (ví dụ kéo sang phải một đoạn)
            scroll_action.ClickAndHold(volumeSlider)
                    .MoveByOffset(30, 0)  // Kéo sang phải (tăng âm lượng trở lại)
                    .Release()  // Nhả chuột
                    .Perform();

            Thread.Sleep(1500);
            // Dừng nhạc
            IWebElement stop_music = dr_Spo_Nam.FindElement(By.CssSelector("span.ButtonInner-sc-14ud5tc-0.cLkUmr"));
            stop_music.Click();
            Thread.Sleep(1500);
            // bấm nút stop lần nữa để phát
            stop_music.Click();
            Thread.Sleep(1500);
            //kiểm tra thanh bài hát cũng thử kéo lên xuống 
            // Tìm phần tử điều khiển thanh bài hát (progress bar)
            IWebElement songSlider = dr_Spo_Nam.FindElement(By.CssSelector("div[data-testid='progress-bar'][style*='--progress-bar-transform']"));

            // Lấy chiều dài thực tế của thanh tiến trình
            int sliderWidth = songSlider.Size.Width;  // Chiều rộng của thanh tiến trình

            // Khởi tạo đối tượng Actions để thao tác kéo và thả
            Actions scroll_Song = new Actions(dr_Spo_Nam);

            // Tính khoảng cách kéo sang phải (1/4 bài hát - tức 25%)
            int moveRight = (int)(sliderWidth * 0.25);  // 1/4 của chiều dài thanh

            // Kéo thanh tiến trình sang phải (1/4 bài hát)
            scroll_Song.ClickAndHold(songSlider)
                   .MoveByOffset(moveRight, 0)  // Kéo sang phải 1/4 chiều dài thanh
                   .Release()  // Nhả chuột
                   .Perform();

            // Tạm dừng 1,5s
            Thread.Sleep(1500);

            // Tính khoảng cách kéo sang trái (1/4 bài hát)
            int moveLeft = (int)(sliderWidth * -0.25);  // Kéo về lại 1/4

            // Kéo thanh tiến trình sang trái (1/4 bài hát)
            scroll_Song.ClickAndHold(songSlider)
                    .MoveByOffset(moveLeft, 0)  // Kéo sang trái 1/4 chiều dài thanh
                    .Release()  // Nhả chuột
                    .Perform();

            // Tạm dừng 1,5s
            Thread.Sleep(1500);

            // Thêm thao tác dừng nhạc sau đó nếu cần
            stop_music.Click();
            Thread.Sleep(1500);
            dr_Spo_Nam.Navigate().Refresh();
            Thread.Sleep(2000);

            // Kịch bản 4: Tra thử 1 bài và thêm vào danh sách mới tạo và danh sách cũ

            dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/div[2]/div/span/div/form/div[2]/input")).SendKeys("Eenie ");
            Thread.Sleep(2000);
            //click chọn
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/div[2]/div/div/section[2]/section/div[2]/div/div/div/div[2]/div[1]/div/div/div[1]/div[2]/a/div")).Click();
            Thread.Sleep(1700);
            // bấm thêm vào danh sách
            dr_Spo_Nam.FindElement(By.CssSelector("button[data-testid='more-button']")).Click();
            Thread.Sleep(1500);
            // Tìm phần tử "thêm vào danh sách" để rê chuột vào
            IWebElement menuItem = dr_Spo_Nam.FindElement(By.CssSelector("button.mWj8N7D_OlsbDgtQx5GW"));

            // Tạo đối tượng Actions để thực hiện các hành động chuột
            Actions actionAddtoPlaylist = new Actions(dr_Spo_Nam);

            // Di chuột vào phần tử
            actionAddtoPlaylist.MoveToElement(menuItem).Perform();

            Thread.Sleep(2000);
            // add vào danh sách cũ
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[20]/div/ul/li[1]/div/ul/div/li[4]/button/span")).Click();
            Thread.Sleep(2000);

            // bấm thêm vào danh sách
            dr_Spo_Nam.FindElement(By.CssSelector("button[data-testid='more-button']")).Click();
            Thread.Sleep(1500);
            IWebElement menuItemSecondTime = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[20]/div/ul/li[1]/button"));
            Actions actionAddtoPlaylist2 = new Actions(dr_Spo_Nam);

            // Di chuột vào phần tử
            actionAddtoPlaylist2.MoveToElement(menuItemSecondTime).Perform();
            Thread.Sleep(2000);
            //add vào danh sách mới
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[20]/div/ul/li[1]/div/ul/div/li[3]/button/span")).Click();
            // kiểm tra điều hướng back và forward của trang web
            Thread.Sleep(1500);
            dr_Spo_Nam.Navigate().Back();
            Thread.Sleep(2000);

            dr_Spo_Nam.Navigate().Forward();
            Thread.Sleep(1500);
            dr_Spo_Nam.Navigate().Refresh();


        }





        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(2500);
            dr_Spo_Nam.Dispose();

        }
    }
}
