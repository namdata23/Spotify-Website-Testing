#include <GUIConstantsEx.au3>
#include <GuiSlider.au3>
#include <MsgBoxConstants.au3>

Example()

Func Example()
	; Create GUI
	GUICreate("Slider Get/Set Tic (v" & @AutoItVersion & ")", 400, 296)
	Local $idSlider = GUICtrlCreateSlider(2, 2, 396, 20, BitOR($TBS_TOOLTIPS, $TBS_AUTOTICKS, $TBS_ENABLESELRANGE))
	GUISetState(@SW_SHOW)

	; Set Tic
	Local $iTic = Random(0, 100, 1)
	_GUICtrlSlider_SetTic($idSlider, $iTic)

	; Get Tic
	MsgBox($MB_SYSTEMMODAL, "Information", "Tic: " & _GUICtrlSlider_GetTic($idSlider, $iTic))

	; Loop until the user exits.
	Do
	Until GUIGetMsg() = $GUI_EVENT_CLOSE
	GUIDelete()
EndFunc   ;==>Example
