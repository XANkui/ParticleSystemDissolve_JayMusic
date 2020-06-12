//using System.Collections;
using UnityEngine;

public class selfDestroy : MonoBehaviour {
	public float delayInSecond = 1f;
	void Awake() {
		Destroy(this.gameObject, delayInSecond);
	}
}
