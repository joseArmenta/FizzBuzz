using System;
using System.Collections.Generic;
using BestBuy.Services.Interfaces;
using BestBuy.Models;
using BestBuy.Utils.Extensions;
using System.Text;

namespace BestBuy.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        #region Private Methods

        private bool IsNumeric(string toValidate)
        {
            if (string.IsNullOrWhiteSpace(toValidate))
                return false;

            return toValidate.IsNumeric();
        }

        private void ValidateLowerAndHigherNumbers(ValidationCriteria parameters)
        {
            var isValidL = IsNumeric(parameters.LowerNumber);
            var isValidH = IsNumeric(parameters.HigherNumber);

            if(!isValidH && !isValidL)
                throw new Exception("Invalid Higher and Lower Numbers");
            
            if(!isValidH)
                throw new Exception("Invalid Higher Number");

            if (!isValidL)
                throw new Exception("Invalid Lower Number");

            if(parameters.LowerNumber.ToDecimal() == 0)
                throw new Exception("Lower Number must be nonzero.");

            if (parameters.HigherNumber.ToDecimal() == 0)
                throw new Exception("Higher Number must be nonzero.");

        }

        private bool IsInvalid(string toTest)
        {
            return !IsNumeric(toTest);
        }

        private bool IsFizz(string toTest, string lowerNumber)
        {
            return (toTest.ToDecimal() % lowerNumber.ToDecimal()) == 0;
        }

        private bool IsBuzz(string toTest, string higherNumber)
        {
            return (toTest.ToDecimal() % higherNumber.ToDecimal()) == 0;
        }

        #endregion

        public List<string> DoFizzBuzzEvaluation(ValidationCriteria parameters)
        {
            if (parameters == null)
                throw new NullReferenceException();

            ValidateLowerAndHigherNumbers(parameters);
            
            var results = new List<string>();
            if (parameters.ObjectsToValidate.Count == 0)
                results.Add("No items to evaluate");
                
            parameters.ObjectsToValidate.ForEach(
                x =>
                {
                    if (IsInvalid(x))
                    {
                        results.Add("Invalid Item");
                    }
                    else
                    {
                        var isFizz = IsFizz(x, parameters.LowerNumber);
                        var isBuzz = IsBuzz(x, parameters.HigherNumber);

                        if (!isFizz && !isBuzz)
                        {
                            results.Add(string.Format("Divided {0} by {1}", x, parameters.LowerNumber));
                            results.Add(string.Format("Divided {0} by {1}", x, parameters.HigherNumber));
                        }
                        else
                        {
                            var text = new StringBuilder();

                            if (isFizz)
                                text.Append("Fizz");

                            if (isBuzz)
                                text.Append("Buzz");

                            if (text.Length > 0)
                                results.Add(text.ToString());
                        }
                    }
                }
            );

            return results;
        }
    }
}