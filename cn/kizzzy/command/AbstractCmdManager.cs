using cn.kizzzy.command;
using cn.kizzzy.protocol;
using cn.kizzzy.util;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace cn.kizzzy.manager
{
    public abstract class AbstractCmdManager : ICmdManager
    {
        private Dictionary<short, ICommand> cmds;

        public bool Init()
        {
            cmds = new Dictionary<short, ICommand>();
            Debug.Log("Cmd组件初始化成功");
            return true;
        }

        public bool Start()
        {
            List<Type> types = ClassUtil.GetClasses(CmdPackage);
            foreach (Type type in types)
            {
                Attr attr = ClassUtil.GetAttribe<Attr>(type);
                if (attr != null)
                {
                    ICommand cmd = (ICommand)Activator.CreateInstance(type);
                    if (cmds.ContainsKey(attr.Code))
                    {
                        Debug.Log("Cmd组件启动失败");
                        return false;
                    }
                    cmds.Add(attr.Code, cmd);
                }
            }
            Print();
            Debug.Log("Cmd组件启动成功");
            return true;
        }

        public bool Stop()
        {
            Debug.Log("Cmd组件关闭成功");
            return true;
        }

        public bool Reload()
        {
            Debug.Log("Cmd组件重启成功");
            return true;
        }

        public string Name
        {
            get
            {
                return typeof(ICmdManager).FullName;
            }
        }

        public abstract string CmdPackage { get; }

        public ICommand GetCommand(short code)
        {
            return cmds[code];
        }

        private void Print()
        {
            foreach (KeyValuePair<short, ICommand> kv in cmds)
            {
                Debug.Log("<" + kv.Key + ", " + kv.Value + ">");
            }
        }
    }
}
