﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zongsoft.Scheduling.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Zongsoft.Scheduling.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 重试丢弃 的本地化字符串。
        /// </summary>
        internal static string Retriever_Discarded_Name {
            get {
                return ResourceManager.GetString("Retriever.Discarded.Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 重试失败 的本地化字符串。
        /// </summary>
        internal static string Retriever_Failed_Name {
            get {
                return ResourceManager.GetString("Retriever.Failed.Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 重试成功 的本地化字符串。
        /// </summary>
        internal static string Retriever_Succeed_Name {
            get {
                return ResourceManager.GetString("Retriever.Succeed.Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 处理失败 的本地化字符串。
        /// </summary>
        internal static string Scheduler_Handled_Failed {
            get {
                return ResourceManager.GetString("Scheduler.Handled.Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 处理成功 的本地化字符串。
        /// </summary>
        internal static string Scheduler_Handled_Succeed {
            get {
                return ResourceManager.GetString("Scheduler.Handled.Succeed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 执行处理器：{0} 的本地化字符串。
        /// </summary>
        internal static string Scheduler_Handlers {
            get {
                return ResourceManager.GetString("Scheduler.Handlers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 未执行过 的本地化字符串。
        /// </summary>
        internal static string Scheduler_NoLastTime {
            get {
                return ResourceManager.GetString("Scheduler.NoLastTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不再执行 的本地化字符串。
        /// </summary>
        internal static string Scheduler_NoNextTime {
            get {
                return ResourceManager.GetString("Scheduler.NoNextTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 触发完成 的本地化字符串。
        /// </summary>
        internal static string Scheduler_Occurred_Name {
            get {
                return ResourceManager.GetString("Scheduler.Occurred.Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 触发开始 的本地化字符串。
        /// </summary>
        internal static string Scheduler_Occurring_Name {
            get {
                return ResourceManager.GetString("Scheduler.Occurring.Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 无期限 的本地化字符串。
        /// </summary>
        internal static string Scheduler_Retry_NoExpiration {
            get {
                return ResourceManager.GetString("Scheduler.Retry.NoExpiration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 首次重试 的本地化字符串。
        /// </summary>
        internal static string Scheduler_Retry_NoTimestamp {
            get {
                return ResourceManager.GetString("Scheduler.Retry.NoTimestamp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 排程完成 的本地化字符串。
        /// </summary>
        internal static string Scheduler_Scheduled_Name {
            get {
                return ResourceManager.GetString("Scheduler.Scheduled.Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 调度触发器：{0} 的本地化字符串。
        /// </summary>
        internal static string Scheduler_Triggers {
            get {
                return ResourceManager.GetString("Scheduler.Triggers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 调度命令集的根命令，提供调度器切换和注入功能。 的本地化字符串。
        /// </summary>
        internal static string SchedulerCommand_Description {
            get {
                return ResourceManager.GetString("SchedulerCommand.Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 调度器命令 的本地化字符串。
        /// </summary>
        internal static string SchedulerCommand_Name {
            get {
                return ResourceManager.GetString("SchedulerCommand.Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 指定要切换的调度器名称。 的本地化字符串。
        /// </summary>
        internal static string SchedulerCommand_Options_Name {
            get {
                return ResourceManager.GetString("SchedulerCommand.Options.Name", resourceCulture);
            }
        }
    }
}
