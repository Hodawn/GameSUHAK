using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : PathfindingAlgorithm
{
    // A* 알고리즘을 사용하여 경로를 찾는 메서드입니다.
    public override Queue<Tile> Search(Tile start, Tile goal)
    {
        // 각 타일에서 목표 타일로 가기 위한 다음 타일을 저장합니다. Key=Tile, Value=Goal로 가기 위한 다음 타일
        Dictionary<Tile, Tile> NextTileToGoal = new Dictionary<Tile, Tile>();
        // 각 타일에 도달하는 총 이동 비용을 저장합니다.
        Dictionary<Tile, int> costToReachTile = new Dictionary<Tile, int>();

        // 우선순위 큐를 사용하여 탐색을 수행합니다.
        PriorityQueue<Tile> frontier = new PriorityQueue<Tile>();
        frontier.Enqueue(goal, 0);
        costToReachTile[goal] = 0;

        // 큐가 빌 때까지 탐색을 계속합니다.
        while (frontier.Count > 0)
        {
            Tile curTile = frontier.Dequeue();

            // 현재 타일이 시작 타일이면 탐색을 종료합니다.
            if (curTile == start)
            {
                break;
            }

            // 현재 타일의 모든 이웃 타일을 탐색합니다.
            foreach (Tile neighbor in MapDataManager.Instance.GetNeighbors(curTile))
            {
                int newCost = costToReachTile[curTile] + neighbor._Cost;

                // 이웃 타일에 더 낮은 비용으로 도달할 수 있으면 업데이트합니다.
                if (costToReachTile.ContainsKey(neighbor) == false || newCost < costToReachTile[neighbor])
                {
                    // 벽이 아닌 타일만 탐색합니다.
                    if (neighbor._TileType != Tile.TileType.Wall)
                    {
                        costToReachTile[neighbor] = newCost;

                        // 우선순위는 이동 비용과 맨해튼 거리를 합산하여 계산합니다.
                        int priority = newCost + ManhattenDistance(neighbor, start);

                        frontier.Enqueue(neighbor, priority);

                        NextTileToGoal[neighbor] = curTile;

                        // 타일의 텍스트를 이동 비용으로 설정합니다.
                        neighbor._Text = costToReachTile[neighbor].ToString();
                    }
                }
            }
        }

        // 시작 타일이 목표 타일로부터 도달 가능한지 확인합니다.
        if (NextTileToGoal.ContainsKey(start) == false)
        {
            return null;
        }

        // 경로를 추적하여 큐에 저장합니다.
        Queue<Tile> path = new Queue<Tile>();
        Tile pathTile = start;
        while (goal != pathTile)
        {
            pathTile = NextTileToGoal[pathTile];
            path.Enqueue(pathTile);
        }
        return path;
    }

    /// <summary>
    /// 두 타일 간의 맨해튼 거리를 계산합니다. (플레이어가 이동해야 하는 타일 수)
    /// </summary>
    /// <returns>두 타일 간의 거리</returns>
    int ManhattenDistance(Tile t1, Tile t2)
    {
        return Mathf.Abs(t1._X - t2._X) + Mathf.Abs(t1._Y - t2._Y);
    }
}
