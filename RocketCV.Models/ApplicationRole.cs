﻿namespace RocketCV.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AspNetCore.Identity.MongoDbCore.Models;
    using MongoDbGenericRepository.Attributes;

    [CollectionName("roles")]
    public class ApplicationRole : MongoIdentityRole<Guid>
    {

    }
}
