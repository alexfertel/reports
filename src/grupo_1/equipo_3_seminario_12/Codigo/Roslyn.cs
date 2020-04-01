//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Build.Locator;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Symbols;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.CodeAnalysis.MSBuild;
//using Microsoft.CodeAnalysis.Text;

//namespace SemanticQuickStart
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Ingrese la ruta del archivo");
//            var path = Console.ReadLine();
//            var code = File.ReadAllText(path);

//            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            
//            var root = tree.GetRoot();
      
//            var ifStatements = root.DescendantNodes().OfType<IfStatementSyntax>();
            
//            Console.WriteLine($"La cantidad de instrucciones if en el programa es: {ifStatements.Count()}");
//            Console.WriteLine($"La cantidad de instrucciones if-else en el programa es: {ifStatements.Count(p => p.Else != null)}");
//            //var compilation = CSharpCompilation.Create("HelloWorld")
//            //                    .AddReferences(
//            //                        MetadataReference.CreateFromFile(
//            //                            typeof(object).Assembly.Location))
//            //                    .AddSyntaxTrees(tree);
//            //var model = compilation.GetSemanticModel(tree);
//            //var nameInfo = model.GetSymbolInfo(root.Usings[0].Name);
//            //var systemSymbol = (INamespaceSymbol)nameInfo.Symbol;
            
//        }


//    }
//}
