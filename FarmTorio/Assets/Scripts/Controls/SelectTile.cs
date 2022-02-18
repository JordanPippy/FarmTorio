using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class SelectTile : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap map;
    public Tile highlight;
    public GameObject player;
    private Vector3Int previous;
    [SerializeField] private int distanceThreshold;
    void Start()
    {
        distanceThreshold = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int playerPositon = map.WorldToCell(player.transform.position);
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = map.WorldToCell(pos);

        if (Vector3Int.Distance(playerPositon, coordinate) < distanceThreshold)
            map.SetTile(coordinate, highlight);

        if (previous != coordinate)
        {
            map.SetTile(previous, null);
            previous = coordinate;
        }
    }
}
