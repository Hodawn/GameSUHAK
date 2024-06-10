using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // 타일 프리팹
    public GameObject _tilePrefab;

    // 맵의 크기를 설정
    public int sizeX = 20;
    public int sizeY = 20;

    // 타일 그리드 
    public Tile[,] grid;
  

    // Awake 메서드는 스크립트 인스턴스가 로드될 때 호출됩니다.
    void Awake()
    {
        // 그리드와 이웃 타일 사전을 초기화합니다.
        grid = new Tile[sizeX, sizeY];

        MapDataManager.Instance.Init();

        // 맵을 생성합니다.
        GenerateMap(sizeX, sizeY);
    }

    // 맵을 생성하는 메서드입니다.
    void GenerateMap(int sizeX, int sizeY)
    {
        // 맵 생성
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                // 각 그리드 위치에 타일 프리팹을 인스턴스화하고 초기화합니다.
                grid[x, y] = Instantiate(_tilePrefab, new Vector3(x, 0, y), Quaternion.identity).GetComponent<Tile>();
                grid[x, y].Init(x, y);
            }
        }

        // 맵으로부터 그래프를 구축합니다.
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                // 이웃 타일 정
                List<Tile> neighbors = new List<Tile>();

                // (a) 위쪽 이웃 타일을 추가합니다.
                if (y < sizeY - 1)
                {
                    neighbors.Add(grid[x, y + 1]);
                }

                // (b) 오른쪽 이웃 타일을 추가합니다.
                if (x < sizeX - 1)
                {
                    neighbors.Add(grid[x + 1, y]);
                }

                // (c) 아래쪽 이웃 타일을 추가합니다.
                if (y > 0)
                {
                    neighbors.Add(grid[x, y - 1]);
                }

                // (d) 왼쪽 이웃 타일을 추가합니다.
                if (x > 0)
                {
                    neighbors.Add(grid[x - 1, y]);
                }

                // x 현재 좌표 

                /************************************/
                /* x b 0        d x b        0 d x
                /* c 0 0        0 c 0        0 0 c
                /* 0 0 0        0 0 0        0 0 0
                /************************************/

                /************************************/
                /* a 0 0        0 a 0        0 0 a
                /* x b 0        d x b        0 d x
                /* c 0 0        0 c 0        0 0 c
                /************************************/

                /************************************/
                /* 0 0 0        0 0 0        0 0 0
                /* a 0 0        0 a 0        0 0 a
                /* x b 0        d x b        0 d x
                /************************************/

                // 그래프 저장 
                MapDataManager.Instance.AddNeighbors(grid[x, y], neighbors.ToArray());
            }
        }
    }

    // 모든 타일을 초기 상태로 재설정하는 메서드입니다.
    public void ResetTiles()
    {
        foreach (Tile t in grid)
        {
            t._Color = Color.white;
            t._Text = "";
        }
    }
}
