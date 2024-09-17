; Định nghĩa đường dẫn tệp
Local $filePath = "D:\Icon\Bongda.ico"

; Chờ để chắc chắn rằng File Explorer đã được mở và sẵn sàng
Sleep(2000)

; Gửi đường dẫn tệp vào ô tìm kiếm
Send($filePath)

; Nhấn Enter để mở tệp
Send("{ENTER}")

; Chờ một chút trước khi đóng File Explorer
Sleep(2000)

; Đóng File Explorer
WinClose("File Explorer")
