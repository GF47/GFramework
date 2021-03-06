﻿using System;

namespace GMessage
{
    /// <summary>
    /// 提供普通的框架内服务，调用者通过服务ID来调用并获取结果
    /// </summary>
    public class CommonService : IService
    {
        /// <summary>
        /// 暴露给公众的方法
        /// </summary>
        public Delegate Call { get; }


        /// <summary>
        /// 生成普通的框架内服务
        /// <example>
        /// 示例
        /// <code>
        /// var cs = new CommonService(new Func&lt;int, float&gt;(method_param_int_return_float));
        /// AppFacade.Instance.RegisterService(serviceID, cs);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="delegate_">执行服务的具体方法，不可以直接传入方法名，而是需要实例化一个相同声明格式的委托</param>
        public CommonService(Delegate delegate_)
        {
            Call = delegate_;
        }
    }
}
