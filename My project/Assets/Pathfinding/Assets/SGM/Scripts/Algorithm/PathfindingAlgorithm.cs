using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathfindingAlgorithm : MonoBehaviour
{
    public MapGenerator _mapGenerator;

    public abstract Queue<Tile> Search(Tile start, Tile goal);
}
