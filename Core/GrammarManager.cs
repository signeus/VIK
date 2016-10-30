using System;
using System.Speech.Recognition;

namespace VIK.Core
{
    class GrammarManager
    {
        private String fileGrammar = string.Empty;

        public GrammarManager(String fileGrammar)
        {
            this.fileGrammar = fileGrammar;
        }

        public GrammarManager(){ }

        private Grammar DefaultGrammar()
        {
            return new DictationGrammar();
        }

        public Grammar CustomGrammar()
        {
            if (String.IsNullOrWhiteSpace(fileGrammar))
                return DefaultGrammar();

            Grammar customGrammar = new Grammar(AppDomain.CurrentDomain.BaseDirectory + "//" + fileGrammar);
            // TODO Decide if the xml have some format for Description or other things.
            customGrammar.Name = "Test";

            return customGrammar;
        }
    }
}
