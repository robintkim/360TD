using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

	public int gold;
	// Use this for initialization

	void Start () {
		gold =500;
	}

	public void AddGold(int num) {
		gold += num;
	}

	public void SubtractGold(int num) {
		gold -= num;
	}
}
