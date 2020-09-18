using Microsoft.AspNetCore.Authorization;

namespace HybirdMvcClient.Requirements
{
    public class SmithInSomewhereRequirement: IAuthorizationRequirement
    {
        public SmithInSomewhereRequirement()
        {
            
        }
    }
}
