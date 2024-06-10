using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    // 요소들을 저장하는 리스트입니다. 각 요소는 (값, 우선순위) 형태의 튜플로 저장됩니다.
    private List<Tuple<T, int>> elements = new List<Tuple<T, int>>();

    // 큐에 있는 요소의 수를 반환합니다.
    public int Count
    {
        get { return elements.Count; }
    }

    // 새로운 요소를 우선순위와 함께 큐에 추가합니다.
    public void Enqueue(T item, int priority)
    {
        elements.Add(Tuple.Create(item, priority));
    }

    // 우선순위가 가장 높은 요소를 큐에서 제거하고 반환합니다.
    public T Dequeue()
    {
        int bestIndex = 0;

        // 모든 요소를 검사하여 우선순위가 가장 높은 요소의 인덱스를 찾습니다.
        for (int i = 0; i < elements.Count; i++)
        {
            // 우선순위가 더 낮은 값이 더 높은 우선순위를 나타냅니다 (작을수록 우선순위가 높음).
            if (elements[i].Item2 < elements[bestIndex].Item2)
            {
                bestIndex = i;
            }
        }

        // 우선순위가 가장 높은 요소를 저장합니다.
        T bestItem = elements[bestIndex].Item1;
        // 해당 요소를 리스트에서 제거합니다.
        elements.RemoveAt(bestIndex);
        // 우선순위가 가장 높은 요소를 반환합니다.
        return bestItem;
    }
}
