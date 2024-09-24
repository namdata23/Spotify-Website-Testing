using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[11]/div/div/div/div/button")).Click();

            // điền nội dung vào ô tìm kiếm
            IWebElement search_music = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/div[2]/div/span/div/form/div[2]/input"));
            search_music.Click();
            Thread.Sleep(1000);
            //kịch bản 1 : gợi ý vài từ của bài hát và xem hệ thống phản hồi 
            search_music.SendKeys("Love way");
            Thread.Sleep(1500);
            // chọn ngay mục đầu nếu đúng với lựa chọn của mình
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/div[2]/div/div/section[1]/div[2]/div/div/div/div[4]")).Click();
            Thread.Sleep(2000);

            // Đợi và nhấn vào nút play để nghe
            IWebElement play_music = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[3]/div[2]/div/div/div/button/span"));
            play_music.Click();
            Thread.Sleep(8000);
            // Kiểm tra nút bấm dừng phần nghe nhạc
            IWebElement stop_music = dr_Spo_Nam.FindElement(By.CssSelector("span.ButtonInner-sc-14ud5tc-0.cLkUmr"));
            stop_music.Click();
            Thread.Sleep(2000);

            //kịch bản 2 : tìm 1 album của một ca sĩ 
            search_music.Click();
            Thread.Sleep(1000);
            search_music.SendKeys("bật nó lên");
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/div[2]/div/div/section[1]/div[2]/div/div/div/div[4]")).Click();
            Thread.Sleep(2000);

            //kịch bản 3 : tra tìm tên của 1 người
            search_music.Click();
            Thread.Sleep(1000);
            search_music.SendKeys("post malone");
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/div[2]/div/div/section[1]/div[2]/div/div/div/div[4]")).Click();
            Thread.Sleep(2000);

           // kịch bản 4: Tìm kiếm bằng 1 ngôn ngữ khác(tiếng anh và tiếng việt)
            search_music.Click();
            Thread.Sleep(1000);
            search_music.SendKeys("我曾经遇见过一束光");
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/div[2]/div/div/section[1]/div[2]/div/div/div/div[4]")).Click();


        }

        [Test]
        public void CheckMeaningLessSeacrchInput()
        {
            search_Spotify.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);

            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[11]/div/div/div/div/button")).Click();
            // điền nội dung vào ô tìm kiếm
            IWebElement search_music = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/div[2]/div/span/div/form/div[2]/input"));
            search_music.Click();
            Thread.Sleep(1000);
            search_music.SendKeys("xyz123*&!");

            // Chờ kết quả tìm kiếm tải (sử dụng wait rõ ràng)
            WebDriverWait wait = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#searchPage > div > div > section.vKsgiy0W3aHYmZUlwHoQ.QyANtc_r7ff_tqrf5Bvc.Shelf > div.iKwGKEfAfW7Rkx2_Ba4E.Z4InHgCs2uhk0MU93y_a.deJGxfMNXUc8uApEGgoQ.nrVisibleCards-2.fJTotRs7ANTq1nrBwlqA " +
                                                        "> div > div > div > div.ouEZqTcvcvMfvezimm_J")));

            // Ghi lại nội dung kết quả tìm kiếm
            IWebElement result = dr_Spo_Nam.FindElement(By.CssSelector("#searchPage > div > div > section.vKsgiy0W3aHYmZUlwHoQ.QyANtc_r7ff_tqrf5Bvc.Shelf > div.iKwGKEfAfW7Rkx2_Ba4E.Z4InHgCs2uhk0MU93y_a.deJGxfMNXUc8uApEGgoQ.nrVisibleCards-2.fJTotRs7ANTq1nrBwlqA " +
                "> div > div > div > div.ouEZqTcvcvMfvezimm_J"));
            string resultText = result.Text;

            // Kiểm tra xem có bất kỳ kết quả liên quan nào được trả về hay không
            if (resultText.Contains("xyz123*&!") || resultText.Contains("suggestions") || resultText == "")
            {
                Console.WriteLine("Kiểm thử thất bại: Hệ thống trả về kết quả không liên quan và kết quả gợi ý.");
            }
            else
            {
                Console.WriteLine("Kiểm thử thành công: Không có kết quả liên quan nào được tìm thấy.");
            }

        }



        // Hàm để chuyển đổi giữa chế độ xem :  chế độ lưới
        public void SwitchToGridView()
        {
            // Xác định nút chế độ danh sách
            string listButtonXPath = "/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/section/div/div[1]/button[2]"; // nút list
            var listButton = dr_Spo_Nam.FindElement(By.XPath(listButtonXPath));

            // Kiểm tra trạng thái trước khi nhấp
            bool isListChecked = listButton.GetAttribute("aria-checked") == "true";

            if (isListChecked)
            {
                // Nếu đang ở chế độ danh sách, nhấp vào nút chế độ lưới
                string gridButtonXPath = "/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/section/div/div[1]/button[3]"; // nút grid
                var gridButton = dr_Spo_Nam.FindElement(By.XPath(gridButtonXPath));
                gridButton.Click();

                // Đợi để giao diện cập nhật
                Thread.Sleep(2000);

                // Kiểm tra trạng thái của nút lưới sau khi nhấp
                bool isGridChecked = gridButton.GetAttribute("aria-checked") == "true";
                Console.WriteLine("Grid button checked: " + isGridChecked);
            }
            else
            {
                Console.WriteLine("Currently not in list view, no action taken.");
            }
        }

        // Hàm để chuyển đổi giữa chế độ xem :  chế độ danh sách
        public void SwitchToListView()
        {
            // Xác định nút chế độ lưới
            string gridButtonXPath = "/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/section/div/div[1]/button[3]"; // nút grid
            var gridButton = dr_Spo_Nam.FindElement(By.XPath(gridButtonXPath));

            // Kiểm tra trạng thái trước khi nhấp
            bool isGridChecked = gridButton.GetAttribute("aria-checked") == "true";

            if (isGridChecked)
            {
                // Nếu đang ở chế độ lưới, nhấp vào nút chế độ danh sách
                string listButtonXPath = "/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/section/div/div[1]/button[2]"; // nút list
                var listButton = dr_Spo_Nam.FindElement(By.XPath(listButtonXPath));
                listButton.Click();

                // Đợi để giao diện cập nhật
                Thread.Sleep(2000);

                // Kiểm tra trạng thái của nút danh sách sau khi nhấp
                bool isListChecked = listButton.GetAttribute("aria-checked") == "true";
                Console.WriteLine("List button checked: " + isListChecked);
            }
            else
            {
                Console.WriteLine("Currently not in grid view, no action taken.");
            }
        }

        [Test]
        public void TestMusicControlsAndNavigation()
        {
            search_Spotify.DangNhapThanhCong_Spotify_Nam();
            Thread.Sleep(2000);
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[11]/div/div/div/div/button")).Click();

            IWebElement search_music = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/div[2]/div/span/div/form/div[2]/input"));
            search_music.SendKeys("Love way");
            Thread.Sleep(1800);
            // chọn ngay mục đầu nếu đúng với lựa chọn của mình
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/div[2]/div/div/section[1]/div[2]/div/div/div/div[4]")).Click();
            Thread.Sleep(2000);
            // Chọn link vào trang nghệ sĩ muốn tìm hiểu
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[4]/div[1]/div/div/div/div/div[1]/div")).Click();
            Thread.Sleep(2000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)dr_Spo_Nam;
            bool element_ShowAll = false;
            int scrollStep = 500; // mỗi lần kéo

            while (!element_ShowAll)
            {
                try
                {
                    // Tìm và cuộn đến phần tử "Hiện tất cả"
                    IWebElement showAllElement = dr_Spo_Nam.FindElement(By.LinkText("Hiện tất cả"));
                    js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", showAllElement);
                    Thread.Sleep(1500);

                    // Đợi cho phần tử có thể nhấp được và thực hiện nhấp
                    WebDriverWait wait_ShowAll = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
                    wait_ShowAll.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(showAllElement));

                    Thread.Sleep(1500);

                    // Click bằng JavaScript
                    js.ExecuteScript("arguments[0].click();", showAllElement);
                    element_ShowAll = true; // Dừng vòng lặp
                }
                catch (NoSuchElementException)
                {
                    // Cuộn xuống nếu chưa tìm thấy phần tử
                    js.ExecuteScript($"window.scrollBy(0, {scrollStep});");
                    Thread.Sleep(1500);
                }
                catch (ElementClickInterceptedException)
                {
                    // Xử lý lỗi click bị chặn bằng cách thực hiện lại việc cuộn và click
                    IWebElement showAllElement = dr_Spo_Nam.FindElement(By.LinkText("Hiện tất cả"));
                    js.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", showAllElement);
                    js.ExecuteScript("arguments[0].click();", showAllElement);
                    element_ShowAll = true; // Dừng vòng lặp
                }
            }

            Thread.Sleep(2000);


            //Chọn mục tất cả
            dr_Spo_Nam.FindElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.jEMA2gVoLgPQqAFrPhFw > div.main-view-container " +
                "> div.main-view-container__scroll-node > div:nth-child(2) > div > main > section > section > div > div.EvQHNTBhaU3rGCRRlAWj > button.w6j_vX6SF5IxSXrrkYw5")).Click();
            Thread.Sleep(1800);

            // Thêm WebDriverWait để đợi phần tử có thể click
            WebDriverWait wait = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(3));

            // Đợi đến khi phần tử "Album" sẵn sàng
            var albumElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[20]/div/ul/li[2]/button")));

            // Nhấn vào phần tử Album
            albumElement.Click();

            Thread.Sleep(1500);
            SwitchToGridView();
            Thread.Sleep(1500);
            //check đổi giao diện qua lại
            //SwitchToListView();

            // Chọn 1 album click vào 
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/section/div/div[2]/div[8]/div[1]")).Click();
            Thread.Sleep(2000);
            // Chọn 1 bài 
            var music_Song = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[4]/div[1]/div[2]/div[2]/div[5]/div"));
            Actions choose_musicsong = new Actions(dr_Spo_Nam);
            Thread.Sleep(2000);
            choose_musicsong.DoubleClick(music_Song).Perform();

            Thread.Sleep(5000);
            // Dừng nhạc
            IWebElement stop_music = dr_Spo_Nam.FindElement(By.CssSelector("span.ButtonInner-sc-14ud5tc-0.cLkUmr"));
            stop_music.Click();

            Thread.Sleep(2000);

            // Chọn element của nút quay lại
            By previousButtonSelector = By.CssSelector("button[data-testid='control-button-skip-back']");

            //Kiểm tra bấm nút trở về
            IWebElement previous_song_button = dr_Spo_Nam.FindElement(previousButtonSelector);
            // Click lần đầu để làm sáng nút
            previous_song_button.Click();

            // Đợi một thời gian ngắn để trạng thái nút cập nhật sau lần click đầu tiên
            Thread.Sleep(1000);

            // Click lần thứ hai để thực hiện hành động quay lại
            previous_song_button.Click();
            Thread.Sleep(5000);

            stop_music.Click();
            Thread.Sleep(2000);

            // Chọn element nút tiến
            By forwardButtonSelector = By.CssSelector("button[data-testid='control-button-skip-forward']");
            //Kiểm tra bấm nút tiến tới
            IWebElement forward_song_button = dr_Spo_Nam.FindElement(forwardButtonSelector);
            forward_song_button.Click();
            Thread.Sleep(5000);
            stop_music.Click();
            Thread.Sleep(2000);

            // xem giao diện phần danh sách chờ trước khi bấm nút trộn bài
            IWebElement wait_list = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[3]/footer/div/div[3]/div/div[1]/button"));
            wait_list.Click();
            Thread.Sleep(2000);
            wait_list.Click();
            // xem xong tắt đi để chuẩn bị coi xem các bài hát có được trộn sau khi bấm hay không

            // kiểm tra nút trộn bài kế tiếp bằng cách xem giao diện phần danh sách chờ
            IWebElement shuffle_button = dr_Spo_Nam.FindElement(By.CssSelector("button[data-testid='control-button-shuffle']"));
            shuffle_button.Click();
            Thread.Sleep(2000);
            // xem giao diện phần danh sách chờ sau khi bấm nút trộn bài
            wait_list.Click();
            Thread.Sleep(2000);
            shuffle_button.Click();// click thêm lần nữa để tắt chế độ trộn bài


            WebDriverWait wait_message = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));
            //click ô bỏ qua thông báo
            IWebElement checkbox = wait_message.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span.Indicator-sc-1airx73-0.bftgqn")));

            // Click vào ô tích
            checkbox.Click();
            Thread.Sleep(1500);

            // Bấm nút "Bỏ qua" xuất hiện
            dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[3]/footer/div[1]/div[3]/div/div[5]/div/div[1]/div/div/div[2]/div[2]/button")).Click();

            Thread.Sleep(1700);
            //kiểm tra phần chế độ xem : gồm bài hát đang phát và xem thông tin tác giả có trùng với thanh đang phát nhạc hay không
            IWebElement view_mode = dr_Spo_Nam.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/footer/div/div[3]/div/button[1]"));
            view_mode.Click();

            Thread.Sleep(2000);

            // nhấn theo dõi nếu thích họ
            IWebElement follow_btn = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[5]/div[1]/aside/div/div[2]/div[2]/div/div/div[2]/button/div[2]/div[2]/div[2]"));
            follow_btn.Click();
            // đợi xem nó có hiện lên mục thư viện chưa
            Thread.Sleep(2000);

            // nhấn thêm lần nữa để hủy theo dõi
            follow_btn.Click();
            Thread.Sleep(2000);
            // click tắt chế độ xem 
            view_mode.Click();

            //Kiểm tra nút lặp lại bài nhạc
            // trước hết chọn 1 bài để kiểm thử
            var musicSong = dr_Spo_Nam.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div[4]/div[1]/div[2]/div[2]/div/main/section/div[4]/div[1]/div[2]/div[2]/div[4]/div"));
            Actions choose_musicsong2 = new Actions(dr_Spo_Nam);
            Thread.Sleep(2000);
            choose_musicsong2.DoubleClick(musicSong).Perform();



            // click chế độ lặp lại
            // Tạo WebDriverWait để chờ cho phần tử sẵn sàng
            WebDriverWait wait_repeat = new WebDriverWait(dr_Spo_Nam, TimeSpan.FromSeconds(10));

            // Chờ cho nút lặp lại có thể nhấn được
            IWebElement repeat_button = wait_repeat.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid='control-button-repeat']")));

            // Nhấn vào nút chế độ lặp lại lần đầu tiên
            Actions repeatSong = new Actions(dr_Spo_Nam);
            repeatSong.Click(repeat_button).Perform();

            // Chờ 
            wait_repeat.Until(ExpectedConditions.ElementToBeClickable(repeat_button)); // Đảm bảo nút vẫn có thể nhấn được
            System.Threading.Thread.Sleep(2000); // Thay thế bằng chờ cho nút sẵn sàng nếu cần

            // Nhấn vào nút chế độ lặp lại lần thứ hai
            repeatSong.Click(repeat_button).Perform();

            int totalDurationInMilliseconds = 35000; // 35 giây ( thời gian bài hát đang phát )
            int waitTimeAfterSongEnds = 5000; // 5 giây

            // Chờ cho bài hát phát xong
            System.Threading.Thread.Sleep(totalDurationInMilliseconds);
            // Chờ thêm 5 giây sau lần phát thứ 2
            System.Threading.Thread.Sleep(waitTimeAfterSongEnds);


            // nhấn lần nữa để hủy chế độ và bấm dừng
            repeatSong.Click(repeat_button).Perform();
            Thread.Sleep(1500);
            stop_music.Click();


        }


        [TearDown]
        public void TearDown()
        {
            //Thread.Sleep(4000);
            //dr_Spo_Nam.Dispose();

        }

    }
}
