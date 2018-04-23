using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
        Debug.Log(other.transform.parent.parent.CompareTag(GV.CAR_TAG));

        if (other.attachedRigidbody && other.transform.parent.parent.CompareTag(GV.CAR_TAG))
            CheckpointManager.Instance.CheckpointTriggered(this, other.transform.parent.parent);
	}
}
