using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// TODO <include>

namespace dokumentasi
{
    class BaseTags
    {

    }
    
    /// <summary>
    /// <c>TestTags</c> is a class in the <code>dokumentasi</code> namespace.
    /// <code>
    /// multiple line
    /// code
    /// </code>
    /// It can be used like this:
    /// <example>
    /// <code>
    /// var t = new TestTags();
    /// </code>
    /// </example>
    /// Exceptions: <exception cref="N.E">E</exception>
    /// </summary>
    class TestTags: BaseTags
    {
        /// <remarks>Here is an example of a bulleted list:
        /// <list type="bullet">
        /// <item>
        /// <description>Item 1.</description>
        /// </item>
        /// <item>
        /// <description>Item 2.</description>
        /// </item>
        /// </list>
        /// </remarks>
        public void SomeMethod1()
        {

        }

        /// <summary>
        /// <para>paragraph1</para>
        /// <para>paragraph2</para>
        /// </summary>
        public void SomeMethod2()
        {

        }

        /// <remarks>MyMethod is a method in the MyClass class.  
        /// The <paramref name="Int1"/> parameter takes a number.
        /// </remarks>
        public void SomeMethod3(int Int1)
        { 
        }

        /// <permission cref="System.Security.PermissionSet">Everyone can access this method.</permission>
        /// <remarks>
        /// <see cref="dokumentasi.TestTags.SomeMethod3"/>
        /// <seealso cref="dokumentasi.TestTags.SomeMethod3"/>
        /// </remarks>
        public static void SomeMethod4()
        {
        }
   
        /// <returns>Returns zero.</returns>
        public static int SomeMethod5()
        {
            return 0;
        }

        /// <value>Name accesses the value of the name data member</value>
        public string SomeProperty { get; set; }
    }
}
