﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FightCore.Resources.Controllers {
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
    public class LibraryResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LibraryResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FightCore.Resources.Controllers.LibraryResources", typeof(LibraryResources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Category filter must be -1 or must be a valid category value.
        /// </summary>
        public static string CategoryFilterInvalid {
            get {
                return ResourceManager.GetString("CategoryFilterInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Page number must be valid.
        /// </summary>
        public static string PageNumberInvalid {
            get {
                return ResourceManager.GetString("PageNumberInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Page number is outside range.
        /// </summary>
        public static string PageNumberOutsideRange {
            get {
                return ResourceManager.GetString("PageNumberOutsideRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Page size must be greater than 0 but no greater than {0}.
        /// </summary>
        public static string PageSizeWrongSize {
            get {
                return ResourceManager.GetString("PageSizeWrongSize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sort option must be valid.
        /// </summary>
        public static string SortOptionInvalid {
            get {
                return ResourceManager.GetString("SortOptionInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Both Content and FeaturedLink cannot be blank.
        /// </summary>
        public static string TitleAndLinkBlank {
            get {
                return ResourceManager.GetString("TitleAndLinkBlank", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title cannot be blank.
        /// </summary>
        public static string TitleCannotBeBlank {
            get {
                return ResourceManager.GetString("TitleCannotBeBlank", resourceCulture);
            }
        }
    }
}