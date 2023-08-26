using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    //Bu interface'in amaci test ederken bir token verilmesi ya da baska bir teknik ile token üretilebilecegini göz önüne almaktir.
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
