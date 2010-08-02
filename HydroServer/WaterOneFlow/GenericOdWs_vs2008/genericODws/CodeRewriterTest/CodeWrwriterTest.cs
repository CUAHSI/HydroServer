using NUnit.Framework;
using System;
using System.Text;
using System.Collections.Generic;

namespace CodeRewriterTest
{
    /// <summary>
    ///This is a test class for WaterOneFlow.Utilities.text.CodeFieldCheck and is intended
    ///to contain all WaterOneFlow.Utilities.text.CodeFieldCheck Unit Tests
    ///</summary>
   [TestFixture()] 
    public class CodeFieldCheckTest
    {


   


        /// <summary>
        ///A test for Encode (StringBuilder)
        ///</summary>
        [Test()]
        public void EncodeTest()
        {
            String originalCodeValue = "a/"; // TODO: Initialize to an appropriate value

            string expected = "a-";
            string actual;

            actual = WaterOneFlow.Utilities.text.CodeFieldCheck.Encode(originalCodeValue);

            Assert.AreEqual(expected, actual, "WaterOneFlow.Utilities.text.CodeFieldCheck.Encode did not return the expected val" +
                    "ue.");


            }
        [Test()]
        public void EncodeTest1()
        {
            String originalCodeValue = "a "; // TODO: Initialize to an appropriate value

            string expected = "a_";
            string actual;

            actual = WaterOneFlow.Utilities.text.CodeFieldCheck.Encode(originalCodeValue);

            Assert.AreEqual(expected, actual, "WaterOneFlow.Utilities.text.CodeFieldCheck.Encode did not return the expected val" +
                    "ue.");


        }

        [Test()]
        public void EncodeTest2()
        {
            String originalCodeValue = "a:string"; // TODO: Initialize to an appropriate value

            string expected = "a-string";
            string actual;

            actual = WaterOneFlow.Utilities.text.CodeFieldCheck.Encode(originalCodeValue);

            Assert.AreEqual(expected, actual, "WaterOneFlow.Utilities.text.CodeFieldCheck.Encode did not return the expected val" +
                    "ue.");


        }

        [Test()]
        public void EncodeTest3()
        {
            String originalCodeValue = "a:string"; // TODO: Initialize to an appropriate value

            string expected = "a-string";
            string actual;

            actual = WaterOneFlow.Utilities.text.CodeFieldCheck.Encode(originalCodeValue);

            Assert.AreEqual(expected, actual, "WaterOneFlow.Utilities.text.CodeFieldCheck.Encode did not return the expected val" +
                    "ue.");


        }
        [Test()]
        public void EncodeTestToGibberish()
        {
            String originalCodeValue = "+++:\\=+++ "; // TODO: Initialize to an appropriate value

            string expected = "...---..._";
            string actual;

            actual = WaterOneFlow.Utilities.text.CodeFieldCheck.Encode(originalCodeValue);

            Assert.AreEqual(expected, actual, "WaterOneFlow.Utilities.text.CodeFieldCheck.Encode did not return the expected val" +
                    "ue.");


        }

    }
    /// <summary>
    ///This is a test class for WaterOneFlow.Utilities.text.TextFieldCheck and is intended
    ///to contain all WaterOneFlow.Utilities.text.TextFieldCheck Unit Tests
    ///</summary>
    [TestFixture]
    public class TextFieldCheckTest
    {


    

        /// <summary>
        ///A test for Encoder (string)
        ///</summary>
        [Test]
        public void EncodeTest()
        {
            string originalTextValue = "a \t \r\n a"; // TODO: Initialize to an appropriate value

            int stringLength = originalTextValue.Length;
            string expected = "a   a";

            string actual;

            actual = WaterOneFlow.Utilities.text.TextFieldCheck.Encode(originalTextValue);

            Assert.AreEqual(expected, actual, "WaterOneFlow.Utilities.text.TextFieldCheck.Encoder did not return the expected va" +
                    "lue.");
        }

        [Test]
        public void EncodeTest2()
        {
            string originalTextValue = "a:string\\\r\n string2"; // TODO: Initialize to an appropriate value

            int stringLength = originalTextValue.Length;
            string expected = "a:string\\ string2";

            string actual;

            actual = WaterOneFlow.Utilities.text.TextFieldCheck.Encode(originalTextValue);

            Assert.AreEqual(expected, actual, "WaterOneFlow.Utilities.text.TextFieldCheck.Encoder did not return the expected va" +
                    "lue.");
        }

    }


}
