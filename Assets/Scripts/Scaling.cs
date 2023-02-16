using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scaling : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 scaleTo;
    public GameObject AreaA, AreaB, AreaC, AreaD, AreaE, AreaF;
    private void Start()
    {
        //originalScale = transform.localScale;
        //scaleTo = originalScale * 2;
        //transform.DOScale(scaleTo, 0.5f)
        //    .SetEase(Ease.InOutSine)
        //    .SetLoops(-1, LoopType.Yoyo);
    }

    public void Changing(string test)
    {
        //objc.transform.GetChild(i).transform.DOJump(objc.transform.GetChild(i).transform.position, .5f, 0, .5f);
        //    objc.transform.GetChild(i).transform.DORotate(Vector3.left * 180, .5f,RotateMode.WorldAxisAdd);
        //DOTween.KillAll();
       // gameObject.transform.DOJump(transform.position, 0.5f, 0, .5f);

        switch (test)
        {
            case "AreaA":
                AreaA.transform.DORotate(Vector3.right * 360, .5f, RotateMode.WorldAxisAdd);
                break; ;

            case "AreaB":
                AreaB.transform.DORotate(Vector3.right * 360, .5f, RotateMode.WorldAxisAdd);
                break;

            case "AreaC":
                AreaC.transform.DORotate(Vector3.right * 360, .5f, RotateMode.WorldAxisAdd);
                break;

            case "AreaD":
                AreaD.transform.DORotate(Vector3.right * 360, .5f, RotateMode.WorldAxisAdd);
                break;

            case "AreaE":
                AreaE.transform.DORotate(Vector3.right * 360, .5f, RotateMode.WorldAxisAdd);
                break;

            case "AreaF":
                AreaF.transform.DORotate(Vector3.right * 360, .5f, RotateMode.WorldAxisAdd);
                break;

            default:
                Debug.Log("Hata");
                break;

        }
    }
}
