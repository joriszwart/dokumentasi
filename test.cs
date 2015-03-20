///
///
using System;
namespace SomeNamespace  // "N:SomeNamespace"
{
   public class E : Exception {};
   ///
   ///
   public /* unsafe */ class SomeClass    // "T:SomeNamespaceX"
   {
      /// <summary>
      /// 
      /// </summary>
      public SomeClass(){}   // "M:SomeNamespace.SomeClass.#ctor"
      // public SomeClass(){} // "M:SomeNamespace.SomeClass.#cctor", a class constructor
      /// <summary>
      /// 
      /// </summary>
      /// <param name="i"></param>
      public SomeClass(int i){}  // "M:SomeNamespaceX.#ctor(System.Int32)"
      /// <summary>
      /// 
      /// </summary>
      ~SomeClass(){}  // "M:SomeNamespace.SomeClass.Finalize", destructor's representation in metadata
      
      /// <summary>
      /// 
      /// </summary>
      public string q;  // "F:SomeNamespace.SomeClass.q"
      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public const double PI = 3.14;  // "F:SomeNamespace.SomeClass.PI"
      /// <summary>
      /// 
      /// </summary>
      /// <param name="s"></param>
      /// <param name="y"></param>
      /// <param name="z"></param>
      /// <returns></returns>
      public int f(){return 1;}  // "M:SomeNamespace.SomeClass.f"
      /// <summary>
      /// 
      /// </summary>
      /// <param name="array1"></param>
      /// <param name="array"></param>
      /// <returns></returns>
//      public int bb(string s, ref int y, void * z){return 1;}
      // "M:SomeNamespace.SomeClass.bb(System.String,System.Int32@,=System.Void*)"
      /// <summary>
      /// 
      /// </summary>
      /// <param name="x"></param>
      /// <param name="xx"></param>
      /// <returns></returns>
      public int gg(short[] array1, int[,] array){return 0;}
      // "M:SomeNamespace.SomeClass.gg(System.Int16[], System.Int32[0:,0:])"
      /// <summary>
      /// 
      /// </summary>
      public static SomeClass operator+(SomeClass x, SomeClass xx){return x;} // "M:SomeNamespace.SomeClass.op_Addition(SomeNamespace.SomeClass,SomeNamespace.SomeClass)"
      /// <summary>
      /// 
      /// </summary>
      public int prop {get{return 1;} set{}} // "P:SomeNamespace.SomeClass.prop"
      /// <summary>
      /// 
      /// </summary>
      ///
      public event D d; // "E:SomeNamespace.SomeClass.d"
      /// <summary>
      /// 
      /// </summary>
      public int this[string s]{get{return 1;}} // "P:SomeNamespace.SomeClass.Item(System.String)"
      /// <summary>
      /// 
      /// </summary>
      public class Nested{} // "T:SomeNamespace.SomeClass.Nested"
      /// <summary>
      /// 
      /// </summary>
      public delegate void D(int i); // "T:SomeNamespaceX.D"
      /// <summary>
      /// 
      /// </summary>
      /// <param name="x"></param>
      /// <returns></returns>
      public static explicit operator int(SomeClass x){return 1;} 
      // "M:SomeNamespace.SomeClass.op_Explicit(SomeNamespace.SomeClass)~System.Int32"
   }
}