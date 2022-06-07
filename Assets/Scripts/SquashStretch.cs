using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashStretch : MonoBehaviour

{
    public AnimationCurve SquashStretchAnimationCurve;
    float mSquashStretchFactor = 1.0f; // 0 is squashed, 2 is stretched, 1 is normal
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScale();
    }
    //this should probably be in another script but whatever
    void UpdateScale()
    {
        float rotAngle = Mathf.Atan2(rb.transform.forward.y, rb.transform.forward.x) * 180 / Mathf.PI;
        Quaternion rot = Quaternion.Euler(rotAngle, 0, 0);
        Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, rot, Vector3.one);

        // Get the inverse of the matrix (ie, to undo the rotation).
        Matrix4x4 inv = m.inverse;

        if (mSquashStretchFactor < 1.0f)
        {
            float t = mSquashStretchFactor;

            Vector3 scale = new Vector3(1.2f, 0.7f, 1.0f);
            var pt = m.MultiplyPoint3x4(scale);
            transform.localScale = Vector3.Lerp(
            Vector3.one, pt,
            t);
        }
        else if (mSquashStretchFactor > 1.0f)
        {
            Vector3 scale2 = new Vector3(0.7f, 1.2f, 1.0f);
            var pt = m.MultiplyPoint3x4(scale2);
            float t = mSquashStretchFactor - 1.0f;
            transform.localScale = Vector3.Lerp(
                Vector3.one,
                pt,
                t);
        }
        else
        {
            transform.localScale = Vector3.one;
        }

    }

    IEnumerator mImpactFXRoutine;
    public void PlayImpactFX()
    {
        if (mImpactFXRoutine != null)
            StopCoroutine(mImpactFXRoutine);
        mImpactFXRoutine = CR_PlayImpactFX();
        StartCoroutine(mImpactFXRoutine);
    }

    IEnumerator CR_PlayImpactFX()
    {
        float t = 0.0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime * 2.0f;
            float squashStretchCurveEval = SquashStretchAnimationCurve.Evaluate(t);
            mSquashStretchFactor = squashStretchCurveEval;
            yield return null;
        }
        mSquashStretchFactor = 1.0f;
    }


}
