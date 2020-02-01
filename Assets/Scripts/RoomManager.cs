using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Transform nextDoor;
    public Computer[] computers;
    public Transform camPos;
    public GameObject door;


    private void Start()
    {
        computers = GetComponentsInChildren<Computer>();
    }

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
        StartCoroutine(ActiveDoorAnim());
    }


    IEnumerator ActiveDoorAnim()
    {
        float elapsedTime = 0;
        Vector3 startigRot = door.transform.localEulerAngles;
        while (elapsedTime < .3f)
        {
            door.transform.localEulerAngles = Vector3.Lerp(startigRot, new Vector3(0, -90, 0), (elapsedTime / .3f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        door.transform.localEulerAngles = new Vector3(0,-90, 0);
    }


    public void CloseOldDoor()
    {
        //chiudi la prota di sinistra
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ciaoe");
            TileManager.Instance.curRoom = this;
            //chiudi porta
            StartCoroutine(TileManager.Instance.MoveCam(camPos.position)); 
        }
    }
}
