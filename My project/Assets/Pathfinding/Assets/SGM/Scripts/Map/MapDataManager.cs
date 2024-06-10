using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataManager : Singleton<MapDataManager>
{
    private Dictionary<Tile, Tile[]> neighborDictionary;

    public void Init()
    {
        neighborDictionary = new Dictionary<Tile, Tile[]>();
    }


    // 이웃 타일 반환
    public Tile[] GetNeighbors(Tile tile)
    {
        return neighborDictionary[tile];
    }

    public void AddNeighbors(Tile grid, Tile[] neighbors)
    {
        // 현재 타일의 이웃 타일들을 사전에 추가합니다.
        neighborDictionary.Add(grid, neighbors);          
    }

    public void Reset()
    {
        neighborDictionary.Clear();
    }
}
