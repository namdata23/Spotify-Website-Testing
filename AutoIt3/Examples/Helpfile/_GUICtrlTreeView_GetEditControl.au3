#include <Extras\WM_NOTIFY.au3>
#include <GUIConstantsEx.au3>
#include <GuiImageList.au3>
#include <GuiTreeView.au3>
#include <WindowsConstants.au3>

Global $g_hTreeView

Example()

Func Example()
	Local $hGui = GUICreate("TreeView Get Edit Control (v" & @AutoItVersion & ")", 400, 300)

	Local $iStyle = BitOR($TVS_EDITLABELS, $TVS_HASBUTTONS, $TVS_HASLINES, $TVS_LINESATROOT, $TVS_DISABLEDRAGDROP, $TVS_SHOWSELALWAYS, $TVS_CHECKBOXES)
	$g_hTreeView = _GUICtrlTreeView_Create($hGui, 2, 2, 396, 268, $iStyle, $WS_EX_CLIENTEDGE)
	GUISetState(@SW_SHOW)

	_WM_NOTIFY_Register()

	Local $hImage = _GUIImageList_Create(16, 16, 5, 3)
	_GUIImageList_AddIcon($hImage, "shell32.dll", 110)
	_GUIImageList_AddIcon($hImage, "shell32.dll", 131)
	_GUIImageList_AddIcon($hImage, "shell32.dll", 165)
	_GUIImageList_AddIcon($hImage, "shell32.dll", 168)
	_GUIImageList_AddIcon($hImage, "shell32.dll", 137)
	_GUIImageList_AddIcon($hImage, "shell32.dll", 146)
	_GUICtrlTreeView_SetNormalImageList($g_hTreeView, $hImage)

	Local $ahItem[6]
	For $x = 0 To _GUIImageList_GetImageCount($hImage) - 1
		$ahItem[$x] = _GUICtrlTreeView_Add($g_hTreeView, 0, StringFormat("[%02d] New Item", $x + 1), $x, $x)
	Next

	; Edit item 0 label
	_GUICtrlTreeView_EditText($g_hTreeView, $ahItem[0])
	Sleep(1000)
	_GUICtrlTreeView_EndEdit($g_hTreeView)

	; Loop until the user exits.
	Do
	Until GUIGetMsg() = $GUI_EVENT_CLOSE
	GUIDelete()
EndFunc   ;==>Example

Func WM_NOTIFY($hWnd, $iMsg, $wParam, $lParam)
	#forceref $hWnd, $iMsg, $wParam
	Local $hWndTreeview = $g_hTreeView
	If Not IsHWnd($g_hTreeView) Then $hWndTreeview = GUICtrlGetHandle($g_hTreeView)

	Local $tNMHDR = DllStructCreate($tagNMHDR, $lParam)
	Local $hWndFrom = HWnd(DllStructGetData($tNMHDR, "hWndFrom"))
	Local $iCode = DllStructGetData($tNMHDR, "Code")
	Switch $hWndFrom
		Case $hWndTreeview
			Switch $iCode
				Case $NM_CLICK ; The user has clicked the left mouse button within the control
					_WM_NOTIFY_DebugEvent("$NM_CLICK", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
					; Return 1 ; nonzero to not allow the default processing
					Return 0 ; zero to allow the default processing
				Case $NM_DBLCLK ; The user has double-clicked the left mouse button within the control
					_WM_NOTIFY_DebugEvent("$NM_DBLCLK", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
					; Return 1 ; nonzero to not allow the default processing
					Return 0 ; zero to allow the default processing
				Case $NM_RCLICK ; The user has clicked the right mouse button within the control
					_WM_NOTIFY_DebugEvent("$NM_RCLICK", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
					; Return 1 ; nonzero to not allow the default processing
					Return 0 ; zero to allow the default processing
				Case $NM_RDBLCLK ; The user has double-clicked the right mouse button within the control
					_WM_NOTIFY_DebugEvent("$NM_RDBLCLK", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
					; Return 1 ; nonzero to not allow the default processing
					Return 0 ; zero to allow the default processing
				Case $NM_KILLFOCUS ; control has lost the input focus
					_WM_NOTIFY_DebugEvent("$NM_KILLFOCUS", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
					; No return value
				Case $NM_RETURN ; control has the input focus and that the user has pressed the key
					_WM_NOTIFY_DebugEvent("$NM_RETURN", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
					; Return 1 ; nonzero to not allow the default processing
					Return 0 ; zero to allow the default processing
;~ 				Case $NM_SETCURSOR ; control is setting the cursor in response to a WM_SETCURSOR message
;~ 					_WM_NOTIFY_DebugEvent("$NM_SETCURSOR", $tagNMMOUSE, $lParam, "IDFrom,,ItemSpec,ItemData,X,Y,HitInfo")
;~ 					Return 0 ; to enable the control to set the cursor
;~ 					; Return 1 ; nonzero to prevent the control from setting the cursor
				Case $NM_SETFOCUS ; control has received the input focus
					_WM_NOTIFY_DebugEvent("$NM_SETFOCUS", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
					; No return value
				Case $TVN_BEGINDRAGA, $TVN_BEGINDRAGW
					_WM_NOTIFY_DebugEvent("$TVN_BEGINDRAG", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_BEGINLABELEDITA, $TVN_BEGINLABELEDITW
					_WM_NOTIFY_DebugEvent("$TVN_BEGINLABELEDIT", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
					ConsoleWrite("Edit Control Handle: 0x" & Hex(_GUICtrlTreeView_GetEditControl($g_hTreeView)) & @CRLF & _
							"IsPtr = " & IsPtr(_GUICtrlTreeView_GetEditControl($g_hTreeView)) & " IsHWnd = " & IsHWnd(_GUICtrlTreeView_GetEditControl($g_hTreeView)))
				Case $TVN_BEGINRDRAGA, $TVN_BEGINRDRAGW
					_WM_NOTIFY_DebugEvent("$TVN_BEGINRDRAG", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_DELETEITEMA, $TVN_DELETEITEMW
					_WM_NOTIFY_DebugEvent("$TVN_DELETEITEM", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_ENDLABELEDITA, $TVN_ENDLABELEDITW
					_WM_NOTIFY_DebugEvent("$TVN_ENDLABELEDIT", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
					Local $tInfo = DllStructCreate($tagNMHDR & ";" & $tagTVITEMEX, $lParam)
					If DllStructGetData($tInfo, "Text") <> 0 Then
						Local $tBuffer = DllStructCreate("wchar Text[" & DllStructGetData($tInfo, "TextMax") & "]", DllStructGetData($tInfo, "Text"))
						_GUICtrlTreeView_SetText($g_hTreeView, _GUICtrlTreeView_GetSelection($g_hTreeView), DllStructGetData($tBuffer, "Text"))
					EndIf
				Case $TVN_GETDISPINFOA, $TVN_GETDISPINFOW
					_WM_NOTIFY_DebugEvent("$TVN_GETDISPINFO", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_GETINFOTIPA, $TVN_GETINFOTIPW
					_WM_NOTIFY_DebugEvent("$TVN_GETINFOTIP", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_ITEMEXPANDEDA, $TVN_ITEMEXPANDEDW
					_WM_NOTIFY_DebugEvent("$TVN_ITEMEXPANDED", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_ITEMEXPANDINGA, $TVN_ITEMEXPANDINGW
					_WM_NOTIFY_DebugEvent("$TVN_ITEMEXPANDING", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_KEYDOWN
					_WM_NOTIFY_DebugEvent("$TVN_KEYDOWN", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_SELCHANGEDA, $TVN_SELCHANGEDW
					_WM_NOTIFY_DebugEvent("$TVN_SELCHANGED", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_SELCHANGINGA, $TVN_SELCHANGINGW
					_WM_NOTIFY_DebugEvent("$TVN_SELCHANGING", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_SETDISPINFOA, $TVN_SETDISPINFOW
					_WM_NOTIFY_DebugEvent("$TVN_SETDISPINFO", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
				Case $TVN_SINGLEEXPAND
					_WM_NOTIFY_DebugEvent("$TVN_SINGLEEXPAND", $tagNMHDR, $lParam, "hWndFrom,IDFrom")
			EndSwitch
	EndSwitch
	Return $GUI_RUNDEFMSG
EndFunc   ;==>WM_NOTIFY
