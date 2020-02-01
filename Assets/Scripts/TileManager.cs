using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public RoomManager roomTutorialPrefab;
    public RoomManager[] roomPrefab;
    public List<RoomManager> rooms = new List<RoomManager>();
    private static TileManager _instance;
    public static TileManager Instance { get { return _instance; } }
    public RoomManager curRoom;
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }

    private void Start()
    {
        AddTile();
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //   AddTile();
    }

    public void AddTile()
    {
        RoomManager rm;
        if (rooms.Count==0)
         rm = Instantiate(roomTutorialPrefab);
        else
         rm = Instantiate(roomPrefab[Random.Range(0,roomPrefab.Length)]);
        if (rooms.Count > 0)
        {
            rm.transform.position = rooms[rooms.Count - 1].nextDoor.position;
        }
        else
        {
            rm.transform.position = Vector3.zero;
            Camera.main.transform.position = rm.camPos.position;
        }

        rm.transform.SetParent(transform);
        rooms.Add(rm);

        if (rooms.Count > 3)
        {
            Destroy(rooms[rooms.Count - 4].gameObject);
            rooms.RemoveAt(rooms.Count -4);
        }
    }

    public IEnumerator MoveCam(Vector3 newPos)
    {
        float elapsedTime = 0;
        Vector3 startingPos = Camera.main.transform.position;
        while (elapsedTime < .3f)
        {
            Camera.main.transform.position = Vector3.Lerp(startingPos, newPos, (elapsedTime / .3f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = newPos;
    }


}
