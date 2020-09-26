﻿using System;
using System.Collections.Generic;

namespace GFramework
{
    /// <summary>
    /// 项目中只存在一个Facade派生类，单例访问
    /// </summary>
    public abstract class Facade
    {
        protected IDispenser dispenser = GlobalDispenser.Instance;
        protected GlobalServices services = GlobalServices.Instance;

        public virtual void BindingCommand(Type command, int messageID)
        {
            dispenser.BindingCommand(command, messageID);
        }

        public void BindingVariableCommands(Type command, IList<int> messageID)
        {
            for (int i = 0; i < messageID.Count; i++)
            {
                dispenser.BindingCommand(command, messageID[i]);
            }
        }

        public void BindingVariableCommands(Type command, params int[] messageID)
        {
            for (int i = 0; i < messageID.Length; i++)
            {
                dispenser.BindingCommand(command, messageID[i]);
            }
        }

        public void UnBindingCommand(int messageID)
        {
            dispenser.UnBindingCommand(messageID);
        }
        public void UnBindingVariableCommands(IList<int> messageID)
        {
            for (int i = 0; i < messageID.Count; i++)
            {
                dispenser.UnBindingCommand(messageID[i]);
            }
        }
        public void UnBindingVariableCommands(params int[] messageID)
        {
            for (int i = 0; i < messageID.Length; i++)
            {
                dispenser.UnBindingCommand(messageID[i]);
            }
        }

        public void SendMessage(int messageID, object sender = null, object content = null, IDispenser dispenser = null)
        {
            if (dispenser == null)
            {
                this.dispenser.Receive(new Message(messageID, sender, content));
            }
            else
            {
                dispenser.Receive(new Message(messageID, sender, content));
            }
        }

        public void RegisterService(int id, IService service) { services.RegisterService(id, service); }
        public void UnRegisterService(int id) { services.UnRegisterService(id); }
        public R CallService<T1, T2, T3, T4, R>(int id, T1 arg1, T2 arg2, T3 arg3, T4 arg4) { return services.CallService<T1, T2, T3, T4, R>(id, arg1, arg2, arg3, arg4); }
        public R CallService<T1, T2, T3,     R>(int id, T1 arg1, T2 arg2, T3 arg3         ) { return services.CallService<T1, T2, T3,     R>(id, arg1, arg2, arg3      ); }
        public R CallService<T1, T2,         R>(int id, T1 arg1, T2 arg2                  ) { return services.CallService<T1, T2,         R>(id, arg1, arg2            ); }
        public R CallService<T1,             R>(int id, T1 arg1                           ) { return services.CallService<T1,             R>(id, arg1                  ); }
        public R CallService<                R>(int id                                    ) { return services.CallService<                R>(id                        ); }
        // public T CallService<T>(int id, object sender, params object[] args) { return services.CallService<T>(id, sender, args); }

        public abstract T GetModule<T>(int moduleID) where T : Module;
    }
}
