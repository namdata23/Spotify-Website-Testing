# 🎵 Spotify Web Testing Documentation

## 📋 Mục lục
1. [Giới thiệu](#giới-thiệu)
2. [Phạm vi kiểm thử](#phạm-vi-kiểm-thử)
   - [1. Kiểm thử chức năng (Functional Testing)](#1-kiểm-thử-chức-năng-functional-testing)
   - [2. Kiểm thử giao diện thông báo (UI Notification Testing)](#2-kiểm-thử-giao-diện-thông-báo-ui-notification-testing)
   - [3. Kiểm thử hiệu năng (Performance Testing)](#3-kiểm-thử-hiệu-năng-performance-testing)
   - [4. Kiểm thử API (API Testing)](#4-kiểm-thử-api-api-testing)
3. [Công cụ sử dụng](#công-cụ-sử-dụng)
4. [Hướng dẫn chạy kiểm thử](#hướng-dẫn-chạy-kiểm-thử)
5. [Kết quả dự kiến](#kết-quả-dự-kiến)
6. [Ghi chú](#ghi-chú)

---

## 📘 Giới thiệu

Dự án này nhằm kiểm thử toàn diện trang web Spotify, bao gồm kiểm thử chức năng, giao diện thông báo, hiệu năng và API. Mục tiêu của kiểm thử là đảm bảo tất cả các thành phần của trang web hoạt động mượt mà, tương thích với nhiều môi trường khác nhau và đáp ứng được kỳ vọng của người dùng.

---

## 🚩 Phạm vi kiểm thử

### 1. Kiểm thử chức năng (Functional Testing)

#### 📌 Mục tiêu
Kiểm tra các tính năng cốt lõi của trang web Spotify, bao gồm:
- Đăng ký, đăng nhập tài khoản.
- Tìm kiếm nhạc, tạo playlist.
- Phát nhạc, dừng phát, tua nhanh/chậm.
- Cập nhật tài khoản người dùng, cài đặt tài khoản.
  
#### 🛠 Phương pháp
- Sử dụng kịch bản kiểm thử (test case) cho từng chức năng cụ thể.
- Kiểm tra các tình huống thành công và thất bại.
  
#### 📄 Danh sách test case
- Test Case 1: Đăng ký tài khoản mới.
- Test Case 2: Đăng nhập với tài khoản hợp lệ và không hợp lệ.
- Test Case 3: Tạo playlist và thêm bài hát vào playlist.
- Test Case 4: Phát nhạc từ playlist đã lưu.
- Test Case 5: Cập nhật thông tin cá nhân và kiểm tra thay đổi.

---

### 2. Kiểm thử giao diện thông báo (UI Notification Testing)

#### 📌 Mục tiêu
Đảm bảo các thông báo giao diện xuất hiện chính xác và đúng thời điểm:
- Thông báo thành công khi người dùng thực hiện các hành động như tạo playlist, đăng nhập thành công.
- Thông báo lỗi khi nhập sai thông tin, hoặc khi không thể phát nhạc.

#### 🛠 Phương pháp
- Kiểm tra trực quan bằng cách thực hiện các hành động và quan sát thông báo xuất hiện.
- Đảm bảo rằng thông báo rõ ràng, dễ hiểu và không che khuất các phần khác của trang web.

#### 📄 Danh sách test case
- Test Case 6: Thông báo khi đăng ký thành công.
- Test Case 7: Thông báo lỗi khi mật khẩu sai trong quá trình đăng nhập.
- Test Case 8: Thông báo khi thêm bài hát vào playlist thành công.

---

### 3. Kiểm thử hiệu năng (Performance Testing)

#### 📌 Mục tiêu
Kiểm tra tốc độ tải trang và thời gian phản hồi của trang web dưới các điều kiện khác nhau:
- Kiểm tra hiệu năng khi tải trang chủ.
- Đo lường thời gian phản hồi khi tìm kiếm nhạc, thêm bài hát vào playlist.
- Kiểm tra tải trọng tối đa mà trang web có thể xử lý.

#### 🛠 Phương pháp
- Sử dụng **JMeter** để tạo tải trọng mô phỏng nhiều người dùng truy cập cùng lúc.
- Đo lường thời gian phản hồi, dung lượng bộ nhớ, và mức độ sử dụng CPU khi tải trang.

#### 📄 Danh sách test case
- Test Case 9: Đo thời gian phản hồi khi tải trang chủ với 100 người dùng đồng thời.
- Test Case 10: Kiểm tra thời gian tải playlist với 50 bài hát.

---

### 4. Kiểm thử API (API Testing)

#### 📌 Mục tiêu
Đảm bảo các API của Spotify hoạt động chính xác:
- API đăng ký, đăng nhập.
- API tìm kiếm nhạc.
- API tạo và quản lý playlist.

#### 🛠 Phương pháp
- Sử dụng **JMeter** để gửi các yêu cầu HTTP tới API và kiểm tra phản hồi.
- Kiểm tra các tình huống thành công và thất bại.
  
#### 📄 Danh sách test case
- Test Case 11: Kiểm thử API đăng nhập với thông tin tài khoản hợp lệ.
- Test Case 12: Kiểm thử API tìm kiếm nhạc với từ khóa hợp lệ và không hợp lệ.
- Test Case 13: Kiểm thử API tạo playlist mới.

---

## 🛠 Công cụ sử dụng
- **Selenium**: Tự động hóa các kiểm thử chức năng và giao diện.
- **JMeter**: Đo lường hiệu năng và thực hiện kiểm thử API.
- **Browser DevTools**: Đo thời gian tải trang và phân tích hiệu suất.

---

## 🚀 Hướng dẫn chạy kiểm thử

### 1. Kiểm thử chức năng và giao diện
- Cài đặt Selenium và các thư viện liên quan.
- Chạy các test case qua file `Test_Function_Nam.cs`.

### 2. Kiểm thử hiệu năng và API
- Cài đặt **JMeter** và mở các file kịch bản:
  -  Kiểm thử hiệu năng.
  -  Kiểm thử API.

---

## 📊 Kết quả dự kiến

- Chức năng trang web hoạt động chính xác với các thao tác của người dùng.
- Giao diện thông báo hiển thị hợp lý, thân thiện và dễ hiểu.
- Trang web có thời gian phản hồi nhanh và ổn định khi tải nhạc và thực hiện các hành động khác.
- API phản hồi đúng dữ liệu với thời gian xử lý hợp lý và bảo mật.

---

## 📝 Ghi chú
- Kiểm thử được thực hiện trên môi trường trình duyệt Chrome.
- Đảm bảo kết nối mạng ổn định khi thực hiện kiểm thử hiệu năng và API.
