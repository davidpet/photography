using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace Petrofsky.Photography.LUTGenerator.Scripting
{
    public class ScriptFilter: Graphics.IFilter
    {
        public ScriptFilter(string scriptText)
        {
            Validation.CheckObject("scriptText", scriptText);

            //initialize python
            runtime = Python.CreateRuntime();
            engine = Python.GetEngine(runtime);
            //load the script
            source = engine.CreateScriptSourceFromString(scriptText);
            script = source.Compile();
        }

        private ScriptRuntime runtime;
        private ScriptEngine engine;
        private ScriptSource source;
        private CompiledCode script;

        #region IFilter Members

        public System.Drawing.Color Filter(System.Drawing.Color color)
        {
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("Red", (int)color.R);
            scope.SetVariable("Green", (int)color.G);
            scope.SetVariable("Blue", (int)color.B);

            script.Execute(scope);

            int r = scope.GetVariable("Red");
            int g = scope.GetVariable("Green");
            int b = scope.GetVariable("Blue");

            return System.Drawing.Color.FromArgb(r, g, b);
        }

        #endregion
    }
}
