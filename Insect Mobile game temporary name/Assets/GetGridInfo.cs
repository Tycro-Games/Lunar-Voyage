using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


struct Tile
{
    public bool blocking;
    public int costG;
    public int costH;
    public Vector2 pos;

    public Tile (Vector2 Pos, int CostG, int CostH, bool Blocking = false)
    {
        blocking = Blocking;
        costG = CostG;
        costH = CostH;
        pos = Pos;
    }
}
[Serializable]
struct TileSettings
{
    public int x;
    public int y;
    public int size;
    public TileSettings (int X, int Y, int Size)
    {
        x = X;
        y = Y;
        size = Size;
    }
}
public class GetGridInfo : MonoBehaviour
{
    private Tile[,] Grid = null;
    [SerializeField]
    private TileSettings size = new TileSettings ();
    private void Start ()
    {
        Grid = new Tile[size.x, size.y];
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Tile tile = new Tile (new Vector2 (i * size.size, j * size.size), 0, 0);

                Grid[i, j] = tile;
            }
        }
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Instantiate (new GameObject (), Grid[i, j].pos, Quaternion.identity);
            }
        }
    }
}
