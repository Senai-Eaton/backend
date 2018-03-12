
using Microsoft.EntityFrameworkCore;

namespace eaton.agir.repository.Context
{
    public class AgirContext: DbContext

    {
        public AgirContext(DbContextOptions<AgirContext> options): base(options)
        {
            
        }
        
        
    }
}