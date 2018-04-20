using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointManager {

    #region singleton
    private static CheckpointManager instance;

    private CheckpointManager() { }

    public static CheckpointManager Instance {
        get {
            if (instance == null)
                instance = new CheckpointManager();

            return instance;
        }
    }
    #endregion singleton

    List<Checkpoint> checkpoints = new List<Checkpoint>();
    Dictionary<int, Checkpoint> playerCheckpoints = new Dictionary<int, Checkpoint>();

    public void Init() {
        foreach (Transform t in GV.ws.checkpoints)
            checkpoints.Add(t.GetComponent<Checkpoint>());

        foreach (KeyValuePair<int, CarUserControl> kv in PlayerManager.Instance.GetPlayers())
            playerCheckpoints.Add(kv.Value.IDCar, checkpoints[0]);
    }

    public void CheckpointTriggered(Checkpoint _checkpoint, Transform _player) {
        int player_id = _player.GetComponent<CarUserControl>().IDCar;

        if (checkpoints.IndexOf(_checkpoint) > checkpoints.IndexOf(playerCheckpoints[player_id]))
            playerCheckpoints[player_id] = _checkpoint;
    }

    public Checkpoint GetLastCheckpoint (int _player) {
        return playerCheckpoints[_player];
    }
}