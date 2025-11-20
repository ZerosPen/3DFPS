using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CrossFade : SceneTransition
{
    public CanvasGroup cg;

    public override IEnumerator AnimateTransitionIn()
    {
        var tweener = cg.DOFade(1f, 1f);
        yield return tweener.WaitForCompletion();
    }

    public override IEnumerator AnimatorTransitionOut()
    {
        var tweener = cg.DOFade(0f, 1f);
        yield return tweener.WaitForCompletion();
    }
}
