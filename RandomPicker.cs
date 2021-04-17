using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPicker<T>
{
    public T Pick(T[] candidates)
    {
        return candidates[Random.Range(0, candidates.Length)];
    }

    public T[] Pick(T[] candidates, int count, bool duplication)
    {
        if (count > candidates.Length) count = candidates.Length;

        if (duplication)
        {
            List<T> pickedList = new List<T>();
            for (int i = 0; i < count; i++)
            {
                T picked = candidates[Random.Range(0, candidates.Length)];
                if (!pickedList.Contains(picked)) pickedList.Add(picked);
            }

            return pickedList.ToArray();
        }
        else
        {
            List<T> tmpCandidates = new List<T>(candidates);
            List<T> pickedList = new List<T>();

            for (int i = 0; i < count; i++)
            {
                int index = Random.Range(0, tmpCandidates.Count);
                pickedList.Add(tmpCandidates[index]);
                tmpCandidates.RemoveAt(index);
            }

            return pickedList.ToArray();
        }
    }
}
