using UnityEngine;
using System.Collections;

public class GameObjectKeyMover : MonoBehaviour {
	Transform trans;
	public float moveSpeed = 2f;	//  2m/sec
	public float turnSpeed = 90f;	// 90degree/sec

	// Use this for initialization
	void Start () {
		gameObject.name += "+Script";

		trans = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

		//trans 말고 이미 제공하는 변수인 transform을 사용해도 됨.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		trans.Translate(trans.forward * v * moveSpeed * Time.deltaTime, Space.World);
		trans.Rotate( new Vector3(0f, Time.deltaTime * turnSpeed * h, 0f) );
	}
}
