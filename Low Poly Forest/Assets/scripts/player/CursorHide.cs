using UnityEngine;
using System.Collections;

public class CursorHide : MonoBehaviour {
	public bool isLocked;
	public bool hideCursor = true;

	void Start () {
		SetCursorLock (true);
	}

	void SetCursorLock(bool isLocked)
	{
		this.isLocked = isLocked;
		Screen.lockCursor = isLocked;
	}


	void Update () {
		if (Input.GetKeyDown (KeyCode.R))
			SetCursorLock (!isLocked);
	}
}