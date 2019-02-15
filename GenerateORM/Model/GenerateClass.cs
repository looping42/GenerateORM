using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    public class GenerateClass
    {
        private CodeCompileUnit targetUnit;
        private CodeTypeDeclaration targetClass;

        public GenerateClass(CodeCompileUnit targetunit, CodeTypeDeclaration targetclass)

        {
            targetUnit = targetunit;
            targetClass = targetclass;
        }

        public void CreateClass(string nameSpace, List<BddTable> bddtables)
        {
            CodeNamespace samples = new CodeNamespace(nameSpace);
            samples.Imports.Add(new CodeNamespaceImport("System"));
            samples.Types.Add(targetClass);
            targetClass.IsClass = true;
            targetClass.TypeAttributes = TypeAttributes.Public | TypeAttributes.Class;
            targetUnit.Namespaces.Add(samples);

            //CodeEntryPointMethod start = new CodeEntryPointMethod();
            //foreach (BddTable item in bddtables)
            //{
            //    start.Statements.Add(new CodeVariableReferenceExpression(item.ToString()));
            //}

            //targetClass.Members.Add(start);
            AddFields(bddtables);
        }

        public void GenerateCSharpCode(string fileName)
        {
            var file = Path.Combine(fileName, "testcs");
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            using (StreamWriter sourceWriter = new StreamWriter(file))
            {
                provider.GenerateCodeFromCompileUnit(targetUnit, sourceWriter, options);
            }
        }

        public void AddFields(List<BddTable> bddtables)
        {
            foreach (BddTable bddTable in bddtables)
            {
                foreach (BddLine bddLine in bddTable.bddLines)
                {
                    CodeMemberField field = new CodeMemberField
                    {
                        Name = bddLine.ColumnName,
                        Attributes = MemberAttributes.Public,
                        Type = new CodeTypeReference(bddLine.ColumnType),
                    };
                    field.Name += " { get;  set; }";
                    targetClass.Members.Add(field);
                }
            }

            // Declare the widthValue field.
            //CodeMemberField widthValueField = new CodeMemberField();
            //widthValueField.Attributes = MemberAttributes.Private;
            //widthValueField.Name = "widthValue";
            //widthValueField.Type = new CodeTypeReference(typeof(System.Double));
            //widthValueField.Comments.Add(new CodeCommentStatement(
            //    "The width of the object."));
            //targetClass.Members.Add(widthValueField);

            //// Declare the heightValue field
            //CodeMemberField heightValueField = new CodeMemberField();
            //heightValueField.Attributes = MemberAttributes.Private;
            //heightValueField.Name = "heightValue";
            //heightValueField.Type =
            //    new CodeTypeReference(typeof(System.Double));
            //heightValueField.Comments.Add(new CodeCommentStatement(
            //    "The height of the object."));
            //targetClass.Members.Add(heightValueField);
        }

        /// <summary>
        /// Add an entry point to the class.
        /// </summary>
        public void AddEntryPoint()
        {
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            string pattern = "Info.Valid(\"\"{0}\"\", \"\"{1}\"\", \"\"{2}\"\", \"\"{3}\"\", \"\"{4}\")";

            start.Statements.Add(new CodeVariableReferenceExpression(pattern));

            targetClass.Members.Add(start);
        }
    }
}