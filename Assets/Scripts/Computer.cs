using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour{
    public bool repaired;
    private void Start()
    {
    }
    public void SetRepaired(bool repaired){
        this.repaired = repaired;
        TileManager.Instance.curRoom.CheckForDoor();
    }

}
