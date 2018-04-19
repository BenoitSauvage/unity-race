using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody && other.transform.CompareTag(GV.CAR_TAG))
            CheckpointManager.Instance.CheckpointTriggered(this, other.transform);
	}
}
