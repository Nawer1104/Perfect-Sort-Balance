using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Balance : MonoBehaviour
{
    public List<Transform> transforms = new List<Transform>();

    private int index = 0;

    public GameObject balance_obj;

    public bool isBalance = false;

    public void SetObject(Object obj)
    {
        obj.transform.SetParent(transforms[index].parent);

        obj.transform.position = transforms[index].position;

        obj.transform.rotation = Quaternion.Euler(0, 0, obj.transform.parent.rotation.eulerAngles.z);

        obj.GetComponent<BoxCollider2D>().enabled = false;

        obj.GetComponent<SpriteRenderer>().sortingOrder = index + 2;

        index++;

        Check();
    }

    private void Check()
    {
        if (index == transforms.Count)
        {
            balance_obj.transform.DORotate(Vector3.zero, 1f).OnComplete(() => {
                isBalance = true;

                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].CheckBalances();
            });
        }
    }
}
