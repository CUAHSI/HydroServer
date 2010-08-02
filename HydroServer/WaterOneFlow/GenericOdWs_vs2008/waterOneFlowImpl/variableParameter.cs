using System;
using System.Collections.Generic;
using System.Text;


/* this object is being created to handle parsing and creation of a vocabulary object 
 and  allow for vocabulary translation. Basically, any translation should be able to happen here.
 * Author:
 * Valentine june 2007
 * 
 * TODO: 
 * Add options to properly handle a timeSupport option, when passed
*/
namespace WaterOneFlowImpl
{
    using WaterOneFlow.Schema.v1;

    public class VariableParam
    {

        static String variableParamForm = "VOCABULARY:code/option/optionN";
        static String sep = ":/";
        static String optionSep = "=";
        protected static String variableIDVocabulary = "BYID"; // vocabulary that say this id a variable ID

        protected bool isIdField = false;

        protected string variableOriginal;

        /// <summary>
        /// Vocabulary
        /// Leading and trailing spaces are trimmed.
        /// </summary>


        protected String VocabularyField;

        /// <summary>
        /// Vocabulary Code
        /// </summary>
        protected String CodeField;

        /// <summary>
        /// list of options.
        /// </summary>
        protected Dictionary<String, String> optionsList = new Dictionary<String, String>();

        /// <summary>
        /// Vocabulary
        /// Leading and trailing spaces are trimmed.
        /// </summary>
        public String Vocabulary
        {
            get
            {
                return this.VocabularyField;

            }
            set
            {
                this.VocabularyField = value.Trim();
            }
        }
        /// <summary>
        /// Leading and trailing spaces are trimmed.
        /// </summary>
        public String Code
        {
            get
            {
                return this.CodeField;

            }
            set
            {
                this.CodeField = WaterOneFlow.Utilities.text.CodeFieldCheck.Encode(value);
            }
        }

        public Dictionary<String, String> options
        {
            get
            {
                return this.optionsList;

            }
            set
            {
                this.optionsList = value;
            }
        }

        public bool IsId
        {
            get { return isIdField; }
            set { isIdField = value; }
        }


        public VariableParam(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new WaterOneFlowException("Bad Variable Parameter. Please enter a non-empty or not null  variable parameter");
            }
            variableOriginal = input;
            String[] s = input.Split(sep.ToCharArray());
            if (s.Length < 2)
            {
                throw new WaterOneFlowException("Bad Variable Parameter. Variable parameters have the form: " + variableParamForm);
            }
            Vocabulary = s[0];
            if (Vocabulary.Equals(variableIDVocabulary, StringComparison.InvariantCultureIgnoreCase))
            {
                IsId = true;
            }
            Code = s[1];
            if (s.Length > 2)
            {

                for (int i = 2; i < s.Length; i++)
                {
                    String[] l = s[i].Split(optionSep.ToCharArray());
                    if (l.Length < 2)
                    {
                        throw new WaterOneFlowException("Variable options should be key=value pairs " + variableParamForm);

                    }
                    else
                    {
                        addOption(l[0], l[1]);
                    }
                }
            }
        }

        public void addOption(String key, String opt)
        {
            // lowercase
            string lcKey = key.ToLowerInvariant();
            optionsList.Add(lcKey, opt);
        }

        public virtual VariableInfoType getVariableSchemaType()
        {
            VariableInfoType vdt = v1_0.CuahsiBuilder.CreateVariableDescriptionType();

            vdt.variableCode[0].Value = Code;
            vdt.variableCode[0].vocabulary = Vocabulary;
            if (options.Count > 0)
            {

                option[] opts = new option[options.Count];
                int i = 0;
                foreach (string key in options.Keys)
                {
                    opts[i] = new option();
                    opts[i].name = key;
                    opts[i].Value = options[key];

                    i++;
                }
                vdt.options = opts;
            }
            return vdt;
        }

        public override String ToString()
        {
            return variableOriginal;
        }


    }

    namespace v1_0
    {
        using WaterOneFlow.Schema.v1;
        public class VariableParam : WaterOneFlowImpl.VariableParam
        {

            public VariableParam(String input)
                : base(input)
            {

            }

            //public new VariableInfoType getVariableSchemaType()
            //{
            //    VariableInfoType vdt = v1_0.CuahsiBuilder.CreateVariableDescriptionType();

            //    vdt.variableCode[0].Value = Code;
            //    vdt.variableCode[0].vocabulary = Vocabulary;
            //    if (options.Count > 0)
            //    {

            //        option[] opts = new option[options.Count];
            //        int i = 0;
            //        foreach (string key in options.Keys)
            //        {
            //            opts[i] = new option();
            //            opts[i].name = key;
            //            opts[i].Value = options[key];

            //            i++;
            //        }
            //        vdt.options = opts;
            //    }
            //    return vdt;
            //}

            public override String ToString()
            {
                return variableOriginal;
            }
        }
    }

    namespace v1_1
    {
        using WaterOneFlow.Schema.v1_1;

        public class VariableParam : WaterOneFlowImpl.VariableParam
        {

            public VariableParam(String input)
                : base(input)
            {

            }

            public new VariableInfoType getVariableSchemaType()
            {
                VariableInfoType vdt = v1_1.CuahsiBuilder.CreateVariableDescriptionType();

                vdt.variableCode[0].Value = Code;
                vdt.variableCode[0].vocabulary = Vocabulary;
                if (options.Count > 0)
                {

                    option[] opts = new option[options.Count];
                    int i = 0;
                    foreach (string key in options.Keys)
                    {
                        opts[i] = new option();
                        opts[i].name = key;
                        opts[i].Value = options[key];

                        i++;
                    }
                    vdt.options = opts;
                }
                return vdt;
            }

            public override String ToString()
            {
                return variableOriginal;
            }
        }
    }
}
