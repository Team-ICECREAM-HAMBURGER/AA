using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class GCObjectPoolController<Tself, Tenum, Tobject> : GCSingletonImplementer<Tself>
    where Tself : GCObjectPoolController<Tself, Tenum, Tobject>
    where Tenum : System.Enum
    where Tobject : Component 
{
    protected Dictionary<Tenum, IObjectPool<Tobject>> _poolDic = new();
    
    
    protected abstract Tobject GetPrefab(Tenum type);
    
    protected virtual void InitPool(Tenum type, int poolMaxSize = 100) {
        if (this._poolDic.ContainsKey(type)) return;

        this._poolDic.Add(type, new ObjectPool<Tobject>(
            createFunc: () => {
                var instance = Instantiate(GetPrefab(type));
                OnCreateObject(type, instance);
                
                return instance;
            },
            actionOnRelease: OnReleaseToPool,
            maxSize: poolMaxSize));
    }

    protected virtual void OnCreateObject(Tenum type, Tobject obj) { } // Enter to the Pool

    protected virtual void OnReleaseToPool(Tobject obj) {
        obj.gameObject.SetActive(false);
    }

    protected virtual void OnDestroyPooled(Tobject obj) {
        Destroy(obj.gameObject);
    }

    public virtual Tobject Get(Tenum type, Vector3 position, Quaternion rotation) {
        if (!this._poolDic.ContainsKey(type)) InitPool(type);

        var obj = this._poolDic[type].Get();
        obj.transform.SetPositionAndRotation(position, rotation);
        obj.gameObject.SetActive(true);

        return obj;
    }
}