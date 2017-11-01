using System;
using System.Collections.Generic;
using UnityEngine;

namespace cn.kizzzy.manager
{
    public class MgrManager : IManager
    {
        private static MgrManager instance;
        private Dictionary<string, IManager> mgrs = new Dictionary<string, IManager>();

        public bool Init()
        {
            foreach (IManager mgr in mgrs.Values)
            {
                if (!mgr.Init())
                    return false;
            }
            return true;
        }

        public bool Start()
        {
            foreach (IManager mgr in mgrs.Values)
            {
                if (!mgr.Start())
                    return false;
            }
            return true;
        }

        public bool Stop()
        {
            foreach (IManager mgr in mgrs.Values)
            {
                if (!mgr.Stop())
                    return false;
            }
            return true;
        }

        public bool Reload()
        {
            foreach (IManager mgr in mgrs.Values)
            {
                if (!mgr.Reload())
                    return false;
            }
            return true;
        }

        public string Name
        {
            get
            {
                return "";
            }
        }

        public static MgrManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new MgrManager();
                return instance;
            }
        }

        public bool AddManager<T>() where T : IManager
        {
            try
            {
                Type type = Type.GetType(typeof(T).FullName);
                IManager mgr = (IManager)Activator.CreateInstance(type);
                if (mgrs.ContainsKey(mgr.Name))
                {
                    Debug.Log("manager already exist");
                    return false;
                }
                mgrs.Add(mgr.Name, mgr);
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
                return false;
            }
            return true;
        }

        public T GetManager<T>() where T :IManager
        {
            string key = typeof(T).FullName;
            return (T)mgrs[key];
        }
    }
}
