using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrosManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}

	public void Startup() {
		Debug.Log("Bros manager starting...");

		status = ManagerStatus.Started;
	}

}
