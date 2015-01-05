using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestBuy.Services.Interfaces;
using BestBuy.Models;
using System.Collections.Generic;

namespace BestBuy.Services.Test
{
    [TestClass]
    public class FizzBuzzServiceTest
    {
        private IFizzBuzzService _fizzBuzzSvc;
        private List<string> _validItems;
        private List<string> _mixedItems;
        private List<string> _invalidItems;
        private List<string> _easyTest;

        private ValidationCriteria GetValidationCriteria(string lowerVal, string higherVal, List<string> itemsToValidate)
        {
            return new ValidationCriteria
            {
                HigherNumber = higherVal,
                LowerNumber = lowerVal,
                ObjectsToValidate = itemsToValidate
            };
        }

        [TestInitializeAttribute]
        public void Initialize()
        {
            _fizzBuzzSvc = new FizzBuzzService();
            _validItems = new List<string> { int.MinValue.ToString(), decimal.MinValue.ToString(), "1", "2", "3", "4", "5", "60", "70", int.MaxValue.ToString(), uint.MaxValue.ToString(), double.MaxValue.ToString(), decimal.MaxValue.ToString() };
            _invalidItems = new List<string> { "A", "", null };
            _mixedItems = new List<string>(_validItems);
            _mixedItems.AddRange(_invalidItems);
            _easyTest = new List<string> { "1", "3", "5", null, "15", "A", "23" };
        }

        #region Parameter Tests

        [TestMethod]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void InvalidNullParameters()
        {
            var results = _fizzBuzzSvc.DoFizzBuzzEvaluation(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void InvalidLowerVal()
        {
            var parameters = this.GetValidationCriteria(null, "5", _validItems);
            var results = _fizzBuzzSvc.DoFizzBuzzEvaluation(parameters);
        }

        [TestMethod]
        public void ValidLowerVal()
        {
            var parameters = this.GetValidationCriteria("-1.7976931348623157", "5", _validItems);
            var results = _fizzBuzzSvc.DoFizzBuzzEvaluation(parameters);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void InvalidHigherVal()
        {
            var parameters = this.GetValidationCriteria("5", null, _validItems);
            var results = _fizzBuzzSvc.DoFizzBuzzEvaluation(parameters);
        }

        [TestMethod]
        public void ValidHigherVal()
        {
            var parameters = this.GetValidationCriteria("-1.7976931348623157", "1.7976931348623157", _validItems);
            var results = _fizzBuzzSvc.DoFizzBuzzEvaluation(parameters);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void LowerNumberToZero()
        {
            var parameters = this.GetValidationCriteria("0", "1.7976931348623157", _validItems);
            var results = _fizzBuzzSvc.DoFizzBuzzEvaluation(parameters);
        }

        #endregion

        [TestMethod]
        public void DoFizzBuzzSimpleEvaluationTest()
        {
            var validationCriteria = new ValidationCriteria { HigherNumber = "5", LowerNumber = "3", ObjectsToValidate = _easyTest };

            var results = _fizzBuzzSvc.DoFizzBuzzEvaluation(validationCriteria);
            var expectedResults = new List<string> { "Divided 1 by 3", "Divided 1 by 5", "Fizz", "Buzz", "Invalid Item", "FizzBuzz", "Invalid Item", "Divided 23 by 3", "Divided 23 by 5" };

            for (var i = 0; i < results.Count; i++)
            {
                Assert.IsTrue(results[i] == expectedResults[i]);
            }
        }

        [TestMethod]
        public void DoFizzBuzzWithDoubleNumbersTest()
        {
            var validationCriteria = new ValidationCriteria { HigherNumber = ".2", LowerNumber = ".1", ObjectsToValidate = _easyTest };

            var results = _fizzBuzzSvc.DoFizzBuzzEvaluation(validationCriteria);
            var expectedResults = new List<string> { 
                "Divided 1 by .1", "Divided 1 by .2", "Divided 3 by .1", "Divided 3 by .2", 
                "Divided 5 by .1", "Divided 5 by .2", "Invalid Item", "Divided 15 by .1", 
                "Divided 15 by .2", "Invalid Item", "Divided 23 by .1", "Divided 23 by .2" 
            };

            for (var i = 0; i < results.Count; i++)
            {
                Assert.IsTrue(results[i] == expectedResults[i]);
            }
        }

        [TestMethod]
        public void DoFizzBuzzWithValidItemsTest()
        {
            var validationCriteria = new ValidationCriteria { HigherNumber = "5", LowerNumber = "3", ObjectsToValidate = _validItems };

            var results = _fizzBuzzSvc.DoFizzBuzzEvaluation(validationCriteria);
            var expectedResults = new List<string> { 
                "Divided -2147483648 by 3", "Divided -2147483648 by 5",
                "Divided -79228162514264337593543950335 by 3", "Divided -79228162514264337593543950335 by 5",
                "Divided 1 by 3", "Divided 1 by 5",
                "Divided 2 by 3", "Divided 2 by 5",
                "Fizz",         //3
                "Divided 4 by 3", "Divided 4 by 5",
                "Buzz",         //5
                "FizzBuzz",     //60
                "Buzz",         //70
                "Divided 2147483647 by 3", "Divided 2147483647 by 5",
                "FizzBuzz",     //4294967295
                "Invalid Item", //"1.79769313486232E+308"
                "Divided 79228162514264337593543950335 by 3", "Divided 79228162514264337593543950335 by 5"
            };

            for (var i = 0; i < results.Count; i++)
            {
                Assert.IsTrue(results[i] == expectedResults[i]);
            }
        }
    }
}
