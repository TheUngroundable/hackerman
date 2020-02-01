using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Transform nextDoor;
    public Computer[] computers;



    public void CheckForDoor()                                          //ogni volta che spacco computer chiamo sta funzione che se tutti i monitor sono distrutti apre porta
    {
        for (int i = 0; i < computers.Length; i++)
        {
            if (computers[i].repaired == false)
                return;
            else OpenDoor();
        }
    }

    public void OpenDoor()                          //attivare animaazione porta e crea nuovo tile
    {
        TileManager.Instance.AddTile();
    }


    public void CloseOldDoor()
    {
        //chiudi la prota di sinistra
    }
}
