﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dokumentasi.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("dokumentasi.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to body {
        ///    background: white;
        ///    color: black;
        ///    font: 14px/1.5 sans-serif
        ///}
        ///table {
        ///    border-collapse: collapse;
        ///    table-layout: fixed;
        ///    width: 100%
        ///}
        ///table, th, td {
        ///    border: 1px solid gray;
        ///    padding: .5em;
        ///    text-align: left;
        ///    vertical-align: top
        ///}
        ///th {
        ///    background: lightgrey
        ///}
        ///dt {
        ///    font-weight: bold
        ///}
        ///body &gt; ul {
        ///    padding-left: 0
        ///}
        ///ul {
        ///    list-style: none inside;
        ///    padding-left: 1.5em
        ///}.
        /// </summary>
        public static string style {
            get {
                return ResourceManager.GetString("style", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;xsl:stylesheet version=&quot;1.0&quot; xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot;/&quot;&gt;
        ///
        ///  &lt;xsl:output method=&quot;html&quot; omit-xml-declaration=&quot;yes&quot; indent=&quot;no&quot; encoding=&quot;utf-8&quot;/&gt;
        ///
        ///  &lt;xsl:param name=&quot;current&quot;/&gt;
        ///
        ///  &lt;xsl:template match=&quot;//HelpTOC&quot;&gt;
        ///    &lt;div class=&quot;leftNav&quot; id=&quot;leftNav&quot;&gt;
        ///      &lt;div class=&quot;toc&quot; id=&quot;tocNav&quot;&gt;
        ///        &lt;ul&gt;
        ///          &lt;xsl:apply-templates/&gt;
        ///        &lt;/ul&gt;
        ///      &lt;/div&gt;
        ///    &lt;/div&gt;
        ///  &lt;/xsl:template&gt;
        ///
        ///  &lt;xsl:template match=&quot;HelpTOCNode&quot;&gt;
        ///    [rest of string was truncated]&quot;;.
        /// </summary>
        public static string toc {
            get {
                return ResourceManager.GetString("toc", resourceCulture);
            }
        }
    }
}
