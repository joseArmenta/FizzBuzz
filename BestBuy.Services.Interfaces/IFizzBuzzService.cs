using BestBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.Services.Interfaces
{
    public interface IFizzBuzzService
    {
        List<string> DoFizzBuzzEvaluation(ValidationCriteria parameters);
    }
}
