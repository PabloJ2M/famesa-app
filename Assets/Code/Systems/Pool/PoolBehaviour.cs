using System.Collections.Generic;

namespace UnityEngine.Pool
{
    public abstract class PoolBehaviour<T> : MonoBehaviour where T : Component
    {
        [SerializeField] protected T _prefab;

        protected IObjectPool<T> _objectPool;
        protected IList<T> _currentActives;

        protected virtual Transform _parent { get; }
        protected virtual void Awake()
        {
            _currentActives = new List<T>();
            _objectPool = new ObjectPool<T>(Create, Get, Release, Clear, default, default, 100);
        }

        protected virtual T Create() => Instantiate(_prefab, _parent);
        protected virtual void Get(T image) { image.gameObject.SetActive(true); _currentActives.Add(image); }
        protected virtual void Release(T image) { image.gameObject.SetActive(false); _currentActives.Remove(image); }
        protected virtual void Clear(T image) => Destroy(image.gameObject);

        protected virtual void ClearActiveItems()
        {
            for (int i = _currentActives.Count - 1; i >= 0; i--)
                _objectPool.Release(_currentActives[i]);
        }
    }
}