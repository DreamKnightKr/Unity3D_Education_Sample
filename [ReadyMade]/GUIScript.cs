using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	static bool isLoaded = false;

	// Use this for initialization
	void Start () {

		if(!isLoaded)
		{
			DontDestroyOnLoad(gameObject);

			// 다시 Scene1로 돌아 올 떄 중복 생성 방지. 보통은 싱글턴이라든가 초기화 Scene이 라든가 조금더 복잡하고 우아한 방식 사용.
			isLoaded = true;
		}
		else
			Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		float fPosX = 250, fPosY = 50, fYInterval = 40;
		int nYPosCount = 0;

		if (GUI.Button(new Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "Back Step1"))
		{
			Application.LoadLevel("Step1");
			Debug.Log("Init. 'Step1' Scene.");
		}
		nYPosCount++;
		if (GUI.Button(new Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "Move Step1_Move"))
		{
			Application.LoadLevel("Step1_Move");

			Debug.Log("Move 'Step1_Move' Scene.");
		}

		nYPosCount++;
		if (GUI.Button(new Rect(fPosX, fPosY + (fYInterval * nYPosCount), 200, 30), "Add Step1_Add"))
		{
			Application.LoadLevelAdditive("Step1_Add");

			Debug.Log("Add 'Step1_Add' Scene.");
			// 반복 수행하면 Scene에 있는 GameObject가 계속추가됨.
		}
	}
}
