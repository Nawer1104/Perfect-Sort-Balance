using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Balance> balances;

    public void CheckBalances()
    {
        foreach(Balance balance in balances)
        {
            if (!balance.isBalance)
                return;
        }

        GameManager.Instance.CheckLevelUp();
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
