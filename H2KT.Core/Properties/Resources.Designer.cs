﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace H2KT.Core.Properties {
    using System;
    
    
    
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        
        ///   Returns the cached ResourceManager instance used by this class.
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("H2KT.Core.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        
        ///   Looks up a localized string similar to Your account is activated!.
        
        internal static string ActivateAccount_Activated {
            get {
                return ResourceManager.GetString("ActivateAccount_Activated", resourceCulture);
            }
        }
        
        
        ///   Looks up a localized string similar to Your account was already activated!.
        
        internal static string ActivateAccount_AlreadyActivated {
            get {
                return ResourceManager.GetString("ActivateAccount_AlreadyActivated", resourceCulture);
            }
        }
        
        
        ///   Looks up a localized string similar to Email sent, please check your inbox to confirm.
        
        internal static string ActivateAccount_Confirm {
            get {
                return ResourceManager.GetString("ActivateAccount_Confirm", resourceCulture);
            }
        }
        
        
        ///   Looks up a localized string similar to Could not find you!.
        
        internal static string ActivateAccount_CouldNotFind {
            get {
                return ResourceManager.GetString("ActivateAccount_CouldNotFind", resourceCulture);
            }
        }
        
        
        ///   Looks up a localized string similar to Confirmation email resent, maybe check your spam?.
        
        internal static string ActivateAccount_Resend {
            get {
                return ResourceManager.GetString("ActivateAccount_Resend", resourceCulture);
            }
        }
    }
}