﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tavisca.CAPI.AccessKey.Model.Models.Errors {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Tavisca.CAPI.AccessKey.Model.Models.Errors.ErrorMessages", typeof(ErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to Access key activation failed.
        /// </summary>
        internal static string AccessKeyNotActivated {
            get {
                return ResourceManager.GetString("AccessKeyNotActivated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Access key deactivation failed.
        /// </summary>
        internal static string AccessKeyNotDeactivated {
            get {
                return ResourceManager.GetString("AccessKeyNotDeactivated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Access key generation failed.
        /// </summary>
        internal static string AccessKeyNotGenerated {
            get {
                return ResourceManager.GetString("AccessKeyNotGenerated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Client does not exists .
        /// </summary>
        internal static string ClientNotFound {
            get {
                return ResourceManager.GetString("ClientNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Access key for this client already present.
        /// </summary>
        internal static string KeyAlreadyExists {
            get {
                return ResourceManager.GetString("KeyAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Access key is already activated .
        /// </summary>
        internal static string KeyIsAlreadyActivated {
            get {
                return ResourceManager.GetString("KeyIsAlreadyActivated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Access key is already deactivated.
        /// </summary>
        internal static string KeyIsAlreadyDeactivated {
            get {
                return ResourceManager.GetString("KeyIsAlreadyDeactivated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter store is not responding.
        /// </summary>
        internal static string ParameterStoreNotResponding {
            get {
                return ResourceManager.GetString("ParameterStoreNotResponding", resourceCulture);
            }
        }
        internal static string ParameterStoreDeletionFailed
        {
            get
            {
                return ResourceManager.GetString("ParameterStoreDeletionFailed", resourceCulture);
            }
        }
        internal static string ParameterStoreAdditionFailed
        {
            get
            {
                return ResourceManager.GetString("ParameterStoreAdditionFailed", resourceCulture);
            }
        }
        internal static string ParameterStoreCommunicationError
        {
            get
            {
                return ResourceManager.GetString("ParameterStoreCommunicationError", resourceCulture);
            }
        }
    }
}
