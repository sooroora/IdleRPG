using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EInteractionDetectorShape
{
    Line,
    Sphere,
    Cube,
    Capsule,
}

public abstract class RayDetector<T> : MonoBehaviour
{
    [SerializeField] protected Transform startTransform;
    [SerializeField] protected float detectDistance = 1.0f;
    [SerializeField] protected float detectShapeRange = 1.0f;
    [SerializeField] protected EInteractionDetectorShape rayShape;
    protected List<T> currentTargetList = new List<T>();

    public void SetDetectDistance( float distance )
    {
        detectDistance = distance;
    }

    public void SetDetectShapeRange( float range )
    {
        detectShapeRange = range;
    }

    public void SetRayShape( EInteractionDetectorShape rayShape )
    {
        this.rayShape = rayShape;
    }
    
    public virtual List<T> CurrentTargets
    {
        get
        {
            UpdateTarget();
            return currentTargetList;
        }
    }

    public virtual T CurrentTarget
    {
        get
        {
            UpdateTarget();
            return currentTarget;
        }
    }

    protected T currentTarget;


    [Header("Debug")]
    [SerializeField]
    private Color gizmosColor = Color.cyan;

    private void Awake()
    {
        currentTargetList = new List<T>();
    }

    protected void UpdateTarget()
    {
        RaycastHit[] hits = new RaycastHit[] { };

        switch (rayShape)
        {
            case EInteractionDetectorShape.Line:
                hits = Physics.RaycastAll(startTransform.position, startTransform.forward, detectDistance);
                break;
            case EInteractionDetectorShape.Sphere:
                hits = Physics.SphereCastAll(startTransform.position, detectShapeRange, startTransform.forward, detectDistance);
                break;

            case EInteractionDetectorShape.Cube:
                Vector3 halfExtents = new Vector3(detectShapeRange, detectShapeRange, detectShapeRange);
                hits = Physics.BoxCastAll(startTransform.position, halfExtents, startTransform.forward, startTransform.rotation, detectDistance);
                break;

            case EInteractionDetectorShape.Capsule:
                // 나중에....

                break;
        }

        if (hits.Length > 0)
        {
            List<RaycastHit> hitsList = hits.ToList();

            // 대상에 RayDetector 를 가지고있는 본인도 들어갈 수 있으니 제거
            hitsList.RemoveAll((h) =>
            {
                if (h.collider.gameObject == this.gameObject) return true;
                return false;
            });

            hitsList.Sort((a, b) => a.distance.CompareTo(b.distance));

            
            currentTargetList.Clear();
            foreach (RaycastHit hit in hitsList)
            {
                T target = hit.collider.GetComponent<T>();
                if (target != null)
                {
                    currentTargetList.Add(target);
                    // currentTarget = target;
                    // return;
                }
            }
            
            if(currentTargetList.Count > 0)
                currentTarget = currentTargetList[0];
            else
                currentTarget = default(T);
        }

    }


    // protected List<T> GetAllTarget()
    // {
    //     List<T> list = new List<T>();
    //
    //     foreach (RaycastHit hit in hitsList)
    //     {
    //         T target = hit.collider.GetComponent<T>();
    //         if (target != null)
    //         {
    //             list.Add(target);
    //         }
    //     }
    //     return list;
    // }


#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (startTransform == null) return;

        Gizmos.color = gizmosColor;
        

        switch (rayShape)
        {
            case EInteractionDetectorShape.Line:
                Gizmos.DrawLine(startTransform.position, startTransform.position + (startTransform.forward * detectDistance));
                break;
            case EInteractionDetectorShape.Sphere:
                Gizmos.DrawWireSphere(startTransform.position, detectShapeRange);
                Gizmos.DrawWireSphere(startTransform.position + (startTransform.forward * detectDistance), detectShapeRange);
                break;

            case EInteractionDetectorShape.Cube:
                Vector3 halfExtents = new Vector3(detectShapeRange, detectShapeRange, detectShapeRange);
                Gizmos.matrix = Matrix4x4.TRS(startTransform.position + startTransform.forward * (detectDistance / 2), startTransform.rotation, Vector3.one);
                Gizmos.DrawWireCube(Vector3.zero, halfExtents * 2 + new Vector3(0, 0, detectDistance));
                break;
        }
    }

#endif
}
