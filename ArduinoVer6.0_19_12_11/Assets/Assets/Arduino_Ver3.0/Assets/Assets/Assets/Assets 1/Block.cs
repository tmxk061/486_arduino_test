using System.Collections;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void SetDownColllider(bool s);

    public abstract void SetUPColllider(bool s);

    public abstract IEnumerator Run(float s);

    public abstract bool CheckUoCollider();

    public abstract bool CheckDownCollider();

    public abstract GameObject CheckParentObj();

    public abstract IEnumerator GetCode(bool s);

    public abstract IEnumerator GetSyncCode(bool s);

    public abstract IEnumerator SyncRun(bool s);

    public abstract IEnumerator GetBtCode(bool s);
}