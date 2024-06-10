using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private MapGenerator _mapGenerator;

    public PathfindingAlgorithm[] algorithms;

    public AlgorithmType _currentAlgorithm;

    private void Awake()
    {
        var map = GameObject.Find("MapGenerator");

        if (map != null)
        {
            _mapGenerator = map.GetComponent<MapGenerator>();
        }
    }

    private void Start()
    {
        TMPro.TMP_Dropdown dropDown = FindObjectOfType<TMPro.TMP_Dropdown>();
        dropDown.onValueChanged.AddListener(OnAlgorithmChanged);
        dropDown.value = PlayerPrefs.GetInt("currentAlgorithm");
    }


    public void OnAlgorithmChanged(int algorithmID)
    {
        _currentAlgorithm = (AlgorithmType)algorithmID;
        FindObjectOfType<PathTester>().RepaintMap();
        PlayerPrefs.SetInt("currentAlgorithm", (int)algorithmID);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Finds a path from starttile to endtile
    /// </summary>
    /// <returns>Returns a Queue which contains the Tiles, the player must move.</returns>
    public Queue<Tile> FindPath(Tile start, Tile end)
    {
        switch (_currentAlgorithm)
        {
            case AlgorithmType.BFS:
            {

                return algorithms[0].Search(start, end);
            }
            case AlgorithmType.Dijkstra:
            {
                return algorithms[1].Search(start, end);
            }
            case AlgorithmType.AStar:
            {
                return algorithms[2].Search(start, end);
            }

        }

        return null;
    }
}