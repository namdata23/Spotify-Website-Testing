using OpenQA.Selenium;
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


    }
}
