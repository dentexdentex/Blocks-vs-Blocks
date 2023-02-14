using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scaling : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 scaleTo;
    public GameObject gameObject;
    private void Start()
    {
        originalScale = transform.localScale;
        scaleTo = originalScale * 2;
        transform.DOScale(scaleTo, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void Changing()
    {
        //objc.transform.GetChild(i).transform.DOJump(objc.transform.GetChild(i).transform.position, .5f, 0, .5f);
        //    objc.transform.GetChild(i).transform.DORotate(Vector3.left * 180, .5f,RotateMode.WorldAxisAdd);
        //DOTween.KillAll();
        gameObject.transform.DOJump(transform.position, 0.5f, 0, .5f);
        gameObject.transform.DORotate(Vector3.left * 180, .5f, RotateMode.WorldAxisAdd);
    }
}
