using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace WaterOneFlow.Utilities
{
    namespace text
    {



        /// <summary>
        /// Rewrites xxCode fields to remove non-approved characters.
        /// <para>This class is to be used by applications to consistently map 
        /// unapproved characters to approved characters. 
        /// </para>
        ///  <para>At present, this SiteCode and VariableCode  </para>
        /// <list type="number">
        /// <item>space to underscore</item>
        /// <item>comma to dot</item>
        /// <item>colon to dash</item>
        /// <item>slash to dash</item>
        /// <item>equals to dash</item>
        /// <item>plus to  dot</item>
        /// </list>
        /// <remarks>This is not reversable, since 
        /// input strings may use the defined charcaters, intentionally.</remarks>
        /// </summary>
        ///  
        public class CodeFieldCheck
        {
            /// <summary>
            /// This is a list of character replaements
            /// </summary>
            /// <returns></returns>
           private static Dictionary<char, char> CodeReplacements()
            {
                Dictionary<char, char> r = new Dictionary<char, char>();
                r.Add(' ', '_'); //space to underscore
                r.Add(',', '.'); // comma to dot
                r.Add(':', '-');// colon to dash
                r.Add('/', '-');//slash to dash
                r.Add('\\', '-');//slash(escaped) to dash
               r.Add('=', '-');//equals to dash
                r.Add('+', '.');//plus to  dot
                // if you add a value, add do documentation.

                return r;
            }
            /// <summary>
            /// Rewrites xxCode fields to remove non-approved characters.
            /// <para>This class is to be used by applications to consistently map 
            /// unapproved characters to approved characters. 
            /// </para>
            ///  <para>At present, this SiteCode and VariableCode  </para>
            /// <list type="number">
            /// <item>space to underscore</item>
            /// <item>comma to dot</item>
            /// <item>colon to dash</item>
            /// <item>slash to dash</item>
            /// <item>equals to dash</item>
            /// <item>plus to  dot</item>
            /// </list>
            /// <remarks>This is not reversable, since 
            /// input strings may use the defined charcaters, intentionally.</remarks>
            /// </summary>
            /// <param name="originalCodeValue"></param>
            /// <returns></returns>
            public static string Encode(StringBuilder originalCodeValue)
            {
                // StringBuilder is a mutable string... faster.
                StringBuilder newCodeValue = originalCodeValue;

                foreach (KeyValuePair<char, char> kvp in CodeReplacements())
                {
                    newCodeValue = newCodeValue.Replace(kvp.Key, kvp.Value);
                }

                string returnValue = TextFieldCheck.Encode(newCodeValue.ToString());
                return returnValue;

            }
            /// <summary>
            /// Rewrites xxCode fields to remove non-approved characters.
            /// </summary>
            /// <see cref="Encode(StringBuilder)"/>
            /// <param name="originalCodeValue"></param>
            /// <returns></returns>
            public static string Encode(string originalCodeValue)
            {
                StringBuilder newCodeValue = new StringBuilder(originalCodeValue);
                return Encode(newCodeValue);
            }
        }

        /// <summary>
        /// Rewrites Text fields to remove non-approved characters.
        /// <para>This class is to be used by applications to
        ///  consistently  
        /// remove unapproved characters. 
        /// </para>
        ///  
        /// <list type="number">
        /// <item>tab</item>
        /// <item>return</item>
        /// <item>linefeed</item>
        /// </list>
        /// <remarks>This is not reversable, since 
        /// input strings have been changed.</remarks>
        /// </summary>

        public class TextFieldCheck
        {
            private static string TextRemoval = "[\t\r\n]";
            private static Regex reg = new Regex(TextRemoval, RegexOptions.Compiled);

            public static string Encode(string originalTextValue)
            {

                string newTextValue;
                newTextValue = originalTextValue.Trim();
                
                newTextValue = reg.Replace(newTextValue, String.Empty);
                return newTextValue;
            }

        }
    }
}
