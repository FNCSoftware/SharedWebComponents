using System;
using System.IO;
using System.Reflection;
using SharedWebComponents.Utility;

namespace SharedWebComponents.VirtualFileRouting {
    internal class VirtualFileRazorViewHelper {
        //todo: need to build this from web config dynamically
        const string PREPEND_TEMPLATE = @"@inherits System.Web.Mvc.WebViewPage{0}{1}@using System.Web.Mvc{2}@using System.Web.Optimization{3}@using System.Web.WebPages{4}@using System.Web.Mvc.Html{5}";

        public static string GetViewString(Stream stream) {
            string result;
            using (var reader = new StreamReader(stream)) {
                result = reader.ReadToEnd();
            }
            var modelString = GetModelString(result);
            if (!string.IsNullOrWhiteSpace(modelString)) {
                result = RemoveModelDeclaration(result);
            }
            var inheritsAndModelString = GetInheritsAndModelString(modelString);
            result = inheritsAndModelString + result;
            return result;
        }

        static string GetInheritsAndModelString(string modelString) {
            var result = string.Format(PREPEND_TEMPLATE, modelString, Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine);
            return result;
        }

        static string RemoveModelDeclaration(string result) {
            var modelDeclaration = result.BetweenInclusive("@model", Environment.NewLine);
            if (!String.IsNullOrWhiteSpace(modelDeclaration)) {
                result = result.Replace(modelDeclaration, "");
            }
            return result;
        }

        static string GetModelString(string input) {
            var model = input.BetweenExclusive("@model", Environment.NewLine).Trim();
            var type = Type.GetType(model, false);
            if (type == null) {
                return null;
            }
            var result = String.IsNullOrWhiteSpace(model) ? "" : "<" + model + ">";
            return result;
        }
    }
}