; Định nghĩa đường dẫn đến tệp ảnh
Local $filePath = "D:\Icon\background.png"

; Chờ cho cửa sổ chọn tệp hiện lên
WinWaitActive("Open")

; Gửi đường dẫn tệp
Send($filePath)

; Nhấn Enter để chọn tệp
Send("{ENTER}")

; Chờ một chút trước khi đóng cửa sổ chọn tệp
Sleep(2000)

; Đóng cửa sổ chọn tệp (nếu cần)
WinClose("Open")
