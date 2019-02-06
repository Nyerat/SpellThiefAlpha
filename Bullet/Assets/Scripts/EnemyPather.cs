using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPather : MonoBehaviour
{

    public BezierSpline spline;
    public BezierSpline spline2;

    private BezierSpline switchSpline;

    public float duration;

    public float delayToGoHome;

    private float progress;

    public SplineWalkerModes mode;

    private bool goingForward = true;

    private void Awake()
    {
        switchSpline = spline;
        StartCoroutine(GoHome());

    }

    private void Update()
    {
        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                if (mode == SplineWalkerModes.Once)
                {
                    progress = 1f;
                }
                else if (mode == SplineWalkerModes.Loop)
                {
                    progress -= 1f;
                }
                else
                {
                    progress = 2f - progress;
                    goingForward = false;
                    
                }
            }
        }
        else
        {
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
                
            }
        }


        if (progress == 1)
        {
            //Go home, enemy
            GoHome();
        }
        transform.localPosition = switchSpline.GetPoint(progress);

    }

    IEnumerator GoHome()
    {

            yield return new WaitForSeconds(delayToGoHome);
            goingForward = true;
            switchSpline = spline2;
            progress = 0;
    }

}
