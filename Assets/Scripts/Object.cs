using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Object : MonoBehaviour
{
    public Balance balance;

    public GameObject vfxCollect;

    private void OnMouseDown()
    {
        transform.DOMove(balance.transform.position, 1f).OnComplete(() => {
            GameObject vfx = Instantiate(vfxCollect, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            balance.SetObject(this);
        });
    }
}
