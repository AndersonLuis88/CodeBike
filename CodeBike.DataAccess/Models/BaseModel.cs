using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBikeAPI.DataAccess.Models.Abstract
{
    public class BaseModel
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
    }
}
